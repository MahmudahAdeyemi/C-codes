using file.DTOs;
using file.Entities;
using file.Interfaces.Repositoritories;
using file.Interfaces.Services;
using file.RequestModel;
using file.ResponseModel;

namespace file.Implementation.Services
{
    public class ProductService  : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public BaseResponse AddProduct(ProductRequestModel productRequestModel)
        {
            if ( AuthenticatedUser.UserName == null || AuthenticatedUser.Role !=User.Role.Admin)
            {
                return new BaseResponse
                {
                    Message = "You are not entitled to this page",
                    Status = false
                };
            }
            if(_productRepository.GetProductByName(productRequestModel.Name) != null)
            {

                return new BaseResponse
                {
                    Message = "Already exist",
                    Status = false
                };
            }

            Product product = new Product
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                UnitOfMeasurement = productRequestModel.UnitOfMeasurement,
                SellingPrice = productRequestModel.SellingPrice,
                CostPrice = productRequestModel.CostPrice,
                QuantityAvailable = productRequestModel.QuantityAvailable,
                IsDeleted = false,

            };
            _productRepository.Add(product);
            return new BaseResponse
            {
                Message = "Sucessfully added",
                Status = true
            };
        }
        public BaseResponse DeleteProduct(string name)
        {
            if ( AuthenticatedUser.UserName == null || AuthenticatedUser.Role != User.Role.Admin)
            {
                return new BaseResponse
                {
                    Message = "You are not entitled to this page",
                    Status = false
                };
            }
            var product = _productRepository.GetProductByName(name);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            product.IsDeleted = true;
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public BaseResponse UpdateProduct( ProductRequestModel poductRequestModel)
        {
            if ( AuthenticatedUser.UserName == null || AuthenticatedUser.Role !=  User.Role.Admin)
            {
                return new BaseResponse
                {
                    Message = "You are not entitled to this page",
                    Status = false
                };
            }
            var product = _productRepository.GetProductByName(poductRequestModel.Name);
            _productRepository.Delete(product.Id);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            AddProduct(poductRequestModel);
            // product.Name = poductRequestModel.Name;
            // product.Description = poductRequestModel.Description;
            // product.UnitOfMeasurement = poductRequestModel.UnitOfMeasurement;
            // product.SellingPrice = poductRequestModel.Price;
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }
        public ProductResponseModel GetProductById(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            return new ProductResponseModel
            {
                Data = new ProductDTO
                {
                    Name = product.Name,
                    QuantityAvailable = product.QuantityAvailable,
                    Price = Math.Round(product.SellingPrice,2),
                    UnitOfMeasurement = product.UnitOfMeasurement,
                    Description = product.Description
                },
                Message = "Product returned",
                Status = true
            };
        }

        public GetAllProductResponse GetAllProductResponse()
        {
            var Product = _productRepository.GetAllProducts();
            if(Product == null)
            {
                return new GetAllProductResponse
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
                    Price = Math.Round(sr.SellingPrice,2),
                    UnitOfMeasurement = sr.UnitOfMeasurement
                }).ToList();
            return new GetAllProductResponse
            {
                Data = ProductReturned,
                Message = $"Product available is {ProductReturned.Count} ",
                Status = true
            };
        
        }

    }
}
