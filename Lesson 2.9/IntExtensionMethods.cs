namespace Lesson_2._9;

public static class IntExtensionMethods
{
    public static bool EvelNum(this int number)
    {
        var countEvel = 0;
        if (number % 2 == 0)
        {
            return true;
        }
        return false;
    }
}
