using StudnetTeacherDirector.Models;
using System.Text.Json;

namespace StudnetTeacherDirector.Services;

public class TestServices : ITestServices
{
    private string TestFilePath;

    public TestServices()
    {
        TestFilePath = "../../../Data/Test.json";
        if (File.Exists(TestFilePath) is false)
        {
            File.WriteAllText(TestFilePath, "[]");
        }
    }
    public void SaveInformation(List<Test> test)
    {
        var testJson = JsonSerializer.Serialize(test);
        File.WriteAllText(TestFilePath, testJson);
    }
    private List<Test> GetAllTest()
    {
        var testJson = File.ReadAllText(TestFilePath);
        var testFile = JsonSerializer.Deserialize<List<Test>>(testJson);
        return testFile;
    }
    public Test AddTest(Test added)
    {
        var list = GetAllTest();
        added.Id = Guid.NewGuid();
        list.Add(added);
        SaveInformation(list);
        return added;
    }

    public bool DeletedTest(Guid id)
    {
        var list = GetAllTest();
        var testId = GetById(id);
        if (testId is null)
        {
            return false;
        }
        foreach (var test in list)
        {
            if (test.Id == id)
            {
                list.Remove(test);
                break;
            }
        }
        SaveInformation(list);
        return true;
    }

    public List<Test> GetAll()
    {
        return GetAllTest();
    }

    public Test GetById(Guid id)
    {
        var list = GetAllTest();
        foreach (var test in list)
        {
            if (test.Id == id)
            {
                return test;
            }
        }
        return null;
    }

    public bool UpdatedTest(Test obj)
    {
        var list = GetAllTest();
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
}
