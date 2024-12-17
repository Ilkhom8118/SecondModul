using Repo_Service_pattern.DataAccess.Entity;

namespace Repo_Service_pattern.Repoistroy
{
    public interface IStudentRepositorie
    {
        Student AddedStudent(Student added);
        void DeletedStudent(Guid id);
        void UpdatedStudent(Student obj);
        Student GetById(Guid id);
        List<Student> ReadStudent();
        void CheckUserNameEmailPhone(string email, string userName, string phone);

    }
}