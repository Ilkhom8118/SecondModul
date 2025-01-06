using UserE.AccessData.Entity;
using UserE.Repository;
using UserE.Service.DTOs;

namespace UserE.Service;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    public UserService()
    {
        _userRepo = new UserRepo();
    }

    private User ConvertToEntity(UserCreateDto obj)
    {
        var user = new User()
        {
            Addres = obj.Addres,
            FirstName = obj.FirstName,
            LastName = obj.LastName,
            Password = obj.Password,
            PhoneNumber = obj.PhoneNumber,
            UserName = obj.UserName,
        };
        return user;
    }
    private UserBaseDto ConverToEntity(UserUpdateDto obj)
    {
        var user = new UserBaseDto()
        {
            Addres = obj.Addres,
            LastName = obj.LastName,
            UserName = obj.UserName,
            FirstName = obj.FirstName,
            PhoneNumber = obj.PhoneNumber,
        };
        return user;
    }
    private UserGetDto ConvertToEntity(User obj)
    {
        var getDto = new UserGetDto()
        {
            Id = obj.Id,
            Addres = obj.Addres,
            LastName = obj.LastName,
            UserName = obj.UserName,
            FirstName = obj.FirstName,
            PhoneNumber = obj.PhoneNumber,
        };
        return getDto;
    }

    public User Add(UserCreateDto obj)
    {
        var user = ConvertToEntity(obj);
        user.Id = Guid.NewGuid();
        _userRepo.AddUser(user);
        return user;
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public void GetAllUsers(List<UserGetDto> obj)
    {
        throw new NotImplementedException();
    }

    public UserGetDto GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(UserUpdateDto obj)
    {
        throw new NotImplementedException();
    }
}
