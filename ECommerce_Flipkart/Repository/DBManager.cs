using ECommerce_Flipkart.Models;
using ECommerce_Flipkart.Repository;
using System.Collections.Generic;
using System.Linq;

public class DBManager : IDBManager
{
    public void DeleteProduct(int id)
    {
        using (var context = new EStoreCollectionContextDbContext())
        {
            var product = context.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                context.products.Remove(product);
                context.SaveChanges();
            }
        }
    }
    public List<Product> GetAllProducts()
    {
        using (var context = new EStoreCollectionContextDbContext())
        {
            var products = from p in context.products select p;
            return products.ToList();
        }
    }

    public void InsertProduct(Product product)
    {
        using (var context = new EStoreCollectionContextDbContext())
        {
            context.products.Add(product);
            context.SaveChanges();
        
        }
    }

    public void UpdateProduct(Product product)
    {
        using (var context = new EStoreCollectionContextDbContext())
        {
            context.products.Update(product);
            context.SaveChanges();
        }
    }

    

}
