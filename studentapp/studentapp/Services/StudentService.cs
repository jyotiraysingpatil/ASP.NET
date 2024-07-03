using studentapp.Models;

namespace studentapp.Services
{
    public class StudentService : IStudentService
    {
        List<StudentViewModel> IStudentService.GetStudents()
        {
            return new List<StudentViewModel>();
        }

        public Boolean Insert(StudentViewModel student)
        {
            return true;
        }
        public Boolean Update(StudentViewModel student)
        {
            return true;
        }
        public Boolean Delete(StudentViewModel student)
        {
            return true;
        }
        public Boolean DeleteAll()
        {
            return true;
        }

        
    }
}