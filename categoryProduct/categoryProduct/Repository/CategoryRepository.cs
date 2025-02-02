using categoryProduct.Entities;
using MySql.Data.MySqlClient;

namespace categoryProduct.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddCategory(Categories categories)
        {
            bool status = false;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO categories (cat_id,catName) VALUES (@cat_id,@catName)";
                    MySqlCommand command = new MySqlCommand(query, c);
                    command.Parameters.AddWithValue("@cat_id", categories.cat_id);
                    command.Parameters.AddWithValue("@catName", categories.catName);
                    await c.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    status = rowsAffected > 0;
                } catch (Exception ex) {
                    Console.WriteLine($"An error occurred:{ex.Message}");
                    throw;
                }
            }
            return status;
        }
        public async Task<bool> DeleteCategory(int cat_id)
        {
            bool status = false;
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "delete from categories where cat_id=@cat_id";
                    MySqlCommand command = new MySqlCommand(query, c);
                    command.Parameters.AddWithValue("@cat_id", cat_id);
                    await c.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    status = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return status;
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            List<Categories> categories = new List<Categories>();
            string query = "select * from categories";
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                await c.OpenAsync();
                using (MySqlCommand command = new MySqlCommand(query, c)) {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            Categories cat= new Categories()
                            {
                                cat_id = reader.GetInt32("cat_id"),
                                catName = reader.GetString("catName")
                            };
                            categories.Add(cat);
                        }
                    }

                }
                return categories;

            }

        }


        public async Task<bool> UpdateCategory(Categories categories)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE categories SET catName=@catName WHERE cat_id=@cat_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@catName", categories.catName);
                    command.Parameters.AddWithValue("@cat_id", categories.cat_id); // Fix

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    status = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
            return status;
        }

    }
}
