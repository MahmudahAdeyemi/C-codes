using System.Runtime.CompilerServices;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class PersonService  : IPersonService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;
        
        public PersonService(IUserRepository userRepository,IRoleRepository roleRepossitory, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepossitory;
            _customerRepository = customerRepository;
        }
        
        public async Task<BaseResponse> CreateCustomer(UserRequestModel userRequestModel)
        {
            var user1 = await _userRepository.GetAsync(userRequestModel.Email);
            if (user1 != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Status = false
                };
            }
            User user = new User
            {
                UserName = userRequestModel.Name,
                Email = userRequestModel.Email,
                PasswordHash = PasswordUtil.HashPassword(userRequestModel.Password)
            };
            var role = await _roleRepository.GetAsync("customer");
            var userRole = new UserRole
            {
                User = user,
                Role  = role,
                UserId = user.Id,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            await _userRepository.CreateAsync(user);
            Customer customer = new Customer()
            {
                Name = userRequestModel.Name,
                Email = user.Email,
                Address = userRequestModel.Address,
                UserId = user.Id
            };
            await _customerRepository.CreateAsync(customer);
            return new BaseResponse
            {
                Message  = "Sucessfully created",
                Status = true
            };
        }
        public async Task<BaseResponse> CreateManager(UserRequestModel userRequestModel)
        {
            var user1 = await _userRepository.GetAsync(userRequestModel.Email);
            if (user1 != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Status = false
                };
            }
            User user = new User
            {
                UserName = userRequestModel.Name,
                Email = userRequestModel.Email,
                PasswordHash = PasswordUtil.HashPassword(userRequestModel.Password)
            };
            var role = await _roleRepository.GetAsync("customer");
            var role1 = await _roleRepository.GetAsync("manager");
            var userRole = new UserRole
            {
                User = user,
                Role  = role,
                UserId = user.Id,
                RoleId = role.Id
            };
            var userRole1 = new UserRole
            {
                User = user,
                Role  = role1,
                UserId = user.Id,
                RoleId = role1.Id
            };
            user.UserRoles.Add(userRole);
            user.UserRoles.Add(userRole1);
            await _userRepository.CreateAsync(user);
            Customer customer = new Customer()
            {
                Name = userRequestModel.Name,
                Email = user.Email,
                Address = userRequestModel.Address,
                UserId = user.Id
            };
            await _customerRepository.CreateAsync(customer);
            return new BaseResponse
            {
                Message  = "Sucessfully created",
                Status = true
            };
        }
        public async Task<BaseResponse> CreateSalesperson(UserRequestModel userRequestModel)
        {
            var user1 = await _userRepository.GetAsync(userRequestModel.Email);
            if (user1 != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Status = false
                };
            }
            User user = new User
            {
                UserName = userRequestModel.Name,
                Email = userRequestModel.Email,
                PasswordHash = PasswordUtil.HashPassword(userRequestModel.Password)
            };
            var role = await _roleRepository.GetAsync("customer");
            var role1 = await _roleRepository.GetAsync("salesPerson");
            var userRole = new UserRole
            {
                User = user,
                Role  = role,
                UserId = user.Id,
                RoleId = role.Id
            };
            var userRole1 = new UserRole
            {
                User = user,
                Role  = role1,
                UserId = user.Id,
                RoleId = role1.Id
            };
            user.UserRoles.Add(userRole);
            user.UserRoles.Add(userRole1);
            await _userRepository.CreateAsync(user);
            Customer customer = new Customer()
            {
                Name = userRequestModel.Name,
                Email = user.Email,
                Address = userRequestModel.Address,
                UserId = user.Id
            };
            await _customerRepository.CreateAsync(customer);
            return new BaseResponse
            {
                Message  = "Sucessfully created",
                Status = true
            };
        }
        
    }
}