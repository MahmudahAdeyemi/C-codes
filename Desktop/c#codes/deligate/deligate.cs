namespace Deligate_Class
{
    class Deligate
    {
        List<Student> mylist = new List<Student>()
            {
                new Student("Luftumanan","AL-ghazal",76,Gender.male),
                new Student("Baseerah","Lgali",23,Gender.female),
                new Student("Farhaan","Balogun",12,Gender.female),
                new Student("Toyyib", "Adebesin", 79, Gender.male),
                new Student("Mahmudah", "Adeyemi", 5, Gender.female)
            };
            public static  bool Age(Student x)
           {
               return x.Age > 18;
           }
           public static bool NewGender (Student y)
           {
               return y.Gender.Equals(Gender.female);
           }

        
    }
}