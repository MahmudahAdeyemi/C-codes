namespace Method
{
    class Chicken : Animal
    {
        private int NoOfEgg;
        public Chicken(string name, int noOfLeg, int weight, int noOfEgg) : base(name, noOfLeg, weight)
        {
            NoOfEgg = noOfEgg;
        }
        
        public int GetNoOfEgg()
        {
            return NoOfEgg;
        }
        public void SetNoOfEgg(int noOfEgg)
        {
            NoOfEgg = noOfEgg;
        }
    }
}
