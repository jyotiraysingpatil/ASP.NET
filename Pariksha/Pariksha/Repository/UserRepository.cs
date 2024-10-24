using MySql.Data.MySqlClient;
using Pariksha.Entities;

namespace Pariksha.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<bool> AddUser(Users users)
        {
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO users (firstName, lastName, isActive, password, phoneNumber, username) VALUES (@firstName, @lastName, @isActive, @password, @phoneNumber, @username)";
                    MySqlCommand command = new MySqlCommand(query, c);
                    command.Parameters.AddWithValue("@firstName", users.firstName);
                    command.Parameters.AddWithValue("@lastName", users.lastName);
                    command.Parameters.AddWithValue("@isActive", users.isActive);
                    command.Parameters.AddWithValue("@password", users.password);
                    command.Parameters.AddWithValue("@phoneNumber", users.phoneNumber);
                    command.Parameters.AddWithValue("@username", users.username);
                    await c.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteUser(int user_id)
        {
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "delete from users where user_id=@user_id";
                    MySqlCommand command = new MySqlCommand(query, c);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    await c.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<List<Users>> GetAll()
        {
            List<Users> users = new List<Users>();
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                string query = "select * from users";
                MySqlCommand command = new MySqlCommand(query, c);
                await c.OpenAsync();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Users
                        {
                            user_id = reader.GetInt32("user_id"),
                            firstName = reader.GetString("firstName"),
                            lastName = reader.GetString("lastName"),
                            isActive = reader.GetBoolean("isActive"),
                            password = reader.GetString("password"),
                            phoneNumber = reader.GetString("phoneNumber"),
                            username = reader.GetString("username")
                        });
                    }
                }
            }
            return users;
        }

        public async Task<bool> UpdateUser(Users users)
        {
            using (MySqlConnection c = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "update users set firstName=@firstName,lastName=@lastName,isActive=@isActive,password=@password,phoneNumber=@phoneNumber,username=@username where user_id=@user_id";
                    MySqlCommand command = new MySqlCommand(query, c);
                    
                    command.Parameters.AddWithValue("@firstName", users.firstName);
                    command.Parameters.AddWithValue("@lastName", users.lastName);
                    command.Parameters.AddWithValue("@isActive", users.isActive);
                    command.Parameters.AddWithValue("@password", users.password);
                    command.Parameters.AddWithValue("@phoneNumber", users.phoneNumber);
                    command.Parameters.AddWithValue("@username", users.username);
                    command.Parameters.AddWithValue("@user_id", users.user_id);
                    await c.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
    }
}
