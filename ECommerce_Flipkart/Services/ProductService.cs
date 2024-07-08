using ECommerce_Flipkart.Models;
using ECommerce_Flipkart.Repository;
using System.Collections.Generic;

namespace ECommerce_Flipkart.Services
{
    public class ProductService : IProductService
    {
        private IDBManager _idbManager;
        public ProductService(IDBManager idbmanager)
        {
            _idbManager = idbmanager;
        }

        public void AddProduct(Product product)
        {
            _idbManager.InsertProduct(product);
        }

        public void DeleteProduct(int id)
        {
           _idbManager.DeleteProduct(id);
        }

        public List<Product> GetProducts()
        {
            return _idbManager.GetAllProducts();
        }

        public void UpdateProduct(Product product)
        {
            _idbManager.UpdateProduct(product);
        }
    }
}
