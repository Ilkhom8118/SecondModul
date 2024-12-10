using StudnetTeacherDirector.Models;
using System.Text.Json;

namespace StudnetTeacherDirector.Services;

public class StudentServices : IStudentServices
{
    private string StudentFilePath;
    public StudentServices()
    {
        StudentFilePath = "../../../Data/Student.json";
        if (File.Exists(StudentFilePath) is false)
        {
            File.WriteAllText(StudentFilePath, "[]");
        }
    }
    public void SaveInformation(List<Student> student)
    {
        var studnetJson = JsonSerializer.Serialize(student);
        File.WriteAllText(StudentFilePath, studnetJson);
    }
    private List<Student> GetAllStudent()
    {
        var studentJson = File.ReadAllText(StudentFilePath);
        var studentFile = JsonSerializer.Deserialize<List<Student>>(studentJson);
        return studentFile;
    }

    public Student AddStudent(Student added)
    {
        var list = GetAllStudent();
        added.Id = Guid.NewGuid();
        list.Add(added);
        SaveInformation(list);
        return added;
    }
    public Student GetById(Guid id)
    {
        var list = GetAllStudent();
        foreach (var student in list)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }
    public bool DeletedStudent(Guid id)
    {
        var list = GetAllStudent();
        var studentId = GetById(id);
        if (studentId is null)
        {
            return false;
        }
        foreach (var obj in list)
        {
            if (obj.Id == id)
            {
                list.Remove(obj);
                break;
            }
        }
        SaveInformation(list);
        return true;
    }
    public bool UpdatedStudent(Student obj)
    {
        var list = GetAllStudent();
        var id = GetById(obj.Id);
        if (id is null)
        {
            return false;
        }
        for (var i = 0; i < list.Count; i++)
        {
            if (obj.Id == list[i].Id)
            {
                list[i] = obj;
            }
        }
        SaveInformation(list);
        return true;
    }
    public List<Student> GetAll()
    {
        return GetAllStudent();
    }
}
