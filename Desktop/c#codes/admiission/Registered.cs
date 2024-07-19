using System.Collections.Generic;
namespace Method
{
    public  class Registered
    {
        List<Registered> mylist = new List<Registered>();
        public Registered(string firstName, string lastName, string middleName, string course, string nameOfUniversity)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Course = course;
            NameOfUniversity = nameOfUniversity;
            IsAdmitted = false;
            RegistrationNumber = GenerateRegistrationNumber();
        }



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Course { get; set; }
        public string NameOfUniversity { get; set; }
        public bool IsAdmitted { get; set; }
        public string RegistrationNumber {get;set;}



        string GenerateRegistrationNumber()
        {
            string g ="";
            string[] mystring = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random r = new Random();
            int k = r.Next(1, 26);
            int j = r.Next(0, 9);

            for (int i = 0; i <= 6; i++)
            {
                if (i < 2)
                {
                    string h = mystring[k];
                    g += h;
                }
                else
                {
                    g += j;
                }
            }
           return g;
        }



        public static void Register(List<Registered>mylist)
        {
            Console.Write("Enter your firstname");
            string firstName = Console.ReadLine();
            Console.Write("Enter your surname");
            string surnamme = Console.ReadLine();
            Console.Write("Enter your fmiddletname");
            string middleName = Console.ReadLine();
            Console.Write("Enter your course");
            string course = Console.ReadLine();
            Console.Write("Enter your university");
            string university = Console.ReadLine();

            Registered student = new Registered(firstName,surnamme,middleName,course,university);
            mylist.Add(student);
        }

        public static void isRegister(List<Registered>mylist)
        {
            Console.Write("Enter your firstname");
            string firstName = Console.ReadLine(); 
            foreach (var item in mylist)
            {
                if(item.FirstName.Contains(firstName))
                {
                     Console.Write("Enter your surname");
                    string surnamme = Console.ReadLine();
                    foreach(var tem in mylist)
                    {
                        if(tem.LastName.Contains(surnamme))
                        {
                            Console.Write("Enter your middlename");
                            string middleName = Console.ReadLine();
                            foreach(var em in mylist)
                            {
                                if(em.MiddleName.Contains(middleName))
                                {
                                    Console.Write("Enter your course: ");
                                    string course = Console.ReadLine();
                                    foreach (var m in mylist)
                                    {
                                        if(m.Course.Contains(course))
                                        {
                                            Console.Write("Enter yoyr university ");
                                            string university = Console.ReadLine();
                                            foreach(var n1 in mylist)
                                            {
                                                if(n1.NameOfUniversity.Contains(university))
                                                {
                                                    Console.WriteLine("you have been registered");
                                                    n1.IsAdmitted = true;
                                                    Console.WriteLine(n1.RegistrationNumber);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}