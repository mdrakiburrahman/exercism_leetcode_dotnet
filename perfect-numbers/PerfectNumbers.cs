using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static List<int> getDivisors(int n)
    {
        var result = new List<int>();
        for(int x = 1; x < n; x++)
        {
            if(n % x == 0)
            {
                result.Add(x);
            }
        }
        return result;
    }

    public static Classification Classify(int number)
    {
        // Error handling
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException("Only positive numbers are allowed");
        }

        // Sum up the divisors list
        var divisors = getDivisors(number);
        var sum = divisors.Sum();

        if (sum == number)
        {
            return Classification.Perfect;
        }
        else if (sum > number)
        {
            return Classification.Abundant;
        }
        else
        {
            return Classification.Deficient;
        }
    }
}
