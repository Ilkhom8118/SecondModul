using StudnetTeacherDirector.Models;

namespace StudnetTeacherDirector.Services;

public interface ITeacherServices
{
    public Teacher AddTeacher(Teacher added);
    public Teacher GetById(Guid id);
    public bool DeletedTeacher(Guid id);
    public bool UpdatedTeacher(Teacher obj);
    public List<Teacher> GetAll();
}
