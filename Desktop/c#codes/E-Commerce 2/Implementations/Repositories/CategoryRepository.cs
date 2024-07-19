using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly E_commerceContext _e_CommerceContext;

        public CategoryRepository(E_commerceContext e_CommerceContext)
        {
            _e_CommerceContext = e_CommerceContext;
        }
        public void AddCategory(Category category)
        {
            _e_CommerceContext.Add(category);
            _e_CommerceContext.SaveChanges();
        }
        public Category GetCategoryById(int id)
        {
            var category = _e_CommerceContext.Categories.SingleOrDefault(x => x.Id == id);
            return category;
        }
        public Category GetCategoryByName(string name)
        {
            var category = _e_CommerceContext.Categories.SingleOrDefault(x => x.Name == name);
            return category;
        }
    }
}
