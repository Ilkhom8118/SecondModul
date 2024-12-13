namespace StudnetTeacherDirector.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Degree { get; set; }

    public string Gender { get; set; }

    public List<double> Results { get; set; } = new List<double>();
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
    public int NewMessages { get; set; } = 0;
    public int OldMessages { get; set; } = 0;
}
