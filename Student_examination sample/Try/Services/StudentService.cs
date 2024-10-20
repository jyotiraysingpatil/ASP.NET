using Try.Entities;
using Try.Repository;

namespace Try.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Student>> GetAll() => await _repo.GetAll();
        public async Task<bool> Insert(Student student) => await _repo.Insert(student);
        public async Task<bool> Update(Student studen
            )=> await _repo.Update(studen);
        public async Task<bool> Delete(int id)=>await _repo.
            Delete(id);
    }
}
