using EcommerceOfficial.Entities;
using EcommerceOfficial.Interfaces.Repositories;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using EcommerceOfficial.ResponseModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EcommerceOfficial.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAdminService _adminService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly SignInManager<AppUser> _signInManager;

        public ProductService(IProductRepository productRepository, IAdminService adminService, IHttpContextAccessor httpContextAccessor, ICategoryRepository categoryRepository, ICustomerRepository customerRepository, ICartRepository cartRepository, SignInManager<AppUser> signInManager)
        {
            _productRepository = productRepository;
            _adminService = adminService;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
            _signInManager = signInManager;
        }

        public async Task<BaseResponseModel> AddProduct(ProductRequestModel productRequestModel)
        {
            var category = await _categoryRepository.GetCategoryByName(productRequestModel.Category);
            var product1 = await _productRepository.GetProductByName(productRequestModel.Name);
            if (product1 != null)
            {
                product1.QuantityAvailable += productRequestModel.QuantityAvailable;
            }
            else
            {
                string filename = null;
                if (productRequestModel.Image != null)
                {
                    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ProfilePictures\\");
                    bool basePathExist = Directory.Exists(basePath);
                    if (!basePathExist)
                    {
                        Directory.CreateDirectory(basePath);
                    }
                    var newfileName = Path.GetFileNameWithoutExtension(productRequestModel.Image.FileName);
                    filename = Path.GetFileName(productRequestModel.Image.FileName);
                    var filePath = Path.Combine(basePath, productRequestModel.Image.FileName);
                    if (!File.Exists(filePath))
                    {
                        using var stream = new FileStream(filePath, FileMode.Create);
                        await productRequestModel.Image.CopyToAsync(stream);
                    }
                }
                var product = new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = productRequestModel.Name,
                    Price = productRequestModel.Price,
                    CategoryId = category.Id,
                    QuantityAvailable = productRequestModel.QuantityAvailable,
                    Image = filename,
                    Description = productRequestModel.Description

                };
                await _productRepository.AddProduct(product);
            }
            return new BaseResponseModel()
            {
                Meassage = "Sucessfull added",
                Status = true
            };
        }
        
        public async Task<BaseResponseModel> UpdateProduct(string id, ProductRequestModel model)
        {
            string filename = "";
            if (model.Image != null)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ProfilePictures\\");
                bool basePathExist = Directory.Exists(basePath);
                if (!basePathExist)
                {
                    Directory.CreateDirectory(basePath);
                }
                var newfileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                filename = Path.GetFileName(model.Image.FileName);
                var filePath = Path.Combine(basePath, model.Image.FileName);
                if (!File.Exists(filePath))
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await model.Image.CopyToAsync(stream);
                }
            }
            var category =await _categoryRepository.GetCategoryByName(model.Category);
            var product =await _productRepository.GetProductById(id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.CategoryId = category.Id;
            product.Image = filename;
            return new BaseResponseModel()
            {
                Meassage = "Sucessfully updated",
                Status = false
            };
        }
       
        public async Task<BaseResponseModel> AddToCart(string productId)
        {
            var f = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (!f)
            {
                return new BaseResponseModel
                {
                    Meassage = "Not logged in",
                    Status = false
                };
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _customerRepository.GetCustomerByUserId(userId);
            //var cart = await _cartRepository.GetCustomerByCartId(customerId);
            var product = await _productRepository.GetProductById(productId);
            product.QuantityAvailable -= 1;
            var cart2 = await _cartRepository.CheckProductCarts(x => x.CustomerId == customer.Id && !x.IsCheckedOut && x.ProductId == productId);
            if (cart2 == null)
            {
                Cart cart1 = new Cart()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = productId,
                    Quantity = 1,
                    IsCheckedOut = false,
                    CustomerId = customer.Id,

                };
                await _cartRepository.AddCart(cart1);
                return new BaseResponseModel
                {
                    Meassage = "Sucess",
                    Status = true
                };

            }
            cart2.Quantity += 1;
            return new BaseResponseModel
            {
                Meassage = "Sucess",
                Status = true
            };
        }
        public async Task<BaseResponseModel> Order()
        {
            var order = new Order();
            var customerId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carts =await _cartRepository.CheckOutCarts(x => x.CustomerId == customerId && x.IsCheckedOut == false);
            foreach (var item in carts)
            {
                var product =await _productRepository.GetProductById(item.ProductId);
                order.TotalProduct += product.Price;
                item.IsCheckedOut = true;
            }
            return new BaseResponseModel()
            {
                Meassage = "Sucess",
                Status = false
            };
        }
        public async  Task<ProductDto> GetProduct (string id)
        {
            var product = await _productRepository.GetProductById(id);
            return new ProductDto()
            {
                Name = product.Name,
                Image = product.Image,
                Price = product.Price,
                QuantityAvailable = product.QuantityAvailable,
                Description = product.Description
            };
        }
        public async Task<GetAllProductsResponseModel> Search(RoleRequestModel model)
        {
            var product = await _productRepository.Search(model.Name);
            var ProductReturned = product.Select(sr => new ProductDto
            {
                Id = sr.Id,
                Name = sr.Name,
                Price = sr.Price,
                QuantityAvailable = sr.QuantityAvailable,
                Image = sr.Image
            }).ToList();
            return new GetAllProductsResponseModel()
            {
                Products = ProductReturned
            };
        }
       
        public async Task<BaseResponseModel> DeleteProduct(string id)
        {
            await _productRepository.RemoveProduct(id);
            return new BaseResponseModel()
            {
                Meassage = "Sucessfully deleted",
                Status = true
            };
        }

        public async Task<GetAllProductsResponseModel> GetAllProducts()
        {
            var product = await _productRepository.GetAllProducts();
            var ProductReturned = product.Select(sr => new ProductDto
            {
                Id = sr.Id,
                Name = sr.Name,
                Price = sr.Price,
                QuantityAvailable = sr.QuantityAvailable,
                Image = sr.Image,
                Description = sr.Description
            }).ToList();
            return new GetAllProductsResponseModel()
            {
                Products = ProductReturned
            };
        }
    }
}
