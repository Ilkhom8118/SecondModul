using CRUD_StudentAndTeacherAndDirector.Models;
using System.Text.Json;

namespace CRUD_StudentAndTeacherAndDirector.Services;

public class StudentServices
{
    private string studentFilePath;



    public StudentServices()
    {
        studentFilePath = "../../../Data/Student.json";
        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
    }

    public void SaveStudentServices(List<Student> student)
    {
        var jsonFile = JsonSerializer.Serialize(student);
        File.WriteAllText(studentFilePath, jsonFile);
    }
    private List<Student> GetAllStudent()
    {
        var studentJson = File.ReadAllText(studentFilePath);
        var studentList = JsonSerializer.Deserialize<List<Student>>(studentJson);
        return studentList;
    }
    public Student AddStudent(Student added)
    {
        added.Id = Guid.NewGuid();
        var students = GetAllStudent();
        students.Add(added);
        SaveStudentServices(students);
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
    public bool DeleteStudent(Guid id)
    {
        var list = GetAllStudent();
        var res = GetById(id);
        if (res is null)
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
        SaveStudentServices(list);
        return true;
    }
    public bool UpdateStudent(Student obj)
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
        SaveStudentServices(list);
        return true;
    }
    public List<Student> GetAll()
    {
        return GetAllStudent();
    }
    public Student GetStudentByUser(string userName, string password)
    {
        var list = GetAllStudent();
        foreach (var studnet in list)
        {
            if (studnet.UserName == userName && studnet.Password == password)
            {
                return studnet;
            }
        }
        return null;
    }
}
