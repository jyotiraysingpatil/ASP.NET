using Student_Management.Entities;
namespace Student_Management.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        List<Student> GetStudentById(int id);

        Boolean InsertStudentDetails(Student student);
        Boolean UpdateStudentDetails(int id,Student student);

        Boolean DeleteStudentDetails(int id);

        List<Student> searchStudnt(string searchTearm);
        List<Student> SortStudents(string sortBy, bool ascending);


    }
}
