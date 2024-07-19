    public class CourseRepository : ICourseRepository
    {
        EfCoreProjectContext _efCoreProjectContext;
        public CourseRepository(EfCoreProjectContext efCoreProjectContext1)
        {
            _efCoreProjectContext = efCoreProjectContext1;
        }

        public void AddCourse(Course course)
        {
            DepartmentRepostory departmentRepostory = new DepartmentRepostory(_efCoreProjectContext);
            var r = departmentRepostory.GetAllDepartment();
            foreach (var item in r)
            {
                Console.WriteLine($"{item.Id}       {item.Name}");
            }
            _efCoreProjectContext.Courses.Add(course);
            Console.Write("Enter the number of departments you want the course to have: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter the id of department" + i);
                int departmentId = int.Parse(Console.ReadLine());
                DepartmentCourse departmentCourse = new DepartmentCourse(departmentId, course.Id);
                _efCoreProjectContext.DepartmentCourses.Add(departmentCourse);
            }
            _efCoreProjectContext.SaveChanges();
            Console.WriteLine("Operation sucessful.");
        }
        public Course GetCourseById()
        {
            Console.Write("Enter the id: ");
            int id = int.Parse(Console.ReadLine());
            Course course = _efCoreProjectContext.Courses.SingleOrDefault(x => x.Id == id);
            return course;
        }
        public List<Course> GetAllCourses()
        {
            List<Course> courses = _efCoreProjectContext.Courses.ToList();
            return courses;
        }
        public void UpdateCourseName(string name)
        {
            Course course = _efCoreProjectContext.Courses.SingleOrDefault(x => x.Name == name);
            Console.Write("Enter the new name: ");
            string newname = Console.ReadLine();
            course.Name = newname;
            _efCoreProjectContext.Courses.Update(course);
            _efCoreProjectContext.SaveChanges();
        }
        public void DeleteCourse(int id)
        {
            CourseUtility courseUtility = new CourseUtility(_efCoreProjectContext);
            courseUtility.GetAllCourses();
            Course course = _efCoreProjectContext.Courses.SingleOrDefault(x => x.Id == id);
            _efCoreProjectContext.Courses.Remove(course);
            _efCoreProjectContext.SaveChanges();
        }
        public List<Course> GetCoursesbyDepartmentId(int id)
        {
            List<Course> course = _efCoreProjectContext.DepartmentCourses.Where(x => x.DepartmentId == id).Select(x => new Course(
                x.Course.Name,
                x.Course.Description
            )).ToList();
            return course;
        }

    }
