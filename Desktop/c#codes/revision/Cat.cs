namespace Method
{
    public class Animal
    {
        public Animal(string name, int noOfLeg, double weight, Dog[] dogs)
        {
            Name = name;
            NoOfLeg = noOfLeg;
            Weight = weight;
            Dogs = dogs;
        }

        
        public string Name{get; set;}
        public int NoOfLeg{get; set;}
        public double Weight{get; set;}
        private Dog[] Dogs;
    }
}