using IndianCensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        CsvAdaptorFactory app;
        Dictionary<string, CensusDTO> stateRecords;

        [TestInitialize]
        public void SetUp()
        {
            app = new CsvAdaptorFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        /// <summary>TC 1.1
        /// Giving the correct path it should return the total count from the census</summary>
        [TestMethod]
        public void Test_GivenStateCensusCSVShouldReturnRecords()
        {
            // string path = @"/home/shuvam/Code/IndianCensusAnalyser/Docs/IndianPopulation.csv";
            string path = @"../Docs/IndianPopulation.csv";
            try
            {
                stateRecords = app.LoadCSVData(Country.INDIA, path, "State,Population,AreaInSqKm,DensityPerSqKm");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreEqual(29, stateRecords.Count);
            Console.WriteLine(stateRecords.Count);
        }
    }
}
