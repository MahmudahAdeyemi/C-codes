public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        List<Admin> GetAllAdmin();
        void UpdateAdminsFirstname(string firstname, string surname);
        void UpdateAdminsSurname(string firstname, string surname);
    }