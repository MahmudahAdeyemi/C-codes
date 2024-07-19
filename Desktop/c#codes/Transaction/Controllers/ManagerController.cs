using Microsoft.AspNetCore.Mvc;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;

namespace Transaction.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        public IActionResult Index()
        {
            var managers = _managerService.GetAllManagerResponse();
            return View(managers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ManagerRequestModel managerRequestModel)
        {
            var managers = _managerService.AddManager(managerRequestModel);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var manager = _managerService.GetManagerById(id);
            return View(manager);
        }
        public IActionResult Delete(int id)
        {
            var manager = _managerService.GetManagerById(id);
            return View(manager);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteManager(int id)
        {
            var manager = _managerService.DeleteManager(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var manager = _managerService.GetManagerById(id);
            return View(manager);
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateManagerRequestModel managerRequestModel)
        {
            _managerService.UpdateManager(id,managerRequestModel);
            return RedirectToAction("Index");
        }
 
    }
}