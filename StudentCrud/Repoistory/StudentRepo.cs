using StudentCrud.DataAccess.Entity;
using System.Text.Json;

namespace StudentCrud.Repoistory;

public class StudentService : IStudentService
{
    private string Path;
    private List<Student> students;
    public StudentService()
    {
        Path = "../../../DataAccess/Data/Student.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        students = new List<Student>();
    }
    private void SaveInformation(List<Student> student)
    {
        var json = JsonSerializer.Serialize(student);
        File.WriteAllText(Path, json);
    }

    private List<Student> GetAll()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Student>>(json);
        return file;
    }

    public Student AddStudent(Student added)
    {
        added.Id = Guid.NewGuid();
        students.Add(added);
        SaveInformation(students);
        return added;
    }

    public bool DeleteStudent(Guid id)
    {
        var guId = GetByStudentId(id);
        if (guId is null)
        {
            return false;
        }
        students.Remove(guId);
        SaveInformation(students);
        return true;
    }

    public List<Student> GetAllStudent()
    {
        return GetAll();
    }

    public Student GetByStudentId(Guid id)
    {
        foreach (var student in students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }

    public bool UpdateStudent(Student obj)
    {
        var id = GetByStudentId(obj.Id);
        if (id is null)
        {
            return false;
        }
        students[students.IndexOf(id)] = obj;
        SaveInformation(students);
        return true;
    }
}
