using Try.Entities;

namespace Try.Repository
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAll();
        Task<bool> Insert(Exam exam);
        Task<bool> Update(Exam exam);
        Task<bool> Delete(int exam_id);

    }
}
