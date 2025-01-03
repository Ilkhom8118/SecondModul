using StudentCrud.Services.DTOs;

namespace StudentCrud.Services;

public class StudentCreateDto : StudentDataBase
{
    public string Password { get; set; }
}
