using System;

public static class ArmstrongNumbers
{
    public static int calcArmStrongValue(int n)
    {
        var s = n.ToString(); // String representation for us to loop through
        var l = s.Length; // Number of digits in the number
        int sum = 0;
        int nth;
        for(int i = 0; i < l; i++)
        {
            nth = int.Parse(Char.ToString(s[i])); // Convert Nth digit to int
            sum += (int)Math.Pow(nth, l);
        }
        return sum;
    }
    public static bool IsArmstrongNumber(int number)
    {
        return calcArmStrongValue(number) == number;
    }
}