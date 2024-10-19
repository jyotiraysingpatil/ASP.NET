using Student_Management2.Models;
using Student_Management2.Services;

namespace Student_Management2.Repository
{
    public class studentRepository : IStudentRepository
    {
        public List<Student> GetAll()
        {
            using(var context=new StudentContext())
            {
                var students=from stud in context.Students
                             select stud;
                return students.ToList<Student>();
            }
            
        }
    }
}
