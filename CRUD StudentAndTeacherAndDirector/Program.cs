using CRUD_StudentAndTeacherAndDirector.Models;
using CRUD_StudentAndTeacherAndDirector.Services;
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
            var service = new StudentServices();
            var students = new Student();
            var test = new Test();
            var testService = new TestServices();
            var teacherService = new TeachersServices();
            // ===================================================================================
            Console.Write("Enter Teacher User name: ");
            var teacherUserName = Console.ReadLine();
            Console.Write("Enter Teacher password: ");
            var teacherPassword = Console.ReadLine();
            if (teacherUserName == teacherService.usingLogin && teacherPassword == teacherService.passwordTeacher)
            {
                while (true)
                {
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Delete Student");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Get All");
                    Console.WriteLine("5. Get By Id");
                    Console.WriteLine("6. Add Test");
                    Console.WriteLine("7. Delete Test");
                    Console.WriteLine("8. Update Test");
                    Console.WriteLine("9. Get Test By Id");
                    Console.WriteLine("10. Get All By Tests");
                    Console.Write("Enter choose: ");
                    var choose = Console.ReadLine();
                    switch (choose)
                    {
                        case "1":
                            Console.Write("First Name:");
                            students.FirstName = Console.ReadLine();
                            Console.Write("Last Name:");
                            students.LastName = Console.ReadLine();
                            Console.Write("Age:");
                            students.Age = int.Parse(Console.ReadLine());
                            Console.Write("Degree:");
                            students.Degree = Console.ReadLine();
                            Console.Write("Gender:");
                            students.Gender = Console.ReadLine();
                            service.AddStudent(students);
                            break;
                        case "2":
                            Console.Write("Enter deleted student's id: ");
                            var studentId = Guid.Parse(Console.ReadLine());
                            if (service.DeleteStudent(studentId))
                            {
                                Console.WriteLine("Deleted !!!");
                            }
                            else
                            {
                                Console.WriteLine("Not Deleted !!!");
                            }
                            break;
                        case "3":
                            Console.Write("Enter student's update id: ");
                            students.Id = Guid.Parse(Console.ReadLine());
                            Console.Write("First Name:");
                            students.FirstName = Console.ReadLine();
                            Console.Write("Last Name:");
                            students.LastName = Console.ReadLine();
                            Console.Write("Age:");
                            students.Age = int.Parse(Console.ReadLine());
                            Console.Write("Degree:");
                            students.Degree = Console.ReadLine();
                            Console.Write("Gender:");
                            students.Gender = Console.ReadLine();
                            var res = service.UpdateStudent(students);
                            if (res is true)
                            {
                                Console.WriteLine("Updated !!!");
                            }
                            else
                            {
                                Console.WriteLine("Not Updated !!!");
                            }
                            break;
                        case "4":
                            var sdnts = service.GetAll();
                            foreach (var student in sdnts)
                            {
                                Console.WriteLine($"Id : {student.Id}");
                                Console.WriteLine($"First Name : {student.FirstName}");
                                Console.WriteLine($"Last Name : {student.LastName}");
                                Console.WriteLine($"Age : {student.Age}");
                                Console.WriteLine($"Degree : {student.Degree}");
                                Console.WriteLine($"Gender : {student.Gender}");
                                foreach (var infoBall in student.Results)
                                {
                                    Console.WriteLine($"{infoBall} | ");
                                }
                            }
                            break;
                        case "5":
                            Console.Write("Enter student's update id: ");
                            var id = Guid.Parse(Console.ReadLine());
                            var studentRes = service.GetById(id);
                            Console.WriteLine($"Id : {studentRes.Id}");
                            Console.WriteLine($"First Name : {studentRes.FirstName}");
                            Console.WriteLine($"Last Name : {studentRes.LastName}");
                            Console.WriteLine($"Age : {studentRes.Age}");
                            Console.WriteLine($"Degree : {studentRes.Degree}");
                            Console.WriteLine($"Gender : {studentRes.Gender}");
                            foreach (var infoBall in studentRes.Results)
                            {
                                Console.WriteLine($"{infoBall} | ");
                            }
                            break;
                        case "6":
                            Console.Write("Add questions: ");
                            test.QuestionText = Console.ReadLine();
                            Console.Write("A: ");
                            test.AVariant = Console.ReadLine();
                            Console.Write("B: ");
                            test.BVariant = Console.ReadLine();
                            Console.Write("C: ");
                            test.CVariant = Console.ReadLine();
                            Console.Write("Tell me the answer: ");
                            test.Answer = Console.ReadLine();
                            testService.AddTest(test);
                            break;
                        case "7":
                            Console.Write("Enter Test's Deleted id: ");
                            var testId = Guid.Parse(Console.ReadLine());
                            if (testService.DeleteTest(testId) is true)
                            {
                                Console.WriteLine("Test Deleted !!!");
                            }
                            else
                            {
                                Console.WriteLine("Not Test Deleted !!!");
                            }
                            break;
                        case "8":
                            Console.Write("Enter Test's Update questions: ");
                            test.QuestionText = Console.ReadLine();
                            Console.Write("A: ");
                            test.AVariant = Console.ReadLine();
                            Console.Write("B: ");
                            test.BVariant = Console.ReadLine();
                            Console.Write("C: ");
                            test.CVariant = Console.ReadLine();
                            Console.Write("Tell me the answer: ");
                            test.Answer = Console.ReadLine();
                            var testRes = testService.UpdateTest(test);
                            if (testRes is true)
                            {
                                Console.WriteLine("Updated !!!");
                            }
                            else
                            {
                                Console.WriteLine("Not Updated !!!");
                            }
                            break;
                        case "9":
                            var testguId = Guid.Parse(Console.ReadLine());
                            var testGuId = testService.GetById(testguId);
                            Console.WriteLine($"{testGuId} ");
                            break;
                        case "10":
                            var testAll = testService.GetAll();
                            for (var i = 0; i < testAll.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {testAll[i]}");
                            }
                            break;
                    }
                }
            }
        }
        public static void StudentMenu()
        {
            var testServices = new TestServices();
            var studentServices = new StudentServices();
            var studentObj = new Student();
            Console.Write("Enter User Name: ");
            var stduentUser = Console.ReadLine();
            Console.Write("Enter User Password: ");
            var studentPass = Console.ReadLine();
            var student = studentServices.GetStudentByUser(stduentUser, studentPass);
            if (student is not null)
            {
                while (true)
                {
                    Console.WriteLine("1. Run Tests");
                    Console.WriteLine("2. How many tests worked");
                    Console.Write("Choose: ");
                    var option = Console.ReadLine();
                    var listTest = testServices.GetAll();
                    switch (option)
                    {
                        case "1":
                            var count = 0;
                            for (var i = 0; i < listTest.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {listTest[i].QuestionText}");
                                Console.WriteLine($"A: {listTest[i].AVariant}");
                                Console.WriteLine($"B {listTest[i].BVariant}");
                                Console.WriteLine($"C: {listTest[i].CVariant}");
                                Console.Write("Enter Variant: ");
                                var variant = Console.ReadLine();
                                if (variant == listTest[i].Answer)
                                {
                                    count++;
                                }
                            }
                            student.Results.Add(count);
                            studentServices.SaveStudentServices(studentServices.GetAll());
                            break;
                        case "2":
                            for (var i = 0; i < student.Results.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {student.Results[i]}");
                            }
                            break;
                    }
                }
            }
        }
    }
}