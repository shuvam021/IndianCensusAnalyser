using System;
using System.IO;

namespace IndianCensusAnalyser
{
    class Program
    {
        private static readonly string ProjectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath("."))));
        private static readonly string _populationDataDAOFile;
        private static string _stateCodeDataDaoFile;
        static Program()
        {
            _populationDataDAOFile = ProjectPath + @"/Docs/PopulationDataDAO.csv";
            _stateCodeDataDaoFile = ProjectPath + @"/Docs/StateCodeDataDAO.csv";
        }

        static void Main(string[] args)
        {
            try
            {
                var records = CsvAdaptorFactory.LoadCSVData(
                    Country.INDIA,
                    _populationDataDAOFile,
                    "State,Population,AreaInSqKm,DensityPerSqKm");
                foreach (var item in records)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n\n");
                // Console.WriteLine(e);
                Console.WriteLine("Something went \"Wrong\" Fix your code idiot...");
            }
        }
    }
}
