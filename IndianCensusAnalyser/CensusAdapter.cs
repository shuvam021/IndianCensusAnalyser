using System;
using System.IO;

namespace IndianCensusAnalyser
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string path, string headers)
        {
            try
            {
                if (!File.Exists(path))
                    throw new CensusAnalyserException(CensusExceptionType.FileNotFound);
                if (Path.GetExtension(path) != ".csv")
                    throw new CensusAnalyserException(CensusExceptionType.InvalidFileType);
                string[] data = File.ReadAllLines(path);
                if (data[0] != headers)
                    throw new CensusAnalyserException(CensusExceptionType.IncorrectHeader);
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
