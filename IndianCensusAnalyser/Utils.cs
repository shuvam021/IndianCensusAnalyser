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
        public Dictionary<CensusExceptionType, string> msgs = new Dictionary<CensusExceptionType, string>(){
            {CensusExceptionType.NoSuchCountry, "No Such Country"},
            {CensusExceptionType.FileNotFound, "File Not Found"},
            {CensusExceptionType.InvalidFileType, "Invalid file type"},
            {CensusExceptionType.IncorrectHeader, "Incorrect header in Data"},
            {CensusExceptionType.IncorrectDelimiter, "File contains wrong delimiter"},
            {CensusExceptionType.IncorrectData, "Insufficient Data"},
        };

        public readonly CensusExceptionType type;
        public override string Message => msgs[type];
        public CensusAnalyserException(CensusExceptionType type)
        {
            this.type = type;
        }
    }
}
