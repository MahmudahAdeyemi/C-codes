namespace Method
{


    class Animal
    {
        private string Name;
        private int NoOfLeg;
        private int Weight;

        public Animal(string name, int noOfLeg, int weight)
        {
            Name = name;
            NoOfLeg = noOfLeg;
            Weight = weight;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public int GetNoOfLeg()
        {
            return NoOfLeg;
        }
        public void SetNoOfLeg(int noOfLeg)
        {
            NoOfLeg = noOfLeg;
        }
        public int GetWeight()
        {
            return Weight;
        }
        public void SetWeight(int weight)
        {
            Weight = weight;
        }
    }

} 