using rev.ENTITIES;

namespace rev.INTERFACE.Repository
{
    public interface IGradeRepository
    {
        void AddGrade(Grade grade);
        Grade DeleteGrade(int id);
        Grade GetGradeById(int id);
    }   
    
}