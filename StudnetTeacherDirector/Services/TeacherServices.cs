using StudnetTeacherDirector.Models;
using System.Text.Json;

namespace StudnetTeacherDirector.Services;

public class TeacherServices : ITeacherServices
{
    private string TeacherFilePAth;
    public TeacherServices()
    {
        TeacherFilePAth = "../../../Data/Teacher.json";
        if (File.Exists(TeacherFilePAth) is false)
        {
            File.WriteAllText(TeacherFilePAth, "[]");
        }
    }

    public void SaveInformation(List<Teacher> teacher)
    {
        var teacherJson = JsonSerializer.Serialize(teacher);
        File.WriteAllText(TeacherFilePAth, teacherJson);
    }
    private List<Teacher> GetAllTeachers()
    {
        var teacherJson = File.ReadAllText(TeacherFilePAth);
        var teacherFile = JsonSerializer.Deserialize<List<Teacher>>(teacherJson);
        return teacherFile;
    }

    public Teacher AddTeacher(Teacher added)
    {
        var list = GetAllTeachers();
        added.Id = Guid.NewGuid();
        list.Add(added);
        SaveInformation(list);
        return added;
    }
    public Teacher GetById(Guid id)
    {
        var list = GetAllTeachers();
        foreach (var teacher in list)
        {
            if (teacher.Id == id)
            {
                return teacher;
            }
        }
        return null;
    }
    public bool DeletedTeacher(Guid id)
    {
        var list = GetAllTeachers();
        var teacherId = GetById(id);
        if (teacherId is null)
        {
            return false;
        }
        foreach (var teacher in list)
        {
            if (teacher.Id == id)
            {
                list.Remove(teacher);
                break;
            }
        }
        SaveInformation(list);
        return true;
    }
    public bool UpdatedTeacher(Teacher obj)
    {
        var list = GetAllTeachers();
        var id = GetById(obj.Id);
        if (id is null)
        {
            return false;
        }
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].Id == obj.Id)
            {
                list[i] = obj;
            }
        }
        SaveInformation(list);
        return true;
    }
    public List<Teacher> GetAll()
    {
        return GetAllTeachers();
    }
}
