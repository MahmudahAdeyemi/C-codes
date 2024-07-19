using System.Net.Http;
using JWTAssignment.DTOs;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;
        public UserService(HttpClient httpClient,IUserRepository userRepository,IRoleRepository roleRepository , ICustomerRepository customerRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _httpClient = httpClient;
        }
        public async Task FetchApi()
        {
            var url = "https://dog.ceo/api/breeds/list/all";
            var result  = await _httpClient.GetAsync(url);
        }
        public async Task<GetUserResponseModel> LoginAsync(LoginRequestModel request)
        {
            var user = await _userRepository.GetAsync(request.UserEmail);
            if (user == null) return null;
            if (PasswordUtil.HashPassword(request.Password) == user.PasswordHash)
            {
                return new GetUserResponseModel
                {
                    Message = "Sucessfully logged in",
                    Status = true,
                    Data = new UserDTO
                    {
                        UserEmail = request.UserEmail,
                        UserId = user.Id,
                        Password = user.PasswordHash,
                        Roles = user.UserRoles.Select(a => new RoleDTO
                    {
                        Name = a.Role.Name
                    }).ToList()
                    }
                };
            }
            return null;
        }
        public async Task<BaseResponse> DeleteUser(int id)
        {
            var user = await _userRepository.GetAsync(x => x.Id == id);
            var name = user.UserRoles.Select(x => x.Role.Name).ToList();
            await _userRepository.Delete(user.Id);
            await _customerRepository.Delete(user.Id);
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public async Task<GetUsersResponseModel> GetAllUsers()
        {
            var data = await _userRepository.GetAllAsync();
            return new GetUsersResponseModel
            {
                Message = "Sucessful",
                Status = true,
                Data = data.ToList().Select(x => new UserDTO{
                    UserId = x.Id,
                    UserName = x.UserName,
                    UserEmail = x.Email,
                    Roles = x.UserRoles.Select(a => new RoleDTO
                    {
                        Name = a.Role.Name
                    }).ToList()
                })
            };
        }
        public async Task<GetUserResponseModel> GetUser(int id)
        {
            var user = await _userRepository.GetAsync(x => x.Id == id);
            if (user == null)
            {
                return new GetUserResponseModel
                {
                    Message = "Not found",
                    Status = false,
                    Data = null
                };
            }
            return new GetUserResponseModel
            {
                Message = "Successful",
                Status = true,
                Data = new UserDTO
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserEmail = user.Email,
                    Roles = user.UserRoles.Select(a => new RoleDTO
                    {
                        Name = a.Role.Name
                    }).ToList()
                }
            };
        }

        
        public async Task<BaseResponse> UpdateUser(int UserId,string newRole)
        {
            var user1 = await _userRepository.GetAsync(x => x.Id ==UserId);

            await _userRepository.Delete(user1.Id);
            User user = new User
            {
                
                UserName = user1.UserName,
                Email = user1.Email,
                PasswordHash = user1.PasswordHash
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
            
            if (newRole == "salesPerson")
            {
                var role1 = await _roleRepository.GetAsync("salesPerson");
                var userRole1 = new UserRole
                {
                    User = user,
                    Role  = role1,
                    UserId = user.Id,
                    RoleId = role1.Id
                };
                user.UserRoles.Add(userRole1);
            }
            if (newRole == "manager")
            {
                var role1 = await _roleRepository.GetAsync("manager");
                var userRole1 = new UserRole
                {
                    User = user,
                    Role  = role1,
                    UserId = user.Id,
                    RoleId = role1.Id
                };
                user.UserRoles.Add(userRole1);
            }

            await _userRepository.CreateAsync(user);
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }

    }
    
}