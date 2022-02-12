using System;
using System.Collections.Generic;
using System.IO;

namespace IndianCensusAnalyser
{
    class Program
    {
        private const string populationDataDAOFile = @"/home/shuvam/Code/IndianCensusAnalyser/IndianCensusAnalyser/Docs/PopulationDataDAO.csv";
        private const string stateCodeDataDAOFile = @"/home/shuvam/Code/IndianCensusAnalyser/IndianCensusAnalyser/Docs/StateCodeDataDAO.csv";

        static void Main(string[] args)
        {
            // try
            // {
            //     var app = new CsvAdaptorFactory();
            //     var stateRecords = app.LoadCSVData(Country.INDIA, populationDataDAOFile, "State,Population,AreaInSqKm,DensityPerSqKm");
            //     foreach (var item in stateRecords)
            //     {
            //         Console.WriteLine($"{item.Key}: {item.Value}");
            //     }
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
            try
            {
                var x = new IndianCensusAdapter().LoadCensusData(populationDataDAOFile, "State,Population,AreaInSqKm,DensityPerSqKm");
                Console.WriteLine(x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
