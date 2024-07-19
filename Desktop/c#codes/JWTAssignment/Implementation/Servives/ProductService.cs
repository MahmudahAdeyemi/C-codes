using JWTAssignment.DTOs;
using JWTAssignment.Entities;
using JWTAssignment.Interfaces.Repositories;
using JWTAssignment.Interfaces.Services;
using JWTAssignment.RequestModel;
using JWTAssignment.ResponseModel;

namespace JWTAssignment.Implementation.Servives
{
    public class ProductService : IProductService
    {
        private readonly  IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        } 
        public async Task<BaseResponse> AddProduct(ProductRequestModel productRequestModel)
        {
            var checkproduct = _productRepository.GetProductByName(productRequestModel.Name).Result;
            if( checkproduct != null)
            {                                                                                                                                                                                                                                                                                                                                                                                                      return new BaseResponse
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
            await _productRepository.CreateAsync(product);
            return new BaseResponse
            {
                Message = "Sucessfully added",
                Status = true
            };
        }
        public async Task<BaseResponse>  DeleteProduct(int id)
        {
            var product =await _productRepository.GetProductById(id);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            product.IsDeleted = true;
            _productRepository.Update(product);
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateProduct( int id,ProductRequestModel productRequestModel)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return  new BaseResponse
                {
                    Message = "Not found",
                    Status = false
                };
            }
            await _productRepository.Delete(product.Id);
            Product product1 = new Product
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                UnitOfMeasurement = productRequestModel.UnitOfMeasurement,
                SellingPrice = productRequestModel.SellingPrice,
                CostPrice = productRequestModel.CostPrice,
                QuantityAvailable = productRequestModel.QuantityAvailable,
                IsDeleted = false,

            };
            // product = product1;
            await _productRepository.CreateAsync(product1);
            
            return  new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = false
            };


        }
        public async Task<GetProductRespone> GetProduct(int id)
        {
            var products =await _productRepository.GetAllAsync();
            var product = products.FirstOrDefault(x => x.Id == id);
            return new GetProductRespone
            {
                Message = "Sucessfully returned",
                Status = true,
                                Data = new ProductDTO
                {
                    Name = product.Name,
                    Price = product.CostPrice,
                    QuantityAvailable = product.QuantityAvailable.ToString() + product.UnitOfMeasurement,
                    Description = product.Description
                }
            };
        }
        public async Task<GetAllProductsReponse> GetAllProducts()
        {
            var products =await _productRepository.GetAllAsync();
            return new GetAllProductsReponse
            {
                Data = products.ToList().Select(x => new ProductDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    QuantityAvailable = x.QuantityAvailable.ToString() + x.UnitOfMeasurement,
                    Description = x.Description,
                    Price = x.SellingPrice
                }).ToList()
            };
        }
    }
}