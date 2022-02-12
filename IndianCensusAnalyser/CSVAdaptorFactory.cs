using System.Collections.Generic;

namespace IndianCensusAnalyser
{
    public class CsvAdaptorFactory
    {
        public static Dictionary<string, CensusDTO> LoadCSVData(Country country, string path, string headers)
        {
            switch (country)
            {
                case (Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(path, headers);
                default:
                    throw new CensusAnalyserException(CensusExceptionType.NoSuchCountry);
            }
        }
    }
}
