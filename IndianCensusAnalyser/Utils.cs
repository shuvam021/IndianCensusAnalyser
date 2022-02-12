using System;
using System.Collections.Generic;

namespace IndianCensusAnalyser
{
    /// <summary>Collection of all country</summary>
    public enum Country
    {
        INDIA,
        US
    }
    public enum CensusExceptionType
    {
        FileNotFound,
        InvalidFileType,
        IncorrectHeader,
        NoSuchCountry,
        IncorrectDelimiter,
        IncorrectData,
    }
    public class CensusAnalyserException : Exception
    {
        private readonly Dictionary<CensusExceptionType, string> _messages = new Dictionary<CensusExceptionType, string>(){
            {CensusExceptionType.NoSuchCountry, "No Such Country"},
            {CensusExceptionType.FileNotFound, "File Not Found"},
            {CensusExceptionType.InvalidFileType, "Invalid file type"},
            {CensusExceptionType.IncorrectHeader, "Incorrect header in Data"},
            {CensusExceptionType.IncorrectDelimiter, "File contains wrong delimiter"},
            {CensusExceptionType.IncorrectData, "Insufficient Data"},
        };

        private readonly CensusExceptionType _type;
        public override string Message => _messages[_type];
        public CensusAnalyserException(CensusExceptionType type)
        {
            _type = type;
        }
    }
}
