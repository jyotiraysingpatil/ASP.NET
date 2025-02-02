using categoryProduct.Entities;
using categoryProduct.Repository;

namespace categoryProduct.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(Categories categories)=> await _categoryRepository.AddCategory(categories); 

        

        public async Task<bool> DeleteCategory(int cat_id)=> await _categoryRepository.DeleteCategory(cat_id);  

        
        public async Task<List<Categories>> GetAllCategories()=> await _categoryRepository.GetAllCategories();  
        

        public async Task<bool> UpdateCategory(Categories categories)=> await _categoryRepository.UpdateCategory(categories);   
       
    }
}
