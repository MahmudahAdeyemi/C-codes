using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;
using e_commerce.Interfaces.Services;
using e_commerce.RequestModel;
using e_commerce.ResponseModel;

namespace e_commerce.Implementations.Services
{
    
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository AdminRepository)
        {
            _adminRepository = AdminRepository;
        }
        public BaseResponse AddManager(AdminRequestModel AdminRequestModel)
        {
            Admin admin = new Admin
            {
                FirstName = AdminRequestModel.FirstName,
                LastName = AdminRequestModel.LastName,
                Email = AdminRequestModel.Email,
                Password = AdminRequestModel.Password
            };

            return new BaseResponse
            {
                Message = "Sucessfully created",
                Status = true
            };
        }
        public BaseResponse UpdateManager(int id, AdminRequestModel adminRequestModel)
        {
            var admin = _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Status = false
                };
            }
            admin.FirstName = adminRequestModel.FirstName;
            admin.LastName = adminRequestModel.LastName;
            admin.Email = adminRequestModel.Email;
            _adminRepository.UpdateAdmin(admin);

            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }
    }
}