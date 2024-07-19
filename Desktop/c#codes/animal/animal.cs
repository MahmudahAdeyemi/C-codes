namespace Method
{
    class Animal
    {
        public string Name{get;set;}
        public int Weight{get;set;}
        public string Colour{get;set;}
        public string Owner{get;set;}

        public Animal(string name,int weight,string colour,string owner)
        {
            Name = name;
            Weight = weight;
            Colour = colour;
            Owner = owner;
        }
    }
}