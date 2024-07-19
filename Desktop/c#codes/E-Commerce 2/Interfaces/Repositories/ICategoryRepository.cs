using E_Commerce_2.Entities;

namespace E_Commerce_2.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
    }
}