using Try.Entities;

namespace Try.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<bool> Insert(Student student); 
        Task<bool> Update(Student student);
        Task<bool> Delete(int id);
    }
}
