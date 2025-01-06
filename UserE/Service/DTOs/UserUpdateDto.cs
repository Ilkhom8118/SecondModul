namespace UserE.Service.DTOs;

public class UserUpdateDto : UserBaseDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }

}
