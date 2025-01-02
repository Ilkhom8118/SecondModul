﻿using StudentCrud.DataAccess.Entity;

namespace StudentCrud.Repoistory;

public interface IStudentService
{
    Student AddStudent(Student added);
    Student GetByStudentId(Guid id);
    bool UpdateStudent(Student obj);
    bool DeleteStudent(Guid id);
    List<Student> GetAllStudent();
}