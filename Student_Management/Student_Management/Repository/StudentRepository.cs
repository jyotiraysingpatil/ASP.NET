using Microsoft.AspNetCore.Mvc;
using Student_Management.Entities;

namespace Student_Management.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public bool DeleteStudentDetails(int id)
        {
            using (var context = new StudentContext())
            {
                var remove= from stud in context.student
                             where stud.id == id
                             select stud;
                context.student.RemoveRange(remove);
               context.SaveChanges();
            }
            return true;
        }

        public List<Student> GetAll()
        {
            using (var context = new StudentContext())
            {
                var students = from stud in context.student select stud;
                return students.ToList<Student>();
            }
        }

        
        public List<Student> GetStudentById(int id)
        {
            using (var context = new StudentContext())
            {
                var students = from stud in context.student
                               where stud.id == id
                               select stud;
                return students.ToList<Student>();
            }
        }

        public bool InsertStudentDetails(Student student)
        {
           using(var context =new StudentContext())
            {
                context.student.Add(student);
                context.SaveChanges(true);
                return true;
            }
        }

        public List<Student> searchStudnt(string searchTearm)
        {
            using (var context=new StudentContext())
            {
                var students=from stud in context.student 
                             where stud.name.Contains(searchTearm)||
                                   stud.email.Contains(searchTearm)||
                                   stud.address.Contains(searchTearm)
                             select stud;
                return students.ToList<Student>();
            }
            
        }

        public bool UpdateStudentDetails(int id, Student student)
        {
          using(var context=new StudentContext())
            {
                context.student.UpdateRange(student);
                context.SaveChanges(true);

            }
          return true;
        }

        public List<Student> SortStudents(string sortBy, bool ascending)
        {
            using (var context = new StudentContext())
            {
                var students = from stud in context.student select stud;

                switch (sortBy.ToLower())
                {
                    case "name":
                        students = ascending ? students.OrderBy(s => s.name) : students.OrderByDescending(s => s.name);
                        break;
                    case "email":
                        students = ascending ? students.OrderBy(s => s.email) : students.OrderByDescending(s => s.email);
                        break;
                    case "admissiondate":
                        students = ascending ? students.OrderBy(s => s.admission_date) : students.OrderByDescending(s => s.admission_date);
                        break;
                    case "fees":
                        students = ascending ? students.OrderBy(s => s.fees) : students.OrderByDescending(s => s.fees);
                        break;
                    default:
                        students = ascending ? students.OrderBy(s => s.id) : students.OrderByDescending(s => s.id);
                        break;
                }

                return students.ToList<Student>();
            }
        }
    }
}
