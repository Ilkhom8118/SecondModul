﻿using Repo_Service_pattern.DataAccess.Enums;

namespace Repo_Service_pattern.DataAccess.Entity;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<string> Degrees { get; set; }
    public Gender Gender { get; set; }


}
