using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using Try.Entities;

namespace Try.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ExamRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> Delete(int exam_id)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "delete from exam where exam_id=@exam_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@exam_id", exam_id);
                    await connection.OpenAsync();
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

        public async Task<List<Exam>> GetAll()
        {
            List<Exam> list = new List<Exam>();
            string query = "SELECT * FROM exam";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Exam exam = new Exam
                            {
                                exam_id = reader.GetInt32("exam_id"),
                                exam_name = reader.GetString("exam_name"),
                                subject = reader.GetString("subject"),
                                sid = reader.GetInt32("sid")
                            };
                            list.Add(exam);
                        }
                    }
                }
            }
            return list;
        }



        public async Task<bool> Update(Exam exam)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE exam SET exam_name=@exam_name, subject=@subject, sid=@sid WHERE exam_id=@exam_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@exam_name", exam.exam_name);
                    command.Parameters.AddWithValue("@subject", exam.subject);
                    command.Parameters.AddWithValue("@sid", exam.sid);
                    command.Parameters.AddWithValue("@exam_id", exam.exam_id); // This was missing in your original code
                    await connection.OpenAsync();
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



        public async Task<bool> Insert(Exam exam)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "INSERT INTO exam (exam_id, exam_name, subject, sid) VALUES (@exam_id, @exam_name, @subject, @sid)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@exam_id", exam.exam_id);
                    command.Parameters.AddWithValue("@exam_name", exam.exam_name);
                    command.Parameters.AddWithValue("@subject", exam.subject);
                    command.Parameters.AddWithValue("@sid", exam.sid);
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
