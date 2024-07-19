namespace Method
{
    public class Menu
    {
         List<Student>Addstudent = new List<Student>();
        
        public void My_menu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nEnter 1 to register student\nEnter 2 for printing student \n Enter 3 for gender checking\n");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    Student.Studentadding(Addstudent);
                    break;
                    case 2:
                    Student.Studentpinting(Addstudent);
                    break;
                    case 3:
                    Student.StudentGender(Addstudent);
                    break;
                }

            }
        }
    }
            
}