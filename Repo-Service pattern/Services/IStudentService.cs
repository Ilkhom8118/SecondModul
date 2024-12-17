using Repo_Service_pattern.Services.DTOs;

namespace Repo_Service_pattern.Services
{
    public interface IStudentService
    {
        bool CreateStudent(StudentCreateDto student);
        void UpdateStudent(StudentUpdateDto student);
        void DeleteStudent(Guid id);
        public List<StudentGetDto> GetStudentAll();
        StudentGetDto GetById(Guid id);
    }
}