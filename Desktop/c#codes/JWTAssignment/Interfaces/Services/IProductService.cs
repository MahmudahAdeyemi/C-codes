using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Interfaces.Services
{
    public interface IProductService
    {
        Task<BaseResponse> AddProduct(ProductRequestModel productRequestModel);
        Task<BaseResponse>  DeleteProduct(int id);
        Task<BaseResponse> UpdateProduct(int id,ProductRequestModel productRequestModel);
        Task<GetProductRespone> GetProduct(int id);
        Task<GetAllProductsReponse> GetAllProducts();
    }
}