using e_commerce.Entities;

namespace e_commerce.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Brand AddBrand(Brand brand);
        Brand UpdateBrand(Brand brand);
    }
}