using JWTAssignment.DTOs;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public async Task<RoleResponseModel>  GetRole(int id)
        {
            var role =  await _roleRepository.GetAsync(x => x.Id  == id);
            if (role == null)
            {
                return new RoleResponseModel
                {
                    Message = "Role not found",
                    Status = false
                };
            }
            return new RoleResponseModel
            {
                Data = new RoleDTO
                {
                    Name = role.Name,
                    Description = role.Description,
                    Users = role.UserRoles.Select(x => new UserDTO
                    {
                        UserName = x.User.UserName
                    }).ToList()
                },
                Message = "Sucessfully loaded",
                Status = true
            };

        }
        public async Task<GetAllRolesResponse> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllAsync();
            return new GetAllRolesResponse
            {
                Message = "Sucessfully loaded",
                Status = true,
                Data = roles.ToList().Select(x => new RoleDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList()
            };
        }
        public async Task<BaseResponse> UpdateRole(int id,string newDescription)
        {
            var role =  await _roleRepository.GetAsync(x => x.Id == id);
            role.Description = newDescription;
            _roleRepository.Update(role);
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }
        public async Task<BaseResponse> DeleteRole(int id)
        {
            await _roleRepository.Delete(id);
            var role =await GetRole(id);
            var user = role.Data.Users.ToList();
            foreach(var item in user)
            {
                await _userRepository.DeleteByName(item.UserName);
            }
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };

        }



    }
}