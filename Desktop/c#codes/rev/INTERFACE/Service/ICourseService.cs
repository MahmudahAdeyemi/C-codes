using rev.RequestModels;
using rev.ResponseModels;

namespace rev.INTERFACE.Service
{
    public interface ICourseService
    {
         
        BaseResponse AddCourse(CourseRequestModel courseRequestModel);
        BaseResponse DeleteCourse(int id);
        CourseResponseModel GetCourseById(int id);
        BaseResponse UpdateCourse(int id, CourseRequestModel courseRequestModel);
    }
}