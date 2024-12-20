using Lesson_2._7_Repo.DataAccess.Entity;

namespace Lesson_2._7_Repo.Repoistroy;

public interface IStudentRepositorie
{
    public Stundent AddStudent(Stundent added);
    public void DeleteStudent(Guid id);
    public void UpdateStudent(Stundent obj);
    public List<Stundent> GetAllStudent();
    public Stundent GetById(Guid id);
}