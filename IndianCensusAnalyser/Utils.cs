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
        IncorrectDelimiter
    }
    public class CensusAnalyserException : Exception
    {
        public string message;
        public CensusExceptionType exception;
        public Dictionary<CensusExceptionType, string> customMessages = new Dictionary<CensusExceptionType, string>(){
            {CensusExceptionType.NoSuchCountry, "No Such Country"},
            {CensusExceptionType.FileNotFound, "File Not Found"},
            {CensusExceptionType.InvalidFileType, "Invalid file type"},
            {CensusExceptionType.IncorrectHeader, "Incorrect header in Data"},
            {CensusExceptionType.IncorrectDelimiter, "File contains wrong delimiter"},
        };
        public CensusAnalyserException(){}
        public CensusAnalyserException(string message, CensusExceptionType exception): base(message){}
        public CensusAnalyserException(CensusExceptionType exception)
        {
            this.exception = exception;
            this.message = this.customMessages[this.exception];
        }

        // public CensusAnalyserException(string message, CensusExceptionType exception) : base(message)
        // {
        //     this.exception = exception;
        // }

    }
}
