using EcommerceOfficial.Entities;
using EcommerceOfficial.Implementation.Services;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOfficial.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdminService _adminsService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomerService _customerService;

        public UserController(IAdminService adminsService, SignInManager<AppUser> signInManager, ICustomerService customerService)
        {
            _adminsService = adminsService;
            _signInManager = signInManager;
            _customerService = customerService;
        }

        public IActionResult AddAdmin()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterUserRequestModel registerUserRequestModel)
        {

        var response =  await   _adminsService.Register(registerUserRequestModel);
            if (!response.Status)
            {
                return View(registerUserRequestModel);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(RegisterUserRequestModel registerUserRequestModel)
        {

            var response = await _customerService.Register(registerUserRequestModel);
            if (!response.Status)
            {
                return View(registerUserRequestModel);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult LogOut()
        {
            _customerService.Logout();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {

            var response = await _adminsService.Login(loginRequestModel);
            if (!response.Status)
            {
                TempData["Message"] = response.Meassage;
                return View(loginRequestModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
