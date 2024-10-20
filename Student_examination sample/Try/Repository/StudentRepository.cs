using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Try.Entities;

namespace Try.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Student>> GetAll()
        {
            List<Student> students = new List<Student>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM students";
                MySqlCommand command = new MySqlCommand(query, connection);

                await connection.OpenAsync();

                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        students.Add(new Student
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            age = reader.GetInt32("age")
                        });
                    }
                }
            }

            return students;
        }

        public async Task<bool> Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "DELETE FROM students WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) for debugging purposes
                    // For example: _logger.LogError(ex, "Error deleting student with ID {id}", id);
                    return false;
                }
            }
        }

        public async Task<bool> Insert(Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO students (id, name, age) VALUES (@id, @name, @age)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", student.id);
                    command.Parameters.AddWithValue("@name", student.name);
                    command.Parameters.AddWithValue("@age", student.age);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) for debugging purposes
                    // For example: _logger.LogError(ex, "Error inserting student with ID {id}", student.id);
                    return false;
                }
            }
        }

        public async Task<bool> Update(Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE students SET name = @name, age = @age WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", student.name);
                    command.Parameters.AddWithValue("@age", student.age);
                    command.Parameters.AddWithValue("@id", student.id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) for debugging purposes
                    // For example: _logger.LogError(ex, "Error updating student with ID {id}", student.id);
                    return false;
                }
            }
        }
    }
}
