using StudentManagement.Entities;
namespace StudentManagement.Repository
{
    public interface IStudentRepository
    {
        bool DeleteStatus(int id);
        List<Student> GetAll();
        Student GetById(int id);
        bool UpdateStatus(int id, string status);

       List<Student> Sort(string sortBy, bool ascending);



    }
}
