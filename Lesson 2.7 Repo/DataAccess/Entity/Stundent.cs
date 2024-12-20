using Lesson_2._7_Repo.DataAccess.Enums;

namespace Lesson_2._7_Repo.DataAccess.Entity;

public class Stundent
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Degree Degree { get; set; }
    public Gander Gander { get; set; }

}
