using CRUD_StudentAndTeacherAndDirector.Models;
using CRUD_StudentAndTeacherAndDirector.Servicesl;

namespace CRUD_StudentAndTeacherAndDirector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstMenu();
        }

        public static void FirstMenu()
        {
            Console.WriteLine("1. Director");
            Console.WriteLine("2. Teacher");
            Console.WriteLine("3. Student");
            Console.Write("Choose: ");
            var option = Console.ReadLine();

            if (option == "1")
            {
                DirectorMenu();
            }
            else if (option == "2")
            {
                TeacherMenu();
            }
            else if (option == "3")
            {
                StudentMenu();
            }

        }

        public static void DirectorMenu()
        {
            var teacherService = new TeachersServices();
            var teacherObj = new Teacher();
            while (true)
            {
                Console.Write("Enter Your Username : ");
                var directUserN = Console.ReadLine();
                Console.Write("Enter Your Password : ");
                var directPassw = Console.ReadLine();
                if (directUserN == teacherService.directorUsername && directPassw == teacherService.directorPassword)
                {
                    while (true)
                    {
                        Console.WriteLine("1. Add Teacher");
                        Console.WriteLine("2. Delete Teacher");
                        Console.WriteLine("3. Update Teacher");
                        Console.WriteLine("4. Get All Teachers");
                        Console.WriteLine("5. Get Teacher By ID");
                        Console.Write("Choose: ");
                        var option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                Console.Write("First Name:");
                                teacherObj.FirstName = Console.ReadLine();
                                Console.Write("Last Name:");
                                teacherObj.LastName = Console.ReadLine();
                                Console.Write("Age:");
                                teacherObj.Age = int.Parse(Console.ReadLine());
                                Console.Write("Subject:");
                                teacherObj.Subject = Console.ReadLine();
                                Console.Write("Like:");
                                teacherObj.Likes = int.Parse(Console.ReadLine());
                                Console.Write("Dislike:");
                                teacherObj.DisLikes = int.Parse(Console.ReadLine());
                                Console.Write("Gender:");
                                teacherObj.Gender = Console.ReadLine();
                                teacherService.AddTeacher(teacherObj);
                                break;
                            case "2":
                                Console.Write("Get Id Teacher: ");
                                var id = Guid.Parse(Console.ReadLine());
                                var getIdTeachers = teacherService.DeleteTeacher(id);
                                if (getIdTeachers is true)
                                {
                                    Console.WriteLine("Deleted !!!");
                                }
                                else
                                {
                                    Console.WriteLine("Not Deleted !!!");
                                }
                                break;
                            case "3":
                                Console.Write("Enter Id: ");
                                teacherObj.Id = Guid.Parse(Console.ReadLine());
                                Console.Write("First Name:");
                                teacherObj.FirstName = Console.ReadLine();
                                Console.Write("Last Name:");
                                teacherObj.LastName = Console.ReadLine();
                                Console.Write("Age:");
                                teacherObj.Age = int.Parse(Console.ReadLine());
                                Console.Write("Subject:");
                                teacherObj.Subject = Console.ReadLine();
                                Console.Write("Like:");
                                teacherObj.Likes = int.Parse(Console.ReadLine());
                                Console.Write("Dislike:");
                                teacherObj.DisLikes = int.Parse(Console.ReadLine());
                                Console.Write("Gender:");
                                teacherObj.Gender = Console.ReadLine();
                                teacherService.UpdateTeacher(teacherObj);
                                break;
                            case "4":
                                var teachers = teacherService.GetAll();
                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"Id: {teacher.Id}");
                                    Console.WriteLine($"FirstName: {teacher.FirstName}");
                                    Console.WriteLine($"LastName: {teacher.LastName}");
                                    Console.WriteLine($"Age: {teacher.Age}");
                                    Console.WriteLine($"Subject: {teacher.Subject}");
                                    Console.WriteLine($"Likes: {teacher.Likes}");
                                    Console.WriteLine($"DisLikes: {teacher.DisLikes}");
                                    Console.WriteLine($"Gender: {teacher.Gender}");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                                break;
                            case "5":
                                Console.Write("Enter Teacher's Id: ");
                                var guId = Guid.Parse(Console.ReadLine());
                                var teacherGuId = teacherService.GetById(guId);
                                Console.WriteLine($"Id: {teacherGuId.Id}");
                                Console.WriteLine($"FirstName: {teacherGuId.FirstName}");
                                Console.WriteLine($"LastName: {teacherGuId.LastName}");
                                Console.WriteLine($"Age: {teacherGuId.Age}");
                                Console.WriteLine($"Subject: {teacherGuId.Subject}");
                                Console.WriteLine($"Likes: {teacherGuId.Likes}");
                                Console.WriteLine($"DisLikes: {teacherGuId.DisLikes}");
                                Console.WriteLine($"Gender: {teacherGuId.Gender}");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Username Or Password");
                    continue;
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
}
