using file.Entities;
using file.Interfaces.Repositoritories;
using file.Interfaces.Services;
using file.RequestModel;
using file.ResponseModel;

namespace file.Implementation.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public StockService(IStockRepository stockRepository, IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }
        public BaseResponse AddStock(StockRequestModel stockRequestModel)
        {
            if ( AuthenticatedUser.UserName == null || AuthenticatedUser.Role !=User.Role.Admin)
            {
                return new BaseResponse
                {
                    Message = "You are not entitled to this page",
                    Status = false
                };
            }
            Stock stock = new Stock
            {
                CostPrice = stockRequestModel.CostPrice,
                ProductId = stockRequestModel.ProductId,
                Quantity = stockRequestModel.Quantity
            };
            _stockRepository.Add(stock);
            var product = _productRepository.GetProduct(stockRequestModel.ProductId);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product needs to be added before it is stocked",
                    Status = false
                };
            }
            product.QuantityAvailable += stock.Quantity;
            var product1 = product;
            _productRepository.Add(product1);
            _productRepository.Delete(product.Id);
            return new BaseResponse
            {
                Message ="Sucessfully added",
                Status = false
            };            
        }
        
    }
}

