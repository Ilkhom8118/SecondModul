using Lesson_2._8_CRUD.DataAccess.Entity;
using Lesson_2._8_CRUD.Repoistory;
using Lesson_2._8_CRUD.Services.DTOs;

namespace Lesson_2._8_CRUD.Services;

public class SchoolService : ISchoolService
{
    private readonly ISchoolRepoistory SchoolRepoistory;
    public SchoolService()
    {
        SchoolRepoistory = new SchoolRepoistory();
    }
    public bool ValidationSchoolAddDto(SchoolDto obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Name) || obj.Name.Length < 20)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(obj.Address) || obj.Address.Length < 200)
        {
            return false;
        }
        if (obj.TotalStudent > 30)
        {
            return false;
        }
        if (obj.TotalTeacher > 30)
        {
            return false;
        }
        return true;
    }
    private School ConvertToSchool(SchoolCrateDto obj)
    {
        return new School
        {
            Name = obj.Name,
            Address = obj.Address,
            TotalStudent = obj.TotalStudent,
            TotalTeacher = obj.TotalTeacher,

        };
    }

    private SchoolDto ConvertToSchool(School obj)
    {
        return new SchoolDto
        {
            Id = obj.Id,
            Name = obj.Name,
            Address = obj.Address,
            TotalStudent = obj.TotalStudent,
            TotalTeacher = obj.TotalTeacher,

        };
    }

    public void DeleteSchool(Guid id)
    {
        SchoolRepoistory.DeleteSchool(id);
    }

    public List<SchoolDto> GetAllSchool()
    {
        var getAll = SchoolRepoistory.GetAllSchool();
        var listSchoolDto = new List<SchoolDto>();
        foreach (var school in getAll)
        {
            listSchoolDto.Add(ConvertToSchool(school));
        }
        return listSchoolDto;
    }

    public SchoolDto GetById(Guid id)
    {
        var list = SchoolRepoistory.GetById(id);
        var dto = ConvertToSchool(list);
        return dto;
    }

    public void UpdateSchool(SchoolDto obj)
    {
        var dto = ConvertToSchool(obj);
        SchoolRepoistory.UpdateSchool(dto);
    }

    public bool AddSchool(SchoolDto added)
    {
        var res = ValidationSchoolAddDto(added);
        if (res)
        {
            var schoolDto = ConvertToSchool(added);
            schoolDto.Id = Guid.NewGuid();
            SchoolRepoistory.AddSchool(schoolDto);
            return true;
        }
        return false;
    }
}
