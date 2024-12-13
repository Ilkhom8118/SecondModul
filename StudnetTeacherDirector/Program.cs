using StudnetTeacherDirector.Models;
using StudnetTeacherDirector.Services;

namespace StudnetTeacherDirector;

public class Program
{
    public static string directorUserName = "Director";
    public static string directorPassword = "Director";
    static void Main(string[] args)
    {
        while (true)
        {
            FrontEnd();
        }
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
            Console.Clear();
            var student = studentServices.GetStudentByUser(login, password);
            var teacher = teacherServices.GetTeacherByUser(login, password);
            if (directorUserName == login && directorPassword == password)
            {
                DirectorMenu();
            }
            else if (student is not null && student.UserName == login && student.Password == password)
            {
                StudentMenu(student);
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
                Console.ReadKey();
                Console.Clear();
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
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "3")
            {
                Console.Write("Enter Teacher By Id: ");
                teacher.Id = Guid.Parse(Console.ReadLine());

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
                Console.ReadKey();
                Console.Clear();
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
                Console.Clear();
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
                    Console.WriteLine($"Likes: {byId.Likes}");
                    Console.WriteLine($"DisLikes: {byId.DisLikes}");
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    public static void TeacherMenu()
    {
        IStudentServices studentServices = new StudentServices();
        Student student = new Student();
        ITestServices testServices = new TestServices();
        Test test = new Test();
        while (true)
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Get All Student");
            Console.WriteLine("5. Get By Student");
            Console.WriteLine("6. Add Test");
            Console.WriteLine("7. Delete Test");
            Console.WriteLine("8. Update Test");
            Console.WriteLine("9. Get All Test");
            Console.WriteLine("10. Get By Test");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var option = Console.ReadLine();
            if (option == "1")
            {
                Console.Write("First Name: ");
                student.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                student.LastName = Console.ReadLine();
                Console.Write("Age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Degree: ");
                student.Degree = Console.ReadLine();
                Console.Write("Gender: ");
                student.Gender = Console.ReadLine();
                Console.Write("PhoneNumber: ");
                student.Phone = Console.ReadLine();
                Console.Write("UserName: ");
                student.UserName = Console.ReadLine();
                Console.Write("Password: ");
                student.Password = Console.ReadLine();
                studentServices.AddStudent(student);
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "2")
            {
                var list = studentServices.GetAll();
                foreach (var stnd in list)
                {
                    Console.WriteLine($"Id : {stnd.Id}");
                    Console.WriteLine($"FirstName : {stnd.FirstName}");
                    Console.WriteLine($"LastName : {stnd.LastName}");
                    Console.WriteLine($"Age : {stnd.Age}");
                    Console.WriteLine($"Degree : {stnd.Degree}");
                    Console.WriteLine($"Gender : {stnd.Gender}");
                    for (var i = 0; i < list[i].Results.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.Bahosi: {list[i].Results[i]}");
                    }
                }
                Console.Write("Enter By Id: ");
                var deleteId = Guid.Parse(Console.ReadLine());
                var idDelete = studentServices.DeletedStudent(deleteId);
                if (idDelete is false)
                {
                    Console.WriteLine("Not Deleted !!!");
                }
                else
                {
                    Console.WriteLine("Deleted !!!");
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "3")
            {
                Console.Write("First Name: ");
                student.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                student.LastName = Console.ReadLine();
                Console.Write("Age: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Degree: ");
                student.Degree = Console.ReadLine();
                Console.Write("Gender: ");
                student.Gender = Console.ReadLine();
                studentServices.UpdatedStudent(student);
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "4")
            {
                var list = studentServices.GetAll();
                foreach (var stnd in list)
                {
                    Console.WriteLine($"Id : {stnd.Id}");
                    Console.WriteLine($"FirstName : {stnd.FirstName}");
                    Console.WriteLine($"LastName : {stnd.LastName}");
                    Console.WriteLine($"Age : {stnd.Age}");
                    Console.WriteLine($"Degree : {stnd.Degree}");
                    Console.WriteLine($"Gender : {stnd.Gender}");

                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "5")
            {
                Console.Write("Enter Id: ");
                var id = Guid.Parse(Console.ReadLine());
                var stnd = studentServices.GetById(id);
                Console.WriteLine($"Id : {stnd.Id}");
                Console.WriteLine($"FirstName : {stnd.FirstName}");
                Console.WriteLine($"LastName : {stnd.LastName}");
                Console.WriteLine($"Age : {stnd.Age}");
                Console.WriteLine($"Degree : {stnd.Degree}");
                Console.WriteLine($"Gender : {stnd.Gender}");
                for (var i = 0; i < stnd.Results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.Bahosi: {stnd.Results[i]}");
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "6")
            {
                Console.Write("Enter Question Text");
                test.QuestionText = Console.ReadLine();
                Console.Write("Enter A Variant: ");
                test.AVariant = Console.ReadLine();
                Console.Write("Enter B Variant: ");
                test.BVariant = Console.ReadLine();
                Console.Write("Enter C Variant: ");
                test.CVariant = Console.ReadLine();
                Console.Write("Enter Answer: ");
                test.Answer = Console.ReadLine();
                testServices.AddTest(test);
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "7")
            {
                var list = testServices.GetAll();
                for (var i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - savol");
                    Console.WriteLine($"Id: {list[i].Id}");
                    Console.WriteLine($"Question Text: {list[i].QuestionText}");
                    Console.WriteLine($"A Variant: {list[i].AVariant}");
                    Console.WriteLine($"B Variant: {list[i].BVariant}");
                    Console.WriteLine($"C Variant: {list[i].CVariant}");
                    Console.WriteLine($"Answer: {list[i].Answer}");
                }
                var guId = Guid.Parse(Console.ReadLine());
                var id = testServices.DeletedTest(guId);
                if (id is true)
                {
                    Console.WriteLine("Deleted Test !!!");
                }
                else
                {
                    Console.WriteLine("Not Deleted Test !!!");
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "8")
            {
                Console.Write("Enter Question Text");
                test.QuestionText = Console.ReadLine();
                Console.Write("Enter A Variant: ");
                test.AVariant = Console.ReadLine();
                Console.Write("Enter B Variant: ");
                test.BVariant = Console.ReadLine();
                Console.Write("Enter C Variant: ");
                test.CVariant = Console.ReadLine();
                Console.Write("Enter Answer: ");
                test.Answer = Console.ReadLine();
                testServices.UpdatedTest(test);
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "9")
            {
                var list = testServices.GetAll();
                for (var i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - savol");
                    Console.WriteLine($"Id: {list[i].Id}");
                    Console.WriteLine($"Question Text: {list[i].QuestionText}");
                    Console.WriteLine($"A Variant: {list[i].AVariant}");
                    Console.WriteLine($"B Variant: {list[i].BVariant}");
                    Console.WriteLine($"C Variant: {list[i].CVariant}");
                    Console.WriteLine($"Answer: {list[i].Answer}");
                }
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "10")
            {
                Console.Write("Enter Id: ");
                var id = Guid.Parse(Console.ReadLine());
                var list = testServices.GetById(id);
                Console.WriteLine($"Id: {list.Id}");
                Console.WriteLine($"Question Text: {list.QuestionText}");
                Console.WriteLine($"A Variant: {list.AVariant}");
                Console.WriteLine($"B Variant: {list.BVariant}");
                Console.WriteLine($"C Variant: {list.CVariant}");
                Console.WriteLine($"Answer: {list.Answer}");
                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "0")
            {
                Console.Clear();
                break;
            }
        }
    }
    public static void StudentMenu(Student sstudent)
    {
        ITestServices testServices = new TestServices();
        Test test = new Test();
        IStudentServices studentServices = new StudentServices();
        Student student = new Student();
        ITeacherServices teacherService = new TeacherServices();
        Teacher teacher = new Teacher();
        while (true)
        {
            if(sstudent.NewMessages > sstudent.OldMessages)
            {
                Console.WriteLine($"\t\tSizda Yangi {sstudent.NewMessages - 
                    sstudent.OldMessages} ta Xabar Bor");
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("1. Get All Test.");
            Console.WriteLine("2. Show my Results.");
            Console.WriteLine("3. Give rate to teacher.");
            Console.WriteLine("4. Send Message.");
            Console.WriteLine("5. My Message.");
            Console.WriteLine("6. Delete Message.");
            Console.WriteLine("0. Back.");
            Console.Write("Choose: ");
            var option = Console.ReadLine();
            Console.ReadKey();
            Console.Clear();
            if (option == "1")
            {
                var list = testServices.GetAll();
                for (var i = 0; i < list.Count; i++)
                {
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"{i + 1}.");
                    Console.WriteLine($" {list[i].QuestionText}");
                    Console.WriteLine($"A: {list[i].AVariant}");
                    Console.WriteLine($"B: {list[i].BVariant}");
                    Console.WriteLine($"C: {list[i].CVariant}");
                    Console.Write("Choose: ");
                    var choose = Console.ReadLine();
                    if (choose == list[i].Answer)
                    {
                        Console.WriteLine("Correct !!!");
                        sstudent.Results.Add(1);
                    }
                    else
                    {
                        Console.WriteLine("Wrong !!!");
                        sstudent.Results.Add(0);
                    }
                    studentServices.UpdatedStudent(sstudent);
                }

            }
            else if (option == "2")
            {
                Console.WriteLine($"{sstudent.FirstName} Results.");

                for (var i = 0; i < sstudent.Results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {sstudent.Results[i]} ");
                }
                Console.WriteLine();

                Console.ReadKey();
                Console.Clear();
            }
            else if (option == "3")
            {
                var listTeacher = teacherService.GetAll();
                Console.Write("Enter Teacher Name: ");
                var teacherName = Console.ReadLine();
                Console.Write("Enter Subject: ");
                var teacherSubject = Console.ReadLine();
                foreach (var techer in listTeacher)
                {
                    if (techer.FirstName == teacherName && techer.Subject == teacherSubject)
                    {
                        techer.Likes++;
                        teacherService.UpdatedTeacher(techer);
                        break;
                    }
                }
            }
            else if (option == "4")
            {
                Console.Write("Enter Reciver Person Id: ");
                var RPerson = studentServices.GetById(Guid.Parse(Console.ReadLine()));
                if (RPerson is null)
                {
                    Console.WriteLine("Wrong Id !!!");
                }
                else
                {
                    Console.Write("Enter Your Message: ");
                    var message = Console.ReadLine();
                    message += $"\nFrom : {sstudent.FirstName}\n";
                    RPerson.Messages.Add(message);
                    studentServices.UpdatedStudent(RPerson);
                    RPerson.NewMessages = RPerson.Messages.Count;
                    studentServices.UpdatedStudent(RPerson);
                }

            }
            else if (option == "5")
            {
                sstudent.NewMessages = sstudent.Messages.Count;
                sstudent.OldMessages = sstudent.Messages.Count;
                studentServices.UpdatedStudent(sstudent);
                foreach (var sms in sstudent.Messages)
                {
                    Console.WriteLine(sms);
                    Console.WriteLine();
                }
            }
            else if (option == "0")
            {
                break;
            }
            else if (option == "6")
            {
                Console.Write("Enter Deleted Message: ");
                var delSms = Console.ReadLine();
                foreach (var sms in sstudent.Messages)
                {
                    if (sms.Contains(delSms))
                    {
                        sstudent.Messages.Remove(sms);
                        Console.WriteLine("Deleted !!!");
                        studentServices.UpdatedStudent(sstudent);
                        sstudent.NewMessages = sstudent.Messages.Count;
                        sstudent.OldMessages = sstudent.Messages.Count;
                        studentServices.UpdatedStudent(sstudent);
                        break;
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
