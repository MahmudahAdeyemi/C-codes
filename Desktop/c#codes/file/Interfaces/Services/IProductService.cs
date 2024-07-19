using file.RequestModel;
using file.ResponseModel;

namespace file.Interfaces.Services
{
    public interface IProductService
    {
        BaseResponse AddProduct(ProductRequestModel productRequestModel);
        BaseResponse DeleteProduct(string name);
        BaseResponse UpdateProduct( ProductRequestModel poductRequestModel);
        ProductResponseModel GetProductById(string name);
        GetAllProductResponse GetAllProductResponse();
    }
}