using StudentCrud.Services.DTOs;

namespace StudentCrud.Services;

public interface IStudentService
{
    StudentGetDto CreateStduent(StudentCreateDto student);
    void UpdateStudent(StudentUpdateDto student);
    void DeleteStudent(Guid id);
    List<StudentGetDto> GetAllStudent();
}