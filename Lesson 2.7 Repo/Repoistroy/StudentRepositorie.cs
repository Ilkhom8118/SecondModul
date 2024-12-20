using Lesson_2._7_Repo.DataAccess.Entity;
using System.Text.Json;

namespace Lesson_2._7_Repo.Repoistroy;
public class StudentRepositorie : IStudentRepositorie
{
    private string Path;
    private List<Stundent> Stundents;
    public StudentRepositorie()
    {
        Path = "../../../DataAccess/Data/Student.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        Stundents = new List<Stundent>();
        Stundents = GetAllStudents();

    }
    private void SaveInformation()
    {
        var json = JsonSerializer.Serialize(Stundents);
        File.WriteAllText(Path, json);
    }
    private List<Stundent> GetAllStudents()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<Stundent>>(json);
        return file;
    }

    public Stundent AddStudent(Stundent added)
    {
        Stundents.Add(added);
        SaveInformation();
        return added;
    }

    public void DeleteStudent(Guid id)
    {
        var deleteId = GetById(id);
        Stundents.Remove(deleteId);
        SaveInformation();
    }

    public List<Stundent> GetAllStudent()
    {
        return GetAllStudents();
    }

    public Stundent GetById(Guid id)
    {
        foreach (var student in Stundents)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }

    public void UpdateStudent(Stundent obj)
    {
        var id = GetById(obj.Id);
        Stundents[Stundents.IndexOf(id)] = obj;
        SaveInformation();
    }
}
