using StudentManagement.Entities;
using StudentManagement.Services;
using StudentManagement.Repository;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public List<Student> GetAll()
    {
        return _studentRepository.GetAll();
    }

    public Student GetById(int id)
    {
        return _studentRepository.GetById(id);
    }

    public bool UpdateStatus(int id, string status)
    {
        return _studentRepository.UpdateStatus(id, status);
    }

    public bool DeleteStatus(int id)
    {
        return _studentRepository.DeleteStatus(id);
    } }