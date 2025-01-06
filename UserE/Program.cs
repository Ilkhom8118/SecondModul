using UserE.Service;
using UserE.Service.DTOs;

namespace UserE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IUserService user = new UserService();
            var obj = new UserCreateDto();
            obj.FirstName = "Ziyod";
            user.Add(obj);



        }
    }
}
