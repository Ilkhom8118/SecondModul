using Repo_Service_pattern.DataAccess.Entity;
using System.Text.Json;

namespace Repo_Service_pattern.Repoistroy;

public class StudentRepositorie : IStudentRepositorie
{
    private string Path;
    private List<Student> Students;

    public StudentRepositorie()
    {
        Path = "../../../DataAccess/Data/Student.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        Students = new List<Student>();
        Students = GetAllStudent();
    }
    private void SaveIformation()
    {
        var json = JsonSerializer.Serialize(Students);
        File.WriteAllText(Path, json);
    }
    private List<Student> GetAllStudent()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Student>>(json);
        return file;
    }
    public Student AddedStudent(Student added)
    {
        Students.Add(added);
        SaveIformation();
        return added;
    }


    public void DeletedStudent(Guid id)
    {
        var deleteId = GetById(id);
        Students.Remove(deleteId);
        SaveIformation();
    }

    public Student GetById(Guid id)
    {
        foreach (var student in Students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        throw new Exception("Student not find!!!");
    }

    public List<Student> ReadStudent()
    {
        return Students;
    }

    public void UpdatedStudent(Student obj)
    {
        var id = GetById(obj.Id);
        Students[Students.IndexOf(id)] = obj;
        SaveIformation();
    }
    public void CheckUserNameEmailPhone(string email, string userName, string phone)
    {
        foreach (var student in Students)
        {
            if (student.Email == email || student.UserName == userName || student.Phone == phone)
            {
                throw new Exception("Invalid Student");
            }
        }
    }
}
