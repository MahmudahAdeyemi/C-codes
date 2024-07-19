namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal>animals = new List<Animal>()
            {
                new Animal("Dog",50,"red","luftumanan"),
                new Animal("Hen",6,"white","toyyib"),
                new Animal("Monkey",50 ,"brown","Farhat"),
                new Animal("Lion",90,"brown","Mahmudah"),
                new Animal("Buffallow",98,"brown","mazeedah")
            };
            AnimalCheck("ANIMAL WITH BROWN COLOUR ARE: ",animals,CheckAnimals); 
        }
        static bool CheckAnimals(Animal animal)
        {
            return animal.Colour == "brown";
        }
        static void AnimalCheck(string title,List<Animal>animals,Func<Animal,bool>checkanimal)
        {
            foreach (var item in animals)
            {
                if (checkanimal(item))
                {
                    
                }
            }
        }

    }
}
