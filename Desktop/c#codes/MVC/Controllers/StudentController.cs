using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ENTITIES;
using MVC.INTERFACE;
using MVC.REPOSITORIES;

namespace MVC.Controllers;
public class StudentController : Controller
{
    private readonly IStudentRepository _studentRepository;
    private readonly IDepartmentRepository _departmentRepository;
    public StudentController(IStudentRepository StudentRepostory, IDepartmentRepository departmentRepostory)
    {
        _studentRepository = StudentRepostory;
        _departmentRepository = departmentRepostory;
    }

    public IActionResult Index()
    {
        var students = _studentRepository.GetAllStudents();
        TempData["Students"] = students.Count();
        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var departments =  _departmentRepository.GetAllDepartment();
        ViewData["Departments"] = new SelectList(departments, "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Student Student)
    {
        _studentRepository.AddStudent(Student);
        return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
        var students= _studentRepository.GetStudentById(id);
        return View(students);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
       var student = _studentRepository.GetStudentById(id);
        return View(student);
    }
    [HttpPost]
    public IActionResult Delete(int id,string name)
    {
        _studentRepository.DeleteStudent(id);
        return RedirectToAction("Index");
    }
     [HttpGet]
    public IActionResult Update()
    {
        var departments =  _departmentRepository.GetAllDepartment();
        ViewData["Departments"] = new SelectList(departments, "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public IActionResult Update(int id,Student Student)
    {
        _studentRepository.UpdateStudent(id,Student);
        return  RedirectToAction("Index");
    }

}