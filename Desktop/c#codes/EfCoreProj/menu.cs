namespace EfCoreProj
{
    public class menu
    {
        
        public void My_menu()
        {
            EfCoreProjectContext _efCoreProjectContext  = new EfCoreProjectContext();
            DepartmentUtility departmentUtility = new DepartmentUtility(_efCoreProjectContext);
            CourseUtility courseUtility = new CourseUtility(_efCoreProjectContext);
            StudentUtility studentUtility = new StudentUtility(_efCoreProjectContext);
            AdminUtility adminUtility = new AdminUtility(_efCoreProjectContext);
            bool check = true;
            while (check)
            {
                bool c =  adminUtility.IfAdmin();
                if (c == true)
                {
                Console.WriteLine("\nEnter 1 to add department \nEnter 2 to get all department\nEnter 3 to delete department\nEnter 4 to get department by id\nEnter 5 to update department\nEnter 6 to add course\nEnter 7 to get course by id\nEnter 8 to update course\nEnter 9 to get all course\nEnter 10 to delete course \nEnter 11 to get courses by department id\nEnter 12 to add student\nEnter 13 to update student's firstname\nEnter 14 to update student's surname \nEnter 15 to delete student \nEnter 16 to get student by departmentid\nEnter 17 to get student by id\nEnter 18 to get all students\nEnter 19 to add admin \nEnter 20 to update admin's firstname\nEnter 21 to update admin's surname\nEnter 22 to get admins");
                int option1 = int.Parse(Console.ReadLine());
                switch (option1)
                {
                    case 1:
                    departmentUtility.AddDepartment();
                    break;
                    case 2:
                    departmentUtility.GetAllDepartment();
                    break;
                    case 3:
                    departmentUtility.DeleteDepartment();
                    break;
                    case 4:
                    departmentUtility.GetDepartmentById();
                    break;
                    case 5:
                    departmentUtility.UpdateDepartment();
                    break;
                    case 6:
                    courseUtility.AddCourse();
                    break;
                    case 7:
                    courseUtility.GetCourseById();
                    break;
                    case 8:
                    courseUtility.UpdateCourseName();
                    break;
                    case 9:
                    courseUtility.GetAllCourses();
                    break;
                    case 10:
                    courseUtility.DeleteCourse();
                    break;
                    case 11:
                    courseUtility.GetCoursesbyDepartmentId();
                    break;
                    case 12:
                    studentUtility.AddStudent();
                    break;
                    case 13:
                    studentUtility.UpdateStudentsFirstname();
                    break;
                    case 14:
                    studentUtility.UpdateStudentsSurname();
                    break;
                    case 15:
                    studentUtility.DeleteStudent();
                    break;
                    case 16:
                    studentUtility.GetStudentByDepartmentId();
                    break;
                    case 17:
                    studentUtility.GetStudentById();
                    break;
                    case 18:
                    studentUtility.GetAllStudents();
                    break;
                    case 19:
                    adminUtility.AddAdmin();
                    break;
                    case 20:
                    adminUtility.UpdateAdminsFirstname();
                    break;
                    case 21:
                    adminUtility.UpdateAdminsSurname();
                    break;
                    case 22:
                    adminUtility.GetAllAdmin();
                    break;
                }

 
                
                }
                Console.WriteLine("Enter 1 to add student\nEnter 2 to update student's firstname\nEnter 3 to update student's surname \nEnter 4 to delete student \nEnter 5 to get student by departmentid\nEnter 6 to get student by id\nEnter 7 to get all students.");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    studentUtility.AddStudent();
                    break;
                    case 2:
                    studentUtility.UpdateStudentsFirstname();
                    break;
                    case 3:
                    studentUtility.UpdateStudentsSurname();
                    break;
                    case 4:
                    studentUtility.DeleteStudent();
                    break;
                    case 5:
                    studentUtility.GetStudentByDepartmentId();
                    break;
                    case 6:
                    studentUtility.GetStudentById();
                    break;
                    case 7:
                    studentUtility.GetAllStudents();
                    break;
                }

            }
        }
    }
}