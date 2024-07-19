using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;
using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;
using System.Security.Claims;

namespace E_Commerce_2.Implementations.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAdminRepository _adminrepository;
        private readonly HttpContextAccessor _httpContextAccessor;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, IAdminRepository adminrepository, HttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _adminrepository = adminrepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddProduct (ProductRequestModel productRequestModel)
        {
            var id =int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var admin =  _adminrepository.GetAdminById(id);
            if (admin == null)
            
            {
                string filename = null;
                if (productRequestModel.Image != null)
                {
                    var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\");
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
                        productRequestModel.Image.CopyToAsync(stream);
                    }
                }
                var category = _categoryRepository.GetCategoryByName(productRequestModel.Category);
                var product = new Product
                {
                    Name = productRequestModel.Name,
                    CategoryId = category.Id,
                    Image = filename
                };
                _productRepository.AddProduct(product);
            }
        }
    }
}         