using Lesson_2._8_CRUD.DataAccess.Entity;
using System.Text.Json;

namespace Lesson_2._8_CRUD.Repoistory;

public class SchoolRepoistory : ISchoolRepoistory
{
    private string Path;
    private List<School> Schools;
    public SchoolRepoistory()
    {
        Path = "../../../DataAccess/Data/School.json";
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        Schools = new List<School>();
        Schools = GetAllSchools();
    }

    private void SaveInformation()
    {
        var json = JsonSerializer.Serialize(Schools);
        File.WriteAllText(Path, json);
    }
    private List<School> GetAllSchools()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<School>>(json);
        return file;
    }
    public School AddSchool(School added)
    {
        Schools.Add(added);
        SaveInformation();
        return added;
    }

    public bool DeleteSchool(Guid id)
    {
        var list = GetAllSchools();
        var guId = GetById(id);
        if (guId is null)
        {
            return false;
        }
        foreach (var school in list)
        {
            if (school.Id == guId.Id)
            {
                list.Remove(school);
            }
        }
        SaveInformation();
        return true;
    }

    public List<School> GetAllSchool()
    {
        return GetAllSchools();
    }

    public School GetById(Guid id)
    {
        foreach (var school in Schools)
        {
            if (school.Id == id)
            {
                return school;
            }
        }
        return null;
    }
    public void UpdateSchool(School obj)
    {
        var id = GetById(obj.Id);
        var res = Schools[Schools.IndexOf(id)] = obj;
        SaveInformation();
    }
}
