﻿namespace CRUD_StudentAndTeacherAndDirector.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Degree { get; set; }

    public string Gender { get; set; }

    public List<int> Results { get; set; } = new List<int>();

    public string Password { get; set; }
    public string UserName { get; set; }
}
