namespace Lesson_2._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myclass = new MyClass();
            int a = 3;
            int b = 4;
            myclass.MySwap<int>(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
