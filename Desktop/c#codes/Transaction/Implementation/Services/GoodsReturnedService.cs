using Transaction.DTO;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;
using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class GoodsReturnedService
    {
        private readonly IGoodRealesdRepository _goodReleasedRepository;
        private readonly IProductRepository _productRepository;

        public GoodsReturnedService(IGoodRealesdRepository purchaceRepository, IProductRepository productRepository)
        {
            _goodReleasedRepository = purchaceRepository;
            _productRepository = productRepository;
        }

        public GoodReleasesResponseModel GetAllPurchase()
        {

            var purchaces = _goodReleasedRepository.GetAllGoodReleased();
            if (purchaces == null)
            {
                return new GoodReleasesResponseModel
                {
                    Status = false,
                    Message = "No Purchase retrieved"

                };
            }

            var purchacesReturned = purchaces.Select(sr => new GoodRealeasedDTO
            {
                Id = sr.Id,
                DateReleased = sr.DateReleased
            }).ToList();

            return new GoodReleasesResponseModel
            {
                Data = purchacesReturned,
                Message = "",
                Status = true
            };
        }

        public GoodReleaseResponseModel GetPurchaseById(int id)
        {
            var manager = _goodReleasedRepository.GetGoodReleasedById(id);
            if (manager == null)
            {
                return new GoodReleaseResponseModel
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            List<string> ProductName = new List<string>();
            List<decimal> ProductQuantity = new List<decimal>();
            for (int i = 0; i < manager.GoodReleasedProducts.Count(); i++)
            {
                var product1 = _productRepository.GetProductById(manager.GoodReleasedProducts[i].ProductId);
                Product product = new Product()
                {
                    Name = product1.Name
                };
                ProductName.Add(product.Name);
                ProductQuantity.Add(Math.Round(manager.GoodReleasedProducts[i].Quantity,2));
            }
            return new GoodReleaseResponseModel
            {
                Data = new GoodRealeasedDTO
                {
                    Id = manager.Id,
                    DateReleased = manager.DateReleased,
                    ProductName = ProductName,  
                    Quantity = ProductQuantity                    
                },
                Message = "Sucessfully done.",
                Status = true
            };
        }
 
    }
}