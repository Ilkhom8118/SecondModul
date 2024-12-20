using Lesson_2._7_Repo.DataAccess.Entity;
using Lesson_2._7_Repo.Repoistroy;
using Lesson_2._7_Repo.Services.DTOs;

namespace Lesson_2._7_Repo.Services;

public class StudentServices : IStudentService
{
    private readonly StudentRepositorie StudentRepo;
    public StudentServices()
    {
        StudentRepo = new StudentRepositorie();
    }
    private Stundent ConvertToStudent(StudentCreateDto studentCreate)
    {
        return new Stundent
        {
            FirstName = studentCreate.FirstName,
            LastName = studentCreate.LastName,
            Age = studentCreate.Age,
            Email = studentCreate.Email,
            Gander = studentCreate.Gander,
            Degree = studentCreate.Degree,
        };
    }
    private Stundent ConvertToStudent(StudentUpdateDto studentUpdate)
    {
        return new Stundent
        {
            Id = studentUpdate.Id,
            FirstName = studentUpdate.FirstName,
            LastName = studentUpdate.LastName,
            Age = studentUpdate.Age,
            Email = studentUpdate.Email,
            Password = studentUpdate.Password,
            Gander = studentUpdate.Gander,
            Degree = studentUpdate.Degree,
        };
    }
    private StudentGetDto ConvertToEntity(Stundent student)
    {
        return new StudentGetDto
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Gander = student.Gander,
            Degree = student.Degree,
        };
    }
    private bool ValidateStudentCreateDto(StudentCreateDto obj)
    {
        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 20)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 20)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || !obj.Email.EndsWith("@gmail.com") ||
            obj.Email.Length > 50 || obj.Email.Length < 10)
        {
            return false;
        }
        if (obj.Age > 15 || obj.Age < 55)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length > 50 || obj.Password.Length < 8)
        {
            return false;
        }
        return true;
    }

    public void DeleteStudent(Guid id)
    {
        StudentRepo.DeleteStudent(id);
    }

    public StudentGetDto GetById(Guid id)
    {
        var byId = StudentRepo.GetById(id);
        var SGD = ConvertToEntity(byId);
        return SGD;
    }

    public List<StudentGetDto> GetStudentsAll()
    {
        var list = new List<StudentGetDto>();
        var stnd = StudentRepo.GetAllStudent();
        foreach (var student in stnd)
        {
            var LSTGD = ConvertToEntity(student);
            list.Add(LSTGD);
        }
        return list;
    }

    public bool StudentCreateDto(StudentCreateDto studentCreateDto)
    {
        var res = ValidateStudentCreateDto(studentCreateDto);
        if (res is true)
        {
            var student = ConvertToStudent(studentCreateDto);
            StudentRepo.AddStudent(student);
            return true;
        }
        return false;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        var stnd = ConvertToStudent(student);
        StudentRepo.UpdateStudent(stnd);
    }
}
