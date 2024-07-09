using Student_Management.Entities;
using Student_Management.Repository;

namespace Student_Management.Services
{
    public class StudentService : IStudentServicecs
    {
        public bool DeleteStudentDetails(int id)
        {
           IStudentRepository studentRepository = new StudentRepository();  
            return studentRepository.DeleteStudentDetails(id);
        }

        public List<Student> GetAll()
        {
           IStudentRepository studentRepository = new StudentRepository();
            return studentRepository.GetAll();
        }

        public List<Student> GetStudentById(int id)
        {
           IStudentRepository studentRepository=new StudentRepository();    
            return studentRepository.GetStudentById(id);
        }

        public bool InsertStudentDetails(Student student)
        {
          IStudentRepository studentRepository=new StudentRepository();
            return studentRepository.InsertStudentDetails(student);
        }

        public List<Student> searchStudnt(string searchTearm)
        {
            IStudentRepository studentRepository=new StudentRepository();
            return studentRepository.searchStudnt(searchTearm);
        }

        public bool UpdateStudentDetails(int id, Student student)
        {
            IStudentRepository studentRepository = new StudentRepository();
            return studentRepository.UpdateStudentDetails(id,student);

        }

        public List<Student> SortStudents(string sortBy, bool ascending)
        {
            IStudentRepository studentRepository = new StudentRepository();
            return studentRepository.SortStudents(sortBy, ascending);
        }
    
}
}
