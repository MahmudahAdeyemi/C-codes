using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.ENTITIES;
using MVC.INTERFACE;

namespace MVC.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepostory)
    {
        _departmentRepository = departmentRepostory;
    }

    public IActionResult Index()
    {
        var departments = _departmentRepository.GetAllDepartment();
        return View(departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var name = TempData["name"];
        Debug.WriteLine(name);
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Department department)
    {
        _departmentRepository.AddDepartment(department);
        return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
        var department = _departmentRepository.GetDepartmentById(id);
        return View(department);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
       var department = _departmentRepository.GetDepartmentById(id);
        return View(department);
    }
    [HttpPost]
    public IActionResult Delete(int id, string name)
    {
         _departmentRepository.DeleteDepartment(id);

        return RedirectToAction("Index");
    }
    public IActionResult Update()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Update(int id,Department department)
    {
        _departmentRepository.UpdateDepartment(id,department);
        return  RedirectToAction("Index");
    }
}