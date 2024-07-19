using rev.ENTITIES;

namespace rev.INTERFACE.Repository
{
   public interface ICourseRepository
    {
        void AddCourse(Course course);
        Course DeleteCourse(int id);
        Course GetCourseById(int id);
    }

}