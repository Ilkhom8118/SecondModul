using Repo_Service_pattern.DataAccess.Entity;
using Repo_Service_pattern.Repoistroy;
using Repo_Service_pattern.Services.DTOs;

namespace Repo_Service_pattern.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepositorie StudentRepositorie;
    public StudentService()
    {
        StudentRepositorie = new StudentRepositorie();
    }
    private Student ConvertToStudent(StudentUpdateDto studentDto)
    {
        return new Student
        {
            Id = studentDto.Id,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            Degrees = studentDto.Degrees,
            Gender = studentDto.Gender
        };
    }
    private Student ConvertToStudent(StudentCreateDto studentCreateDto)
    {
        return new Student
        {
            Id = Guid.NewGuid(),
            FirstName = studentCreateDto.FirstName,
            LastName = studentCreateDto.LastName,
            Age = studentCreateDto.Age,
            Email = studentCreateDto.Email,
            Phone = studentCreateDto.Phone,
            Degrees = studentCreateDto.Degrees,
            Gender = studentCreateDto.Gender
        };
    }
    private StudentGetDto ConvertToDto(Student student)
    {
        return new StudentGetDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Phone = student.Phone,
            Degrees = student.Degrees,
            Gender = student.Gender
        };
    }
    private bool ValidateStudentCreateDto(StudentCreateDto obj)
    {
        if (string.IsNullOrWhiteSpace(obj.FirstName) || obj.FirstName.Length > 50)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.LastName) || obj.LastName.Length > 50)
        {
            return false;
        }
        if (obj.Age < 15 || obj.Age > 55)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Email) || obj.Email.EndsWith("@gmail.com")
            || obj.Email.Length > 100 || obj.Email.Length <= 10)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Phone) || obj.Phone.StartsWith("+998")
            || obj.Phone.Length != 11)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Password) || obj.Password.Length > 50 || obj.Password.Length < 8)
        {
            return false;
        }
        return false;
    }
    public bool CreateStudent(StudentCreateDto student)
    {
        var res = ValidateStudentCreateDto(student);
        if (res)
        {
            var studentCreateDto = ConvertToStudent(student);
            StudentRepositorie.AddedStudent(studentCreateDto);
            return true;
        }
        return false;
    }

    public void DeleteStudent(Guid id)
    {
        StudentRepositorie.DeletedStudent(id);
    }

    public StudentGetDto GetById(Guid id)
    {
        var std = StudentRepositorie.GetById(id);
        var gDto = ConvertToDto(std);
        return gDto;
    }

    public List<StudentGetDto> GetStudentAll()
    {
        var list = new List<StudentGetDto>();
        var stnd = StudentRepositorie.ReadStudent();
        foreach (var student in stnd)
        {
            var getDto = ConvertToDto(student);
            list.Add(getDto);
        }
        return list;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        var _student = ConvertToStudent(student);
        StudentRepositorie.UpdatedStudent(_student);
    }
}
