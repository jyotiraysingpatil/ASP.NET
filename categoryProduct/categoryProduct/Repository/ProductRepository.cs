using categoryProduct.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace categoryProduct.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddProduct(Products products)
        {
            bool status = false;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO products (prodName, cat_id) VALUES (@prodName, @cat_id)";
                    using (MySqlCommand cmd = new MySqlCommand(query, c))
                    {
                        cmd.Parameters.AddWithValue("@prodName", products.prodName);
                        cmd.Parameters.AddWithValue("@cat_id", products.cat_id);

                        await c.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        status = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
            return status;
        }

        public async Task<bool> DeleteProduct(int pro_id)
        {
            bool status = false;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM products WHERE pro_id = @pro_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, c))
                    {
                        cmd.Parameters.AddWithValue("@pro_id", pro_id);
                        await c.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        status = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
            return status;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            List<Products> products = new List<Products>();
            string query = "SELECT * FROM products";

            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                await c.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, c))
                {
                    using (MySqlDataReader reader = await cmd.ExecuteReaderAsync()) // Fixed issue
                    {
                        while (await reader.ReadAsync())
                        {
                            Products product = new Products()
                            {
                                pro_id = reader.GetInt32("pro_id"),
                                prodName = reader.GetString("prodName"),
                                cat_id = reader.GetInt32("cat_id")
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public async Task<Products?> GetByProId(int pro_id)
        {
            Products? product = null;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM products WHERE pro_id = @pro_id";
                    using (MySqlCommand command = new MySqlCommand(query, c))
                    {
                        command.Parameters.AddWithValue("@pro_id", pro_id);
                        await c.OpenAsync();

                        using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                product = new Products
                                {
                                    pro_id = reader.GetInt32("pro_id"),
                                    prodName = reader.GetString("prodName"),
                                    cat_id = reader.GetInt32("cat_id")
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return product;
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            bool status = false;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE products SET prodName = @prodName, cat_id = @cat_id WHERE pro_id = @pro_id";
                    using (MySqlCommand command = new MySqlCommand(query, c))
                    {
                        command.Parameters.AddWithValue("@prodName", products.prodName);
                        command.Parameters.AddWithValue("@cat_id", products.cat_id);
                        command.Parameters.AddWithValue("@pro_id", products.pro_id);

                        await c.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        status = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return status;
        }
    }
}
