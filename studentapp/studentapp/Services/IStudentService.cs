using studentapp.Models;
using System.Reflection.Metadata.Ecma335;
namespace studentapp.Services
{
    public interface IStudentService
    {
        List<StudentViewModel> GetStudents();
      bool Insert(StudentViewModel student);
    }
    
}
