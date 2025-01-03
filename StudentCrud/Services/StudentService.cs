using StudentCrud.DataAccess.Entity;
using StudentCrud.Repoistory;
using StudentCrud.Services.DTOs;

namespace StudentCrud.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepo studentRepo;
    public StudentService()
    {
        studentRepo = new StudentRepo();
    }
    public bool ValidateStudentCreateDto(StudentCreateDto obj)
    {
        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 50)
        {
            return false;
        }
        if (obj.Age < 15 || obj.Age > 65)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || obj.Email.EndsWith("@gmail.com") ||
            obj.Email.Length < 100 || obj.Email.Length >= 10)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Phone) || obj.Phone.Length > 13 || obj.Phone.StartsWith("+998"))
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length >= 8)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.UserName) || obj.UserName.Length < 1)
        {
            return false;
        }
        return true;
    }

    private Student ConvertStudentEntity(StudentCreateDto obj)
    {
        var student = new Student()
        {
            Age = obj.Age,
            Email = obj.Email,
            Phone = obj.Phone,
            LastName = obj.LastName,
            Password = obj.Password,
            FirstName = obj.FirstName,
            Id = Guid.NewGuid(),
            UserName = obj.UserName,
        };
        return student;
    }
    private Student ConvertStudentEntity(StudentUpdateDto obj)
    {
        var student = new Student()
        {
            Id = obj.Id,
            Age = obj.Age,
            Email = obj.Email,
            Phone = obj.Phone,
            LastName = obj.LastName,
            Password = obj.Password,
            FirstName = obj.FirstName,
            UserName = obj.UserName,
        };
        return student;
    }
    private StudentGetDto ConvertToDto(Student obj)
    {
        var dto = new StudentGetDto()
        {
            Id = obj.Id,
            Age = obj.Age,
            Email = obj.Email,
            Phone = obj.Phone,
            LastName = obj.LastName,
            FirstName = obj.FirstName,
            UserName = obj.UserName,
        };
        return dto;
    }
    public StudentGetDto CreateStduent(StudentCreateDto student)
    {
        var studentCDto = ConvertStudentEntity(student);
        var dto = ConvertToDto(studentCDto);
        return dto;
    }

    public void DeleteStudent(Guid id)
    {
        studentRepo.DeleteStudent(id);
    }

    public List<StudentGetDto> GetAllStudent()
    {
        var list = studentRepo.GetAllStudent();
        var listSGD = new List<StudentGetDto>();
        foreach (var student in list)
        {
            var stnd = ConvertToDto(student);
            listSGD.Add(stnd);
        }
        return listSGD;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        var stnd = ConvertStudentEntity(student);
        studentRepo.UpdateStudent(stnd);
    }
}
