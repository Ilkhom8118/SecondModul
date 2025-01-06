using UserE.AccessData.Entity;

namespace UserE.Repository
{
    public interface IUserRepo
    {
        User AddUser(User added);
        User GetById(Guid id);
        void DeleteUser(Guid id);
        void UpdatedUser(User obj);
        List<User> GetAll();
    }
}