namespace StudentCrud.Services.DTOs;

public class StudentUpdateDto : StudentDataBase
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
