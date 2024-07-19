using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseModel> GetCategory(string id);
        Task<BaseResponseModel> AddCategory(CategoryRequestModel model);
        Task DeleteCategory(string id);
        Task<GetAllCategoriesResponseModel> GetAllCategories();
    }
}