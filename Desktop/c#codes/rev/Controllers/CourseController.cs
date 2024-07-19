using Microsoft.AspNetCore.Mvc;
using rev.INTERFACE.Service;

namespace rev.Controllers
{
    public class CourseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var managers = _courseService.();
            return View(managers);
        }
    }
}