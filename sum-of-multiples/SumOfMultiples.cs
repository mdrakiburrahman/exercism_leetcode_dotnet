using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> divisors, int limit)
    {
        var multiples = new List<int> {};
        for(int n = 1; n < limit; n++)
        {
            // Attempt to divide n by each divisor
            foreach(int divisor in divisors)
            {
                if (divisor != 0)
                {
                    if (n % divisor == 0)
                    {
                        multiples.Add(n);
                        break;
                    }
                }
            }
        }
        return multiples.Sum();
    }
}