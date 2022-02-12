using System;

namespace IndianCensusAnalyser
{
    public class PopulationDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public PopulationDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt64(population);
            this.area = Convert.ToInt64(area);
            this.density = Convert.ToInt64(density);
        }

        public override string ToString()
        {
            return $"PopulationDataDAO: {this.state}\t{this.population}\t{this.area}\t{this.density}";
        }
    }
}
