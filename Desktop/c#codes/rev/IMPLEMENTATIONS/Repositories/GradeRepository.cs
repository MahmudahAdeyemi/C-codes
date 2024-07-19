using rev.ENTITIES;
using rev.INTERFACE.Repository;

namespace rev.IMPLEMENTATIONS.Repositories
{
    

    public class GradeRepository : IGradeRepository
    {
        private readonly RevContext _revContext;

        public GradeRepository(RevContext revContext)
        {
            _revContext = revContext;
        }
        public void AddGrade(Grade grade)
        {
            _revContext.Add(grade);
            _revContext.SaveChanges();
        }
        public Grade DeleteGrade(int id)
        {
            Grade grade = _revContext.Grades.Single(x => x.Id == id);
            _revContext.Grades.Remove(grade);
            _revContext.SaveChanges();
            return grade;
        }
        public Grade GetGradeById(int id)
        {
            Grade grade = _revContext.Grades.Single(x => x.Id == id);
            return grade;
        }
    }
}