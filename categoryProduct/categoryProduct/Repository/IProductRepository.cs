using categoryProduct.Entities;

namespace categoryProduct.Repository
{
    public interface IProductRepository
    {
        public Task<bool> AddProduct(Products products);
        public Task<bool> UpdateProduct(Products products);
        public Task<bool> DeleteProduct(int pro_id);    
        public Task<List<Products>> GetAllProducts();   
        public Task<Products?> GetByProId(int pro_id);
    }
}
