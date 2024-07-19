public interface IEmployeeRepository
{
    bool AddEmployee(Employee employee);
     bool UpdateEmployeeDepartment(int id,string name);
     bool UpdateEmployeePosition(int id,string name);
    bool UpdateEmployeeEmail(string email,string name);
    bool DeleteEmployee(int id);
    Employee GetEmployeeById(int id);
     List<Employee> GetAllEmployees();
     void UpdatePassword(string email,string password,string newpassword);
}