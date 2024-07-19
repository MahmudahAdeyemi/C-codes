public interface ICourseRepository
    {
        void AddCourse(Course course);
        void DeleteCourse(int id);
        List<Course> GetAllCourses();
        Course GetCourseById();
        List<Course> GetCoursesbyDepartmentId(int id);
        void UpdateCourseName(string name);
    }
