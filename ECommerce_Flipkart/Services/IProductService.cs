using ECommerce_Flipkart.Models;

namespace ECommerce_Flipkart.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

    }
}
