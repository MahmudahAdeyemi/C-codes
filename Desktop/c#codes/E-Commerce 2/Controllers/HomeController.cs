using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_2.Models;
using System.Security.Claims;

namespace E_Commerce_2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userName = User.FindFirstValue(ClaimTypes.Name);
        //var userName = User.FindFirst(ClaimTypes.Name).Value;
        //var userName = User.FindAll(ClaimTypes.Name);
        if (User.Identity.IsAuthenticated)
        {
        return View();

        }
        return RedirectToAction("Register","User");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
