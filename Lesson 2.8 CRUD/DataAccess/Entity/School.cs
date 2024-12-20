namespace Lesson_2._8_CRUD.DataAccess.Entity;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int TotalStudent { get; set; }
    public int TotalTeacher { get; set; }
}

