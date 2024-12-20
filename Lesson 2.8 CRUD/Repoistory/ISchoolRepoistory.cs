using Lesson_2._8_CRUD.DataAccess.Entity;

namespace Lesson_2._8_CRUD.Repoistory;

public interface ISchoolRepoistory
{
    public School AddSchool(School added);
    public bool DeleteSchool(Guid id);
    public void UpdateSchool(School obj);
    public School GetById(Guid id);
    public List<School> GetAllSchool();
}
