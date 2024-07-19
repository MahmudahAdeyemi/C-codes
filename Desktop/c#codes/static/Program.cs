namespace Method
{
    class Program
    {


        static void Main(string[] args)
        {
            Animal animal1 = new Animal ("Dog",4,2);
            Animal animal2 = new Animal ("Hen",2,2);

            
            animal1.AddToNumberOfAnimal(10);

            animal2.AddToNumberOfAnimal(20);

            Animal.NoOfAnimals  = 5;
            Console.WriteLine(animal2.GetNoOfAnimal());
        }
    }
}