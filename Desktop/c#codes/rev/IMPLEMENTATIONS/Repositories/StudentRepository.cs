using rev.INTERFACE.Repository;

namespace rev.IMPLEMENTATIONS.Repositories
{

    public class StudentRepository : IStudentRepository
    {
        private readonly RevContext _revContext;

        public StudentRepository(RevContext revContext)
        {
            _revContext = revContext;
        }
        public void AddStudent(Student student)
        {
            _revContext.Add(student);
            _revContext.SaveChanges();
        }
        public Student DeleteStudent(int id)
        {
            Student student = _revContext.Students.Single(x => x.Id == id);
            _revContext.Students.Remove(student);
            _revContext.SaveChanges();
            return student;
        }
        public Student GetStudentById(int id)
        {
            Student student = _revContext.Students.Single(x => x.Id == id);
            return student;
        }
    }
}