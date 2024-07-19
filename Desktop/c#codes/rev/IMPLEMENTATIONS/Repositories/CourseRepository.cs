using rev.ENTITIES;
using rev.INTERFACE.Repository;

namespace rev.IMPLEMENTATIONS.Repositories
{
    
    public class CourseRepository : ICourseRepository
    {
        private readonly RevContext _revContext;

        public CourseRepository(RevContext revContext)
        {
            _revContext = revContext;
        }
        public void AddCourse(Course course)
        {
            _revContext.Add(course);
            _revContext.SaveChanges();
        }
        public Course DeleteCourse(int id)
        {
            Course course = _revContext.Courses.Single(x => x.Id == id);
            _revContext.Courses.Remove(course);
            _revContext.SaveChanges();
            return course;
        }
        public Course GetCourseById(int id)
        {
            Course course = _revContext.Courses.Single(x => x.Id == id);
            return course;
        }
        public List<Course> GetAllCourse()
        {
            var course = _revContext.Courses.ToList();
            return course;
        }
        
        

    }
}