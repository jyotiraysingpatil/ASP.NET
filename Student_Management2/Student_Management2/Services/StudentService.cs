using Student_Management2.Models;
using Student_Management2.Repository;

namespace Student_Management2.Services
{
    public class StudentService : IStudentService
    {

        public List<Student> GetAll()
        {
         IStudentRepository studentRepository=new studentRepository();  
            return studentRepository.GetAll();

        }
    }
}
