using e_commerce.Context;
using e_commerce.Entities;
using e_commerce.Interfaces.Repositories;

namespace e_commerce.Implementations.Repositories
{
    

    public class BrandRepository : IBrandRepository
    {
        private readonly e_commerceContext _e_commerceContext;
        public BrandRepository(e_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Brand AddBrand(Brand brand)
        {
            _e_commerceContext.Add(brand);
            _e_commerceContext.SaveChanges();
            return (brand);
        }
        public Brand UpdateBrand(Brand brand)
        {
            _e_commerceContext.Update(brand);
            _e_commerceContext.SaveChanges();
            return (brand);
        }
    }
}