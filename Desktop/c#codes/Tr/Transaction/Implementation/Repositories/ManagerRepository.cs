using Transaction.Entities;
using Transaction.Interfaces.Repositories;

namespace Transaction.Implementation.Repositories
{
    

    public class ManagerRepository : IManagerRepository
    {
        private readonly TransactionContext _transactionContext;

        public ManagerRepository(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddManager(Manager manager)
        {
            _transactionContext.Add(manager);
            _transactionContext.SaveChanges();
        }
        public Manager DeleteManager(int id)
        {
            Manager manager = _transactionContext.Managers.Single(x => x.Id == id);
            _transactionContext.Managers.Remove(manager);
            _transactionContext.SaveChanges();
            return manager;
        }
        public Manager GetManagerById(int id)
        {
            Manager manager = _transactionContext.Managers.Single(x => x.Id == id);
            return manager;
        }
        public Manager UpdateManager( Manager manager)
        {
            _transactionContext.Managers.Update(manager);
            _transactionContext.SaveChanges();
            return manager;
        }
        public List<Manager> GetAllManager()
        {
            var managers = _transactionContext.Managers.ToList();
            return managers;
        }
        public bool IfExit (Manager manager)
        {
            var c = _transactionContext.Managers.Contains(manager);
            if (c == true)
            {
                return false;
            }
            return true;
        }
        public void ChangePassword(Manager manager)
        {
            _transactionContext.Update(manager);
            _transactionContext.SaveChanges();
        }
    }
}