using UserE.AccessData.Entity;
using UserE.Service.DTOs;

namespace UserE.Service;

public interface IUserService
{
    User Add(UserCreateDto obj);
    void Delete(Guid id);
    void UpdateUser(UserUpdateDto obj);
    void GetAllUsers(List<UserGetDto> obj);
    UserGetDto GetUserById(Guid id);
}