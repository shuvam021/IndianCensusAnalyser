using System;

namespace IndianCensusAnalyser
{
    class Program
    {
        private const string populationDataDAOFile = @"/home/shuvam/Code/IndianCensusAnalyser/IndianCensusAnalyser/Docs/PopulationDataDAO.csv";
        // private const string stateCodeDataDAOFile = @"/home/shuvam/Code/IndianCensusAnalyser/IndianCensusAnalyser/Docs/StateCodeDataDAO.csv";

        static void Main(string[] args)
        {
            try
            {
                var records = CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA,
                    populationDataDAOFile,
                    "State,Population,AreaInSqKm,DensityPerSqKm");
                foreach (var item in records)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\n");
                Console.WriteLine(e);
                Console.WriteLine("Something went \"Wrong\" Fix your code idiot...");
            }
        }
    }
}
