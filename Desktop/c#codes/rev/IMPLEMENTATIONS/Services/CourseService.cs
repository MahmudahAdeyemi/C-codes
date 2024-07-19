using rev.DTO;
using rev.ENTITIES;
using rev.INTERFACE.Repository;
using rev.INTERFACE.Service;
using rev.RequestModels;
using rev.ResponseModels;

namespace rev.IMPLEMENTATIONS.Services
{
   
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        public BaseResponse AddCourse(CourseRequestModel courseRequestModel)
        {
            Course course = new Course
            {
                Name = courseRequestModel.Name,
                Description = courseRequestModel.Description
            };
            _courseRepository.AddCourse(course);
            return new BaseResponse
            {
                Status = true
            };

        }
        public BaseResponse DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
            return new BaseResponse
            {
                Message = "Suceefully deleted",
                Status = true
            };
        }
        public BaseResponse UpdateCourse(int id, CourseRequestModel courseRequestModel)
        {
            var course = _courseRepository.GetCourseById(id);
            course.Name = courseRequestModel.Name;
            course.Description = courseRequestModel.Description;
            return new BaseResponse
            {
                Message = "Suceefully updated",
                Status = true
            };
        }
        public CourseResponseModel GetCourseById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            return new CourseResponseModel
            {
                Data = new CourseDTO
                {
                    Name = course.Name,
                    Description = course.Description
                }
            };
        }





    }
}