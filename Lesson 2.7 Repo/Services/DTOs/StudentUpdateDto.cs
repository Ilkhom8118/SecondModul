namespace Lesson_2._7_Repo.Services.DTOs;

public class StudentUpdateDto : StudentBaseDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
