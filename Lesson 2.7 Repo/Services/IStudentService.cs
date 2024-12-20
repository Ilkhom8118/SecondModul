using Lesson_2._7_Repo.Services.DTOs;

namespace Lesson_2._7_Repo.Services;

public interface IStudentService
{
    public bool StudentCreateDto(StudentCreateDto studentCreateDto);
    public void UpdateStudent(StudentUpdateDto student);
    public void DeleteStudent(Guid id);
    public List<StudentGetDto> GetStudentsAll();
    StudentGetDto GetById(Guid id);
}