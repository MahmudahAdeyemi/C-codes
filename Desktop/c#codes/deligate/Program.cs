namespace Deligate_Class
{
    class Program
    {
        public Program()
        {
        }
 
        // public delegate bool FilterDelegate(Student student);

        static void Main(string[] args)
        {
            List<Student> mylist = new List<Student>()
            {
                new Student("Luftumanan","AL-ghazal",76,Gender.male),
                new Student("Baseerah","Lgali",23,Gender.female),
                new Student("Farhaan","Balogun",12,Gender.female)
            };
            Student student1 = new Student("Mahmudah", "Adeyemi", 5, Gender.female);
            mylist.Add(student1);
            mylist.Add(new Student("Toyyib", "Adebesin", 79, Gender.male));

            mylist.RemoveAll(s => s.FirstName == "Toyyib");

            PrintStudents("All students", mylist, s => s.Age>18);




        //     FilterDelegate myfilter = s =>
        //    {
        //         // int count =0;
        //         // foreach(var item in s.FirstName)
        //         // {
        //         //     if (item == 'a' || item == 'e' || item == 'i' || item =='o'|| item =='u')
        //         //     {
        //         //         count ++;
        //         //     }
        //         // }
        //         // return count > 3;
        //         return s.Age > 18 && s.Gender.Equals(Gender.male);
        //    };



            // PrintStudents("MALE STUDENT ARE: ", mylist, myfilter);

        }
        static void PrintStudents(string title, List<Student> students, Func<Student, bool> deligate)
        {
            Console.WriteLine(title);
            foreach (var student in students)
            {
                if (deligate(student)) 
                {
                    Console.WriteLine(student.FirstName);
                }

            }
        }

        static int Numbers(int num1, int num2)
        {
            return num1 + num2;
        }

        static int AddNums(int a, int b) => a + b;


        static bool FilterAge(Student student) => student.Age < 18;


        static bool FilterGender(Student student)
        {
            return student.Gender.Equals(Gender.female);
        }

        static bool FilterCheck(Student student)
        {
            return student.FirstName.Contains('a');
        }
        // static void PrintCheck(List<Student> students)
        // {
        //     foreach (var student in students)
        //     {
        //         if (FilterCheck(student))
        //         {
        //             Console.WriteLine(student.FirstName);
        //         }
        //     }
        // }

        // static void PrintGender(List<Student> students)
        // {
        //     foreach (var student in students)
        //     {
        //         if (FilterGender(student))
        //         {
        //             Console.WriteLine(student.FirstName);
        //         }
        //     }
        // }

        // static void PrintAge(List<Student> students)
        // {
        //     foreach (var student in students)
        //     {
        //         if (FilterAge(student))
        //         {
        //             Console.WriteLine(student.FirstName);
        //         }
        //     }
        // }
    }

}