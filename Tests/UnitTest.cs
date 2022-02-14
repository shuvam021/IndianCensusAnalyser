using IndianCensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        private CsvAdaptorFactory _app;
        private static readonly string ProjectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath(".")))));
        private string _populationHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

        [TestInitialize]
        public void SetUp()
        {
            _app = new CsvAdaptorFactory();
        }

        /// <summary>TC 1.1
        /// Giving the correct path it should return the total count from the census</summary>
        [TestMethod]
        public void Test_GivenStateCensusCSVShouldReturnRecords()
        {
            string file = ProjectPath + @"/IndianCensusAnalyser/Docs/PopulationDataDAO.csv";
            var records = CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA, 
                    file,
                    _populationHeader);
            Assert.IsTrue(File.Exists(file));
            Assert.AreEqual(29, records.Count);
        }
        
        /// <summary>TC 1.2
        /// Giving the Incorrect path it should return the File not found Exception</summary>
        [TestMethod]
        public void Test_GivenIncorectPathShould_ReturnException()
        {
            string file = ProjectPath + @"/IndianCensusAnalyser/Docs/PopulationData.csv";
            var records = Assert.ThrowsException<CensusAnalyserException>(()=>CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA, 
                    file,
                    _populationHeader));
            
            Assert.IsFalse(File.Exists(file));
            Assert.AreEqual(CensusExceptionType.FileNotFound, records.type);
        }
        
        /// <summary>TC 1.3
        /// Giving the Incorrect File Type it should return the "IncorrectFileType" Exception</summary>
        [TestMethod]
        public void Test_GivenWrongFileType_ReturnsException()
        {
            string file = ProjectPath + @"/IndianCensusAnalyser/Docs/IndiaStateCode.txt";
            
            var records = Assert.ThrowsException<CensusAnalyserException>(()=>CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA, 
                    file,
                    _populationHeader
                    ));
            
            Assert.IsTrue(File.Exists(file));
            Assert.AreEqual(CensusExceptionType.InvalidFileType, records.type);
        }
        
        /// <summary>TC 1.4
        /// Giving the File contains delimiter other than comma should return the "Incorrect Delimiter" Exception</summary>
        [TestMethod]
        public void Test_GivenWrongDelimiter_ReturnsException()
        {
            string populationDataDaoFile = ProjectPath + @"/IndianCensusAnalyser/Docs/Test.csv";
            var records = Assert.ThrowsException<CensusAnalyserException>(()=>CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA, 
                    populationDataDaoFile,
                    _populationHeader
                    ));
            
            Assert.IsTrue(File.Exists(populationDataDaoFile));
            Assert.AreEqual(CensusExceptionType.IncorrectDelimiter, records.type);
        }
        
        /// <summary>TC 1.5
        /// Giving the File contains delimiter other than comma should return the "Incorrect Delimiter" Exception</summary>
        [TestMethod]
        public void Test_GivenHeader_ReturnsException()
        {
            string populationDataDaoFile = ProjectPath + @"/IndianCensusAnalyser/Docs/Test.csv";
            _populationHeader += ",some_new_column";
            var records = Assert.ThrowsException<CensusAnalyserException>(()=>CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA, 
                    populationDataDaoFile,
                    _populationHeader
                    ));
            
            Assert.IsTrue(File.Exists(populationDataDaoFile));
            Assert.AreEqual(CensusExceptionType.IncorrectHeader, records.type);
        }
    }
}
 