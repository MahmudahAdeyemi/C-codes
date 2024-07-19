using Transaction.DTO;
using Transaction.Entities;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
using Transaction.ResponseModel;

namespace Transaction.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IShopItemsRepository _shopItemsRepository;
        private readonly IStoreItemsRepository _storeItemsRepository;

        public ProductService(IProductRepository productRepository, IShopItemsRepository shopItemsRepository, IStoreItemsRepository storeItemsRepository)
        {
            _productRepository = productRepository;
            _shopItemsRepository = shopItemsRepository;
            _storeItemsRepository = storeItemsRepository;
        }

        public BaseResponse AddProduct(ProductRequestModel productRequestModel)
        {
            Product product = new Product
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                UnitOfMeasurement = productRequestModel.UnitOfMeasurement,
                UnitPrice = productRequestModel.UnitPrice,
                Category = productRequestModel.Category,
                CategoryPrice = productRequestModel.CategoryPrice,
                CategoryQuantity = productRequestModel.CategoryPrice
            };
            ShopItems shopItems = new ShopItems
            {
                Name = product.Name,
                Quantity = 0
            };
            _shopItemsRepository.AddShopItems(shopItems);
            StoreItems storeItems = new StoreItems
            {
                Name = product.Name,
                Quantity = 0
            };
            _storeItemsRepository.AddStoreItems(storeItems);
            bool c = _productRepository.IfExit(product);
            if (c == true)
            {
                _productRepository.AddProduct(product);
                return new BaseResponse
                {
                    Message = "Sucessfully added",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Already exits",
                Status = false
            };

        }
        public BaseResponse DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            _productRepository.DeleteProduct(product);
            if(_shopItemsRepository.GetAllShopItems().Select(x => x.Name).ToList().Contains(product.Name))
            {
                _shopItemsRepository.DeleteShopItem(_shopItemsRepository.GetShopItemsByName(product.Name));
            }
            if (_storeItemsRepository.GetAllStoreItems().Select(x => x.Name).ToList().Contains(product.Name))
            {
                _storeItemsRepository.DeleteStoreItems(_storeItemsRepository.GetStoreItemsByName(product.Name));
            }
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public BaseResponse UpdateProduct(int id, ProductRequestModel ProductRequestModel)
        {
            var Product = _productRepository.GetProductById(id);
            if (Product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            Product.Name = ProductRequestModel.Name;
            Product.Description = ProductRequestModel.Description;
            Product.UnitOfMeasurement = ProductRequestModel.UnitOfMeasurement;
            Product.UnitPrice  = ProductRequestModel.UnitPrice;
            _productRepository.UpdateProduct(Product);
            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }
        public ProductResponse GetProductById(int id)
        {
            var Product = _productRepository.GetProductById(id);
            if (Product == null)
            {
                return new ProductResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            return new ProductResponse
            {
                Data = new ProductDTO
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    Description = Product.Description,
                    UnitPrice =Math.Round(Product.UnitPrice, 2),
                    UnitOfMeasurement = Product.UnitOfMeasurement
                },
                Message = "Sucessfully done.",
                Status = false
            };
        }
        public ProductsResponse GetAllProductResponse()
        {
            

            var Product = _productRepository.GetAllProduct();
            if(Product == null)
            {
                return new ProductsResponse
                {
                    Status = false,
                    Message = "No product retrieved"

                };
            }

            var ProductReturned = Product.Select(sr => new ProductDTO
                {
                    Id = sr.Id,
                    Name = sr.Name,
                    Description = sr.Description,
                    UnitPrice = Math.Round(sr.UnitPrice,2),
                    UnitOfMeasurement = sr.UnitOfMeasurement
                }).ToList();
            return new ProductsResponse
            {
                Data = ProductReturned,
                Message = "",
                Status = true
            };
        
        }
    }
}