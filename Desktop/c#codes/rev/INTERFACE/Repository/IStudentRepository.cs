namespace rev.INTERFACE.Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student DeleteStudent(int id);
        Student GetStudentById(int id);
    }
}