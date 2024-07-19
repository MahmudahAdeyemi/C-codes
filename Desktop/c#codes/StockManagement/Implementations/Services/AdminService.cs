using StockManagement.Implementations.Repositories;
using StockManagement.Interfaces.Repositories;
using StockManagement.ReponseModel;
using StockManagement.RequestModels;

namespace StockManagement.Implementations.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public BaseResponse ChangePassword(int id, ChangePasswordModel changePasswordModel)
        {
            var admin = _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            if (PasswordUtil.HashPassword(changePasswordModel.PreviousPassword) != admin.Password)
            {
                return new BaseResponse
                {
                    Message = "Incorrect password entered",
                    Status = false
                };
            }
            if (changePasswordModel.NewPassword != changePasswordModel.ConfirmNewPassword)
            {
                return new BaseResponse
                {
                    Message = "New password is different from confirm new password",
                    Status = false
                };
            }
            admin.Password = PasswordUtil.HashPassword(changePasswordModel.PreviousPassword);
            _adminRepository.ChangePassword(admin);
            return new BaseResponse
            {
                Message = "Sucessfully changed",
                Status = true
            };
        }
    }
}