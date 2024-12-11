using StudnetTeacherDirector.Models;
using StudnetTeacherDirector.Services;

namespace StudnetTeacherDirector;

public class Program
{
    public static string directorUserName = "Director";
    public static string directorPassword = "Director";
    static void Main(string[] args)
    {
        FrontEnd();

    }
    public static void FrontEnd()
    {
        var std = new Student();

        IStudentServices studentServices = new StudentServices();
        ITeacherServices teacherServices = new TeacherServices();
        Student studentUser = new Student();
        while (true)
        {
            Console.WriteLine("\t Login");
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            var student = studentServices.GetStudentByUser(login, password);
            var teacher = teacherServices.GetTeacherByUser(login, password);
            if (directorUserName == login && directorPassword == password)
            {
                DirectorMenu();
            }
            else if (student is not null && student.UserName == login && student.Password == password)
            {
                StudentMenu();
            }
            else if (teacher is not null && teacher.UserName == login && teacher.Password == password)
            {
                TeacherMenu();
            }
            else
            {
                Console.WriteLine("1. Fargot password");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");
                var choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.Write("Enter Teacher number: ");
                    var numberTeacher = Console.ReadLine();
                    var res = teacherServices.GetTeacherByNumber(numberTeacher);
                    if (res is not null && res.Phone == numberTeacher)
                    {
                        Console.Write("Enter UserName: ");
                        res.UserName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        res.Password = Console.ReadLine();
                        teacherServices.UpdatedTeacher(res);
                    }
                    else
                    {
                        Console.WriteLine("No such user found");
                        break;
                    }
                }
                else if (choose == "0")
                {
                    break;
                }

            }
        }
    }

    public static void DirectorMenu()
    {
        ITeacherServices teacherServices = new TeacherServices();
        Teacher teacher = new Teacher();
        while (true)
        {
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Deleted Teacher");
            Console.WriteLine("3. Update Teacher");
            Console.WriteLine("4. Get By Teacher");
            Console.WriteLine("5. Get All Teacher");
            Console.Write("Choose: ");
            var option = Console.ReadLine();
            if (option == "1")
            {
                Console.Write("First Name: ");
                teacher.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                teacher.LastName = Console.ReadLine();
                Console.Write("Age: ");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.Write("Subject: ");
                teacher.Subject = Console.ReadLine();
                Console.Write("Gander: ");
                teacher.Gender = Console.ReadLine();
                Console.Write("Phone Number: ");
                teacher.Phone = Console.ReadLine();
                Console.Write("Enter UserName: ");
                teacher.UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                teacher.Password = Console.ReadLine();
                teacherServices.AddTeacher(teacher);
            }
            else if (option == "2")
            {
                var listTeacher = teacherServices.GetAll();
                foreach (var teacherList in listTeacher)
                {
                    Console.WriteLine($"Id: {teacherList.Id}");
                    Console.WriteLine($"FirstName: {teacherList.FirstName}");
                    Console.WriteLine($"LastName: {teacherList.LastName}");
                    Console.WriteLine($"Age: {teacherList.Age}");
                    Console.WriteLine($"Subject: {teacherList.Subject}");
                    Console.WriteLine($"Gender: {teacherList.Gender}");
                    Console.WriteLine();
                }
                Console.WriteLine("Enter Deleted By Id");
                var deletedId = Guid.Parse(Console.ReadLine());
                var res = teacherServices.DeletedTeacher(deletedId);
                if (res)
                {
                    Console.WriteLine("Deleted !!!");
                }
                else
                {
                    Console.WriteLine("Not Deleted !!!");
                }
            }
            else if (option == "3")
            {
                Console.Write("First Name: ");
                teacher.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                teacher.LastName = Console.ReadLine();
                Console.Write("Age: ");
                teacher.Age = int.Parse(Console.ReadLine());
                Console.Write("Subject: ");
                teacher.Subject = Console.ReadLine();
                Console.Write("Gander: ");
                teacher.Gender = Console.ReadLine();
                teacherServices.UpdatedTeacher(teacher);
            }
            else if (option == "4")
            {
                Console.Write("Enter By Id: ");
                var getByid = Guid.Parse(Console.ReadLine());
                var byId = teacherServices.GetById(getByid);
                Console.WriteLine($"Id: {byId.Id}");
                Console.WriteLine($"FirstName: {byId.FirstName}");
                Console.WriteLine($"LastName: {byId.LastName}");
                Console.WriteLine($"Age: {byId.Age}");
                Console.WriteLine($"Subject: {byId.Subject}");
                Console.WriteLine($"Gender: {byId.Gender}");
                Console.WriteLine($"UserName: {byId.UserName}");
                Console.WriteLine($"Password: {byId.Password}");
                Console.WriteLine($"Phone: {byId.Phone}");
                Console.WriteLine();
            }
            else if (option == "5")
            {
                var listTeacher = teacherServices.GetAll();
                foreach (var byId in listTeacher)
                {
                    Console.WriteLine($"Id: {byId.Id}");
                    Console.WriteLine($"FirstName: {byId.FirstName}");
                    Console.WriteLine($"LastName: {byId.LastName}");
                    Console.WriteLine($"Age: {byId.Age}");
                    Console.WriteLine($"Subject: {byId.Subject}");
                    Console.WriteLine($"Gender: {byId.Gender}");
                    Console.WriteLine($"UserName: {byId.UserName}");
                    Console.WriteLine($"Password: {byId.Password}");
                    Console.WriteLine($"Phone: {byId.Phone}");
                    Console.WriteLine();
                }
            }
        }
    }
    public static void TeacherMenu()
    {

    }
    public static void StudentMenu()
    {

    }
}
