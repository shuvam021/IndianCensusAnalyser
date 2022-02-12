namespace IndianCensusAnalyser
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public string state;
        public long population;
        public long area;
        public long density;
        public double totalArea;
        public double waterArea;
        public double landArea;

        public CensusDTO(StateCodeDataDAO data)
        {
            this.serialNumber = data.serialNumber;
            this.stateName = data.stateName;
            this.tin = data.tin;
            this.stateCode = data.stateCode;
        }
        public CensusDTO(PopulationDataDAO data)
        {
            this.state = data.state;
            this.population = data.population;
            this.area = data.area;
            this.density = data.density;
        }
        public override string ToString()
        {
            return $"CensusDTO: {this.serialNumber}\t{this.stateName}\t{this.tin}\t{this.stateCode}\t" +
                   $"{this.state}\t{this.population}\t{this.area}\t{this.density}";
        }
    }
}
