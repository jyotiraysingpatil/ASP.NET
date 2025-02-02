using categoryProduct.Entities;
using categoryProduct.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace categoryProduct.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddProduct(Products products) => await repository.AddProduct(products);

        public async Task<bool> DeleteProduct(int pro_id) => await repository.DeleteProduct(pro_id);

        public async Task<List<Products>> GetAllProducts() => await repository.GetAllProducts();

        public async Task<Products?> GetByProId(int pro_id) => await repository.GetByProId(pro_id);

        public async Task<bool> UpdateProduct(Products products) => await repository.UpdateProduct(products);
    }
}
