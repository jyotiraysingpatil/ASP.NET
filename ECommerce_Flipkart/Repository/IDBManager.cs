using ECommerce_Flipkart.Models;

namespace ECommerce_Flipkart.Repository
{
    public interface IDBManager
    {
        List<Product> GetAllProducts();

        void InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

    }
}
    