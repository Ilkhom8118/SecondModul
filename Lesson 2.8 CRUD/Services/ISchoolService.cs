using Lesson_2._8_CRUD.Services.DTOs;

namespace Lesson_2._8_CRUD.Services;

public interface ISchoolService
{
    bool AddSchool(SchoolDto added);
    void DeleteSchool(Guid id);
    void UpdateSchool(SchoolDto obj);
    List<SchoolDto> GetAllSchool();
    SchoolDto GetById(Guid id);
    SchoolDto AddSchoolAdd(SchoolCrateDto added);
}