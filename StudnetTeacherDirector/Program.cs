using StudnetTeacherDirector.Services;

namespace StudnetTeacherDirector
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public static void FrontEnd()
        {
            IStudentServices studentServices = new StudentServices();
        }
    }
}
