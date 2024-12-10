using StudnetTeacherDirector.Models;

namespace StudnetTeacherDirector.Services;

public interface ITestServices
{
    public Test AddTest(Test added);
    public Test GetById(Guid id);
    public bool DeletedTest(Guid id);
    public bool UpdatedTest(Test obj);
    public List<Test> GetAll();
}