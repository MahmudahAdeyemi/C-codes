namespace Method
{
    class Animal
    {
        public string Name;
        public int NoOfLegs;
        public int NoOfEyes;

        public static int NoOfAnimals = 0;
        public Animal(string name, int noOfLegs, int noOfEyes)
        {
            Name = name;
            NoOfLegs = noOfLegs;
            NoOfEyes = noOfEyes;
        }

        public int GetNoOfAnimal()
        {
            return NoOfAnimals;
        }
        

        public void AddToNumberOfAnimal(int num)
        {
            NoOfAnimals+=num;
        }
    }
}