using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Interfaces.Services
{
    public interface IProductService
    {
        BaseResponse AddProduct(ProductRequestModel productRequestModel);
        BaseResponse DeleteProduct(int id);
         ProductsResponse GetAllProductResponse();
        ProductResponse GetProductById(int id);
        BaseResponse UpdateProduct(int id, ProductRequestModel ProductRequestModel);
    }
}