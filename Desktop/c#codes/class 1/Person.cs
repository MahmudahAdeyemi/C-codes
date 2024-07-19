namespace Method
{
    class Person
    {
        private string Name;
        private int Age;
        private double Height;
        private string Gender;
        private double Weight;
        private string Language;
        public Person(string name, int age, double height, string gender, double weight, string language)
        {
            Name = name;
            Age = age;
            Height = height;
            Gender = gender;
            Weight = weight;
            Language = language;
        }

        public string GetGender()
        {
            return Gender;
        }

        public void SetGender(string gender)
        {
            Gender = gender;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public int GetAge()
        {
            return Age;
        }
        public void SetAge(int age)
        {
            Age = age;
        }
        public double GetHeight()
        {
            return Height;
        }
        public void SetHeight(double height)
        {
            Height = height;
        }
        public double GetWeight()
        {
            return Weight;
        }
        public void SetWeight(double weight)
        {
            Weight = weight;
        }
        public void Speak()
        {
            Console.WriteLine("Speaking. " + Language);
        }

    }


}