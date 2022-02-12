using System.Collections.Generic;

namespace IndianCensusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary></summary>
        /// <param name="country"></param>
        /// <param name="path">Path to csv file</param>
        /// <param name="headers">headers of contents</param>
        /// <returns>Dictionary<string, CensusDTO></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(
            Country country, string path, string headers
        )
        {
            return new CsvAdaptorFactory().LoadCSVData(country, path, headers);
        }
    }
}