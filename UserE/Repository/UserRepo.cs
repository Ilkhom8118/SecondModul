using System.Text.Json;
using UserE.AccessData.Entity;

namespace UserE.Repository;

public class UserRepo : IUserRepo
{
    private string Path;
    private List<User> _users;
    public UserRepo()
    {
        Path = "../../../AccessData/Data/User.json";
        _users = new List<User>();
        if (!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
    }
    private void SaveInformation(List<User> users)
    {
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText(Path, json);
    }
    private List<User> GetAllUsers()
    {
        var json = File.ReadAllText(Path);
        var file = JsonSerializer.Deserialize<List<User>>(json);
        return file;
    }
    public User AddUser(User added)
    {
        _users.Add(added);
        SaveInformation(_users);
        return added;
    }


    public void DeleteUser(Guid id)
    {
        var objId = GetById(id);
        _users.Remove(objId);
        SaveInformation(_users);
    }

    public List<User> GetAll()
    {
        return GetAllUsers();
    }

    public User GetById(Guid id)
    {
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null;
    }

    public void UpdatedUser(User obj)
    {
        var id = GetById(obj.Id);
        _users[_users.IndexOf(id)] = obj;
        SaveInformation(_users);
    }
}
