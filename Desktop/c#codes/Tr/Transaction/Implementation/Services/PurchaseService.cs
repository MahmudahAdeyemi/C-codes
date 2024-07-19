using Transaction.DTO;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaceRepository;
        private readonly IProductRepository _productRepository;

        public PurchaseService(IPurchaseRepository purchaceRepository, IProductRepository productRepository)
        {
            _purchaceRepository = purchaceRepository;
            _productRepository = productRepository;
        }

        public PurchasesResponseModel GetAllPurchase()
        {

            var purchaces = _purchaceRepository.GetAllPurchace();
            if (purchaces == null)
            {
                return new PurchasesResponseModel
                {
                    Status = false,
                    Message = "No Purchase retrieved"

                };
            }

            var purchacesReturned = purchaces.Select(sr => new PurchaceDTO
            {
                Id = sr.Id,
                Date = sr.Date,
                PurchaceReferenceNumber = sr.PurchaceReferenceNumber
            }).ToList();

            return new PurchasesResponseModel
            {
                Data = purchacesReturned,
                Message = "",
                Status = true
            };
        }

        public PurchaceResponseModel GetPurchaseById(int id)
        {
            var manager = _purchaceRepository.GetPurchaceById(id);
            if (manager == null)
            {
                return new PurchaceResponseModel
                {
                    Message = "Manager not found",
                    Status = false
                };
            }
            List<string> ProductName = new List<string>();
            List<decimal> ProductPrice = new List<decimal>();
            List<decimal> ProductQuantity = new List<decimal>();
            decimal TotalPrice = 0;
            for (int i = 0; i < manager.ProductPurchaces.Count(); i++)
            {
                var product1 = _productRepository.GetProductById(manager.ProductPurchaces[i].ProductId);
                Product product = new Product()
                {
                    Name = product1.Name
                };
                ProductName.Add(product.Name);
                ProductPrice.Add(Math.Round(manager.ProductPurchaces[i].PurchacedPrice,2));
                ProductQuantity.Add(Math.Round(manager.ProductPurchaces[i].Quantity,2));
                decimal total = manager.ProductPurchaces[i].Quantity * manager.ProductPurchaces[i].PurchacedPrice;
                TotalPrice += total;
            }
            return new PurchaceResponseModel
            {
                Data = new PurchaceDTO
                {
                    Id = manager.Id,
                    Date = manager.Date,
                    PurchaceReferenceNumber = manager.PurchaceReferenceNumber,
                    TotalPrice = Math.Round(TotalPrice),
                    ProductName = ProductName,
                    PurchasedPrice = ProductPrice,
                    ProductQuantity = ProductQuantity
                    
                },
                Message = "Sucessfully done.",
                Status = true
            };
        }

    }
}