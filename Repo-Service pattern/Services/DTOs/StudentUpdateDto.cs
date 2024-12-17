namespace Repo_Service_pattern.Services.DTOs;

public class StudentUpdateDto : StudentBaseDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
