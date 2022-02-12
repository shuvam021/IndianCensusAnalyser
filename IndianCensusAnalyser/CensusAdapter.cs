using System.IO;

using System.Net;

namespace IndianCensusAnalyser
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string path, string headers)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new CensusAnalyserException("File Not Found", CensusExceptionType.FileNotFound);
                }
                if (Path.GetExtension(path) != ".csv")
                {
                    throw new CensusAnalyserException("Invalid file type", CensusExceptionType.InvalidFileType);
                }

                string[] data = File.ReadAllLines(path);
                if (data[0] != headers)
                {
                    throw new CensusAnalyserException("Incorrect header in Data", CensusExceptionType.IncorrectHeader);
                }
                return data;
            }
            catch (CensusAnalyserException e)
            {
                throw e;
            }
        }
    }
}
