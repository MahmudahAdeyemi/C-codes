using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;

namespace EcommerceOfficial.Interfaces.Services
{
    public interface IProductService
    {
        Task<BaseResponseModel> AddProduct(ProductRequestModel productRequestModel);
        Task<BaseResponseModel> DeleteProduct(string id);
        Task<GetAllProductsResponseModel> Search(RoleRequestModel model);
        Task<BaseResponseModel> AddToCart(string productId);
        Task<GetAllProductsResponseModel> GetAllProducts();
        Task<BaseResponseModel> Order();
        Task<ProductDto> GetProduct(string id);
        Task<BaseResponseModel> UpdateProduct(string id, ProductRequestModel model);
        
    }
}