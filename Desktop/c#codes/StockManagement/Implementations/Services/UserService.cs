using StockManagement.DTO;
using StockManagement.Entities;
using StockManagement.Interfaces.Repositories;
using StockManagement.ReponseModel;
using StockManagement.RequestModels;

namespace StockManagement.Implementations.Services
{
    public class UserService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISalesRepRepository _salesRepRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(ICustomerRepository customerRepository,IUserRepository userRepository,ISalesRepRepository salesRepRepository,IRoleRepository roleRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _salesRepRepository = salesRepRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> RegisterCustomer(RegisterRequestModel model)
        {
            Customer customer = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Address = model.Address,
                Email = model.Email,
                Password = PasswordUtil.HashPassword(model.Password),
                PhoneNumber = model.PhoneNumber
            };
            var check = _customerRepository.IfExit(customer);
            if (!check)
            {
                return new BaseResponse
                {
                    Message = "UserName already exist",
                    Status = false
                };
            }
            _customerRepository.AddCustomer(customer);
            User user = new ()
            {
                UserName = model.UserName,
                Email = model.Email,
                HashedPassword = PasswordUtil.HashPassword(model.Password),
                RoleId = 4,
                Role = _roleRepository.GetRoleById(4)
            };
            _userRepository.AddUser(user);
            return new BaseResponse
            {
                Message = "Sucessfully registered",
                Status = true
            };
        }
        
        public async Task<BaseResponse> RegisterSalesRep(RegisterRequestModel model)
        {
            SalesRep salesRep = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Address = model.Address,
                Email = model.Email,
                Password = PasswordUtil.HashPassword(model.Password),
                PhoneNumber = model.PhoneNumber
            };
            var check = _salesRepRepository.IfExit(salesRep);
            if (!check)
            {
                return new BaseResponse
                {
                    Message = "UserName already exist",
                    Status = false
                };
            }
            _salesRepRepository.AddSalesRep(salesRep);
            User   user = new ()
            {
                UserName = model.UserName,
                Email = model.Email,
                HashedPassword = PasswordUtil.HashPassword(model.Password),
                RoleId = 3,
                Role = _roleRepository.GetRoleById(3)
            };
            _userRepository.AddUser(user);
            return new BaseResponse
            {
                Message = "Sucessfully registered",
                Status = true
            };
        }
        public async Task<GetUserResponseModel> Login(LoginRequestModel model)
        {
            var user = _userRepository.GetAllUser().FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return new GetUserResponseModel
                {
                    Message =  "You have not registered",
                    Status = false
                };
            }
            if (PasswordUtil.HashPassword(model.Password) == user.HashedPassword)
            {
                return new GetUserResponseModel
                {
                    Message = "Sucessfully logged in",
                    Status = true,
                    Data = new UserDTO
                    {
                        UserEmail = model.Email,
                        UserId = user.Id,
                        Password = user.HashedPassword,
                        Role = user.Role.Select(a => new RoleDTO
                    {
                        Name = a.Role.Name
                    })
                    }
                };
            }

        }

    }
}