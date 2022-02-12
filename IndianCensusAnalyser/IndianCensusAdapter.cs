using System.Collections.Generic;
using System.Linq;

namespace IndianCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] data;
        Dictionary<string, CensusDTO> state;
        public Dictionary<string, CensusDTO> LoadCensusData(string path, string headers)
        {
            data = GetCensusData(path, headers);
            state = new Dictionary<string, CensusDTO>();
            foreach (string item in data.Skip(1))
            {
                if (!item.Contains(","))
                {
                    var excp = new CensusAnalyserException();
                    throw new CensusAnalyserException(CensusExceptionType.IncorrectDelimiter);
                }

                string[] column = item.Split(',');

                if (path.Contains("StateCodeDataDAO.csv"))
                    state.Add(column[0], new CensusDTO(new StateCodeDataDAO(column[0], column[1], column[2], column[3])));
                if (path.Contains("PopulationDataDAO.csv"))
                    state.Add(column[0], new CensusDTO(new PopulationDataDAO(column[0], column[1], column[2], column[3])));
            }
            return state;
        }
    }
}
