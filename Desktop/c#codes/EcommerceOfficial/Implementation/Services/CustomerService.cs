using EcommerceOfficial.DTOs;
using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceOfficial.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerRepository = customerRepository;
        }
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            return "Sucessfully logged out";
        }
        public async Task<BaseResponseModel> Register(RegisterUserRequestModel model)
        {
            string filename = null;
            if (model.ProfilePicture != null)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ProfilePictures\\");
                bool basePathExist = Directory.Exists(basePath);
                if (!basePathExist)
                {
                    Directory.CreateDirectory(basePath);
                }
                var newfileName = Path.GetFileNameWithoutExtension(model.ProfilePicture.FileName);
                filename = Path.GetFileName(model.ProfilePicture.FileName);
                var filePath = Path.Combine(basePath, model.ProfilePicture.FileName);
                if (!File.Exists(filePath))
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await model.ProfilePicture.CopyToAsync(stream);
                }
            }
            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                ProfilePicture = filename,
                UserName = model.Email
            };

            var userMf = await _userManager.CreateAsync(user, model.Password);
            var customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                ProfilePicture = filename,
                UserId = user.Id,
                Password = model.Password
            };
            await _customerRepository.AddCustomer(customer);

            if (!userMf.Succeeded)
            {
                return new BaseResponseModel
                {
                    Meassage = userMf.Errors.FirstOrDefault().Description,
                    Status = false
                };


            }
            
            var role = await _userManager.AddToRoleAsync(user, "Admin");
            return new BaseResponseModel
            {
                Meassage = "Sucessfully logged in",
                Status = true
            };


        }
    }
}
