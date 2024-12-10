using StudnetTeacherDirector.Models;

namespace StudnetTeacherDirector.Services;

public interface IStudentServices
{
    public Student AddStudent(Student added);
    public Student GetById(Guid id);
    public bool DeletedStudent(Guid id);
    public bool UpdatedStudent(Student obj);
    public List<Student> GetAll();
}
