using categoryProduct.Entities;
using categoryProduct.Repository;

namespace categoryProduct.Services
{
    public interface IProductService
    {
        Task<bool> AddProduct(Products products);
        Task<bool> DeleteProduct(int pro_id);
        Task<List<Products>> GetAllProducts();
        Task<Products?> GetByProId(int pro_id);
        Task<bool> UpdateProduct(Products products);
    }
}
