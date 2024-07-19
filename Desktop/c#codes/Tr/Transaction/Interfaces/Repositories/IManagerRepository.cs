using Transaction.Entities;

namespace Transaction.Interfaces.Repositories
{
    public interface IManagerRepository
    {
        void AddManager(Manager manager);
        Manager DeleteManager(int id);
        List<Manager> GetAllManager();
        Manager GetManagerById(int id);
        Manager UpdateManager( Manager manager);
        bool IfExit (Manager manager);
        void ChangePassword(Manager manager);
    }
}