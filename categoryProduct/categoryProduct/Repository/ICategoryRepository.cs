using categoryProduct.Entities;

namespace categoryProduct.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(Categories categories);
        Task<bool> UpdateCategory(Categories categories);
        Task<bool> DeleteCategory(int cat_id);
        Task<List<Categories>> GetAllCategories();

    }
}
