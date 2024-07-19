namespace Method
{
    class Program
    {


        static void Main(string[] args)
        {
            Dog dog1 = new Dog("dor", 4,58);
            Console.WriteLine(dog1.GetNoOfLeg());
            Dog dog2 = new Dog("bingo",8,6784);
            Console.WriteLine(dog2.GetWeight());
            Chicken chicken1 = new Chicken("broilers",2,43,6);
            Console.WriteLine(chicken1.GetName());
            Chicken chicken2 = new Chicken("layers", 4,56,12);
            Console.WriteLine(chicken2.GetNoOfLeg());
            // Person mahmudah = new Person("Mahmudah", 20, 1.6, "female", 20,"yoruba");
            // mahmudah.Speak();
            // //Console.WriteLine(mahmudah.GetGender());
            // Person toyyib = new Person("Toyyib", 600, 2.5, "male", 5.6,"hausa");
            // toyyib.Speak();
          
            // Animal dog = new Animal("dog", 4, 40);
            // // Console.WriteLine(dog.NoOfLeg);
            // Animal hen = new Animal("hen", 2, 10);
            // // Console.WriteLine(hen.NoOfLeg);


        }
    }
  
    
    }
