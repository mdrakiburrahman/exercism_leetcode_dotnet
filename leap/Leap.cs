using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        // If year is divisible by 4, it is a leap year
        if (year%4 == 0)
        {
            // But if year is divisible by 100, it may not be a leap year
            if (year%100 == 0)
            {
                // Unless that year is divisible by 400, then it is a leap year
                if (year%400 == 0)
                {
                    return true;
                } 
                return false;
            }
            return true;
        }
        return false;
    }
}