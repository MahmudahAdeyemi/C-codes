using Transaction.DTO;
using Transaction.Entities;
using Transaction.Implementation.Repositories;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public BaseResponse AddManager(ManagerRequestModel managerRequestModel)
        {
            Manager manager = new Manager
            {
                FirstName = managerRequestModel.FirstName,
                LastName = managerRequestModel.LastName,
                Email = managerRequestModel.Email,
                Password = managerRequestModel.Password
            };
            bool c = _managerRepository.IfExit(manager);
            if (c == true)
            {
                _managerRepository.AddManager(manager);
                return new BaseResponse
                {
                    Message = "Sucessfully added",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Already exits",
                Status = false
            };
        }
        public BaseResponse DeleteManager(int id)
        {
            var c = _managerRepository.DeleteManager(id);
            if (c == null)
            {
                return new BaseResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }
        public BaseResponse UpdateManager(int id, UpdateManagerRequestModel managerRequestModel)
        {
            var manager = _managerRepository.GetManagerById(id);
            if (manager == null)
            {
                return new BaseResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            manager.FirstName = managerRequestModel.FirstName;
            manager.LastName = managerRequestModel.LastName;
            manager.Email = managerRequestModel.Email;
            _managerRepository.UpdateManager(manager);

            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }   
        public BaseResponse ChangePassword(int id, ChangePasswordRequestModel changePasswordRequestModel)
        {
            var manager = _managerRepository.GetManagerById(id);
            if (manager == null)
            {
                return new BaseResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            if (changePasswordRequestModel.PreviousPassword != manager.Password)
            {
                return new BaseResponse
                {
                    Message = "Incorrect password entered",
                    Status = false
                };
            }
            if (changePasswordRequestModel.NewPassword != changePasswordRequestModel.ConfirmNewPassword)
            {
                return new BaseResponse
                {
                    Message = "New password is different from confirm new password",
                    Status = false
                };
            }
            manager.Password = changePasswordRequestModel.ConfirmNewPassword;
            _managerRepository.ChangePassword(manager);
            return new BaseResponse
            {
                Message = "Sucessfully changed",
                Status = true
            };
        }
        public ManagerResponse GetManagerById(int id)
        {
            var manager = _managerRepository.GetManagerById(id);
            if (manager == null)
            {
                return new ManagerResponse
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            return new ManagerResponse
            {
                Data = new ManagerDTO
                {
                    Id = manager.Id,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    Email = manager.Email
                },
                Message = "Sucessfully done.",
                Status = false
            };
        }
        public ManagersResponse GetAllManagerResponse()
        {
            

            var manager = _managerRepository.GetAllManager();
            if(manager == null)
            {
                return new ManagersResponse
                {
                    Status = false,
                    Message = "No Sales Representative retrieved"

                };
            }

            var managerReturned = manager.Select(sr => new ManagerDTO
                {
                    Id = sr.Id,
                    FirstName = sr.FirstName,
                    LastName = sr.LastName,
                    Email = sr.Email
                }).ToList();

            return new ManagersResponse
            {
                Data = managerReturned,
                Message = "",
                Status = true
            };
        
        }
    }
}