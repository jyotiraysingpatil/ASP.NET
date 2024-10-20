using Try.Entities;
using Try.Repository;

namespace Try.Services
{
    public class ExamService: IExamService
    {
        private readonly IExamRepository examRepository;
        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public async  Task<List<Exam>> GetAll()=> await examRepository.GetAll();                          
        public async Task<bool> Insert(Exam exam) => await examRepository.Insert(exam);

        public async Task<bool> Update(Exam exam) => await examRepository.Update(exam);
        public async Task<bool> Delete(int exam_id)=>await examRepository.Delete(exam_id);
    }
}
