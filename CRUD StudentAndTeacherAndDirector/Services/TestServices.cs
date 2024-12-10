using CRUD_StudentAndTeacherAndDirector.Models;
using System.Text.Json;

namespace CRUD_StudentAndTeacherAndDirector.Services;

public class TestServices
{
    private string testFilePath;
    public TestServices()
    {
        testFilePath = "../../../Data/Test.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
    }
    public void SaveInformation(List<Test> tests)
    {
        var testJson = JsonSerializer.Serialize(tests);
        File.WriteAllText(testFilePath, testJson);
    }

    private List<Test> GetAllTests()
    {
        var file = File.ReadAllText(testFilePath);
        var testsFromDb = JsonSerializer.Deserialize<List<Test>>(file);
        return testsFromDb;
    }
    public Test AddTest(Test added)
    {
        added.Id = Guid.NewGuid();
        var tests = GetAllTests();
        tests.Add(added);
        SaveInformation(tests);
        return added;
    }
    public Test GetById(Guid id)
    {
        var tests = GetAllTests();
        foreach (var test in tests)
        {
            if (test.Id == id)
            {
                return test;
            }
        }
        return null;
    }
    public bool DeleteTest(Guid id)
    {
        var tests = GetAllTests();
        var testId = GetById(id);
        if (testId is null)
        {
            return false;
        }
        foreach (var obj in tests)
        {
            if (obj.Id == id)
            {
                tests.Remove(obj);
                break;
            }
        }
        SaveInformation(tests);
        return true;
    }
    public bool UpdateTest(Test obj)
    {
        var tests = GetAllTests();
        var testId = GetById(obj.Id);
        if (testId is null)
        {
            return false;
        }
        for (var i = 0; i < tests.Count; i++)
        {
            if (tests[i].Id == obj.Id)
            {
                tests[i] = obj;
            }
        }
        SaveInformation(tests);
        return true;
    }
    public List<Test> GetAll()
    {
        return GetAllTests();
    }
}
