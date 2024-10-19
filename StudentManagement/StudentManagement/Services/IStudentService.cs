using StudentManagement.Entities;
namespace StudentManagement.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        bool UpdateStatus(int id, string status);
        bool DeleteStatus(int id);
     
    }
}
