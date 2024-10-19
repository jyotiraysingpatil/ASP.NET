using StudentManagement.Entities;

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAll()
        {
            using (var context = new StudentContext())
            {
                return context.Students.ToList();
            }
        }

        public Student GetById(int id)
        {
            using (var context = new StudentContext())
            {
                return context.Students.Find(id);
            }
        }

        public bool UpdateStatus(int id, string status)
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.Find(id);
                if (student == null)
                {
                    return false;
                }

                student.status = status;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteStatus(int id)
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.Find(id);
                if (student == null)
                {
                    return false;
                }

                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }
        }

        public List<Student> Sort(string sortBy, bool ascending)
        {
          
            }
        }
    }
}