using CRUD_StudentAndTeacherAndDirector.Models;
using System.Text.Json;

namespace CRUD_StudentAndTeacherAndDirector.Servicesl;

public class TeachersServices
{
    //private string teacherFilePath;
    //public TeachersServices()
    //{
    //    teacherFilePath = "../../../Data/Teachers.json";
    //    if (File.Exists(teacherFilePath) is false)
    //    {
    //        File.WriteAllText(teacherFilePath, "[]");
    //    }

    //}

    //private void SaveInformation(List<Teacher> teachers)
    //{
    //    var teachersJson = JsonSerializer.Serialize(teachers);
    //    File.WriteAllText(teacherFilePath, teachersJson);
    //}
    //private List<Teacher> GetAllTeachers()
    //{
    //    var teachersFile = File.ReadAllText(teacherFilePath);
    //    var teachersList = JsonSerializer.Deserialize<List<Teacher>>(teachersFile);
    //    return teachersList;
    //}
    //public Teacher AddTeacher(Teacher added)
    //{
    //    var list = GetAllTeachers();
    //    added.Id = Guid.NewGuid();
    //    list.Add(added);
    //    SaveInformation(list);
    //    return added;
    //}
    //public Teacher GetById(Guid id)
    //{
    //    var list = GetAllTeachers();
    //    foreach (var teacher in list)
    //    {
    //        if (teacher.Id == id)
    //        {
    //            return teacher;
    //        }
    //    }
    //    return null;
    //}
    //public bool DeleteTeacher(Guid id)
    //{
    //    var list = GetAllTeachers();
    //    var res = GetById(id);
    //    if (res is null)
    //    {
    //        return false;
    //    }

    //    list.Remove(res);

    //    SaveInformation(list);
    //    return true;
    //}
    //public bool UpdateTeacher(Teacher obj)
    //{
    //    var list = GetAllTeachers();
    //    var res = GetById(obj.Id);
    //    if (res is null)
    //    {
    //        return false;
    //    }

    //    for (var i = 0; i < list.Count; i++)
    //    {
    //        if (list[i].Id == obj.Id)
    //        {
    //            list[i]=obj;
    //            break;
    //        }
    //    }
    //    SaveInformation(list);
    //    return true;
    //}
    //public List<Teacher> GetAll()
    //{
    //    return GetAllTeachers();
    //}

    //private string teachersFilePath;
    //public TeachersServices()
    //{
    //    teachersFilePath = "../../../Data/Teachers.json";
    //    File.WriteAllText(teachersFilePath, "[]");
    //}
    //private void SaveInformation(List<Teacher> teacher)
    //{
    //    var jsonTeacher = JsonSerializer.Serialize(teacher);
    //    File.WriteAllText(teachersFilePath, jsonTeacher);
    //}
    //private List<Teacher> GetAllTeacher()
    //{
    //    var teacherFile = File.ReadAllText(teachersFilePath);
    //    var teacherList = JsonSerializer.Deserialize<List<Teacher>>(teacherFile);
    //    return teacherList;
    //}
    //public Teacher AddTeacher(Teacher added)
    //{
    //    var list = GetAllTeacher();
    //    added.Id = Guid.NewGuid();
    //    list.Add(added);
    //    SaveInformation(list);
    //    return added;
    //}
    //public Teacher GetById(Guid id)
    //{
    //    var list = GetAllTeacher();
    //    foreach (var teacher in list)
    //    {
    //        if (teacher.Id == id)
    //        {
    //            return teacher;
    //        }
    //    }
    //    return null;
    //}
    //public bool DeleteTeacher(Guid id)
    //{
    //    var list = GetAllTeacher();
    //    var res = GetById(id);
    //    if (res is null)
    //    {
    //        return false;
    //    }
    //    list.Remove(res);
    //    SaveInformation(list);
    //    return true;
    //}
    //public bool UpdateTeacher(Teacher obj)
    //{
    //    var list = GetAllTeacher();
    //    var res = GetById(obj.Id);
    //    if (res is null)
    //    {
    //        return false;
    //    }
    //    for (var i = 0; i < list.Count; i++)
    //    {
    //        if (obj.Id == list[i].Id)
    //        {
    //            list[i] = obj;
    //        }
    //    }
    //    SaveInformation(list);
    //    return true;
    //}
    //public List<Teacher> GetAll()
    //{
    //    return GetAllTeacher();
    //}
    private string teachersFilePath;
    public string passwordTeacher = "teacher";
    public string usingLogin = "teacher";

    public string directorPassword = "Director";
    public string directorUsername = "Director";

    public TeachersServices()
    {
        teachersFilePath = "../../../Data/Teachers.json";
        if (File.Exists(teachersFilePath) is false)
        {
            File.WriteAllText(teachersFilePath, "[]");
        }
    }
    private void SaveInformation(List<Teacher> teacher)
    {
        var teacherJson = JsonSerializer.Serialize(teacher);
        File.WriteAllText(teachersFilePath, teacherJson);
    }
    private List<Teacher> GetAllTeacher()
    {
        var jsonFile = File.ReadAllText(teachersFilePath);
        var jsonList = JsonSerializer.Deserialize<List<Teacher>>(jsonFile);
        return jsonList;
    }
    public Teacher AddTeacher(Teacher added)
    {
        var list = GetAllTeacher();
        added.Id = Guid.NewGuid();
        list.Add(added);
        SaveInformation(list);
        return added;
    }
    public Teacher GetById(Guid id)
    {
        var list = GetAllTeacher();
        foreach (var teacher in list)
        {
            if (teacher.Id == id)
            {
                return teacher;
            }
        }
        return null;
    }
    public bool DeleteTeacher(Guid id)
    {
        var list = GetAllTeacher();
        var res = GetById(id);
        if (res is null)
        {
            return false;
        }
        list.Remove(res);
        SaveInformation(list);
        return true;
    }
    public bool UpdateTeacher(Teacher obj)
    {
        var list = GetAllTeacher();
        var res = GetById(obj.Id);
        if (res is null)
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
    public List<Teacher> GetAll()
    {
        return GetAllTeacher();
    }
}

