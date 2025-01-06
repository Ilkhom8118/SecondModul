namespace Inkapsulatsiya;

public class Account
{
    private int _Age;

    public int MyProperty
    {
        get
        {
            var age = 12;
            return age;
        }
        set
        {
            if (value == 10)
            {
                Console.WriteLine("set");
            }
        }
    }

}
