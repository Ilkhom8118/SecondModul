using Lesson_2._8_CRUD.Services;
using Lesson_2._8_CRUD.Services.DTOs;

namespace Lesson_2._8_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISchoolService sevice = new SchoolService();

            var create = new SchoolDto()
            {
                Name = "salom",
                Address = "qale",
                TotalStudent = 4,
                TotalTeacher = 5,
            };

            sevice.AddSchoolAdd(create);
            sevice.DeleteSchool(create.Id);
        }
    }
}
//public string Name { get; set; }
//public string Address { get; set; }
//public int TotalStudent { get; set; }
//public int TotalTeacher { get; set; }