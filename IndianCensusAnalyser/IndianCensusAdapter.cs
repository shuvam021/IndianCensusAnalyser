using System.Collections.Generic;
using System.Linq;

namespace IndianCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        private string[] _data;
        private readonly Dictionary<string, CensusDTO> _state = new Dictionary<string, CensusDTO>();
        public Dictionary<string, CensusDTO> LoadCensusData(string path, string headers)
        {
            _data = GetCensusData(path, headers);
            foreach (var item in _data.Skip(1))
            {
                if (!item.Contains(","))
                    throw new CensusAnalyserException(CensusExceptionType.IncorrectDelimiter);

                string[] column = item.Split(',');
                switch (headers)
                {
                    case "SrNo,State Name,TIN,StateCode":
                        _state.Add(column[0], new CensusDTO(
                            new StateCodeDataDAO(column[0],column[1],column[2], column[3])
                        ));
                        break;
                    case "State,Population,AreaInSqKm,DensityPerSqKm":
                        _state.Add(column[0], new CensusDTO(
                            new PopulationDataDAO(column[0], column[1], column[2], column[3])
                        ));
                        break;
                    default:
                        throw new CensusAnalyserException(CensusExceptionType.IncorrectData);
                }
            }
            return _state;
        }
    }
}
