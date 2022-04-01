using System;
using System.Collections.Generic;


var p = PrimeFactors.Factors(93819012551L);
// Print the array
Console.WriteLine(string.Join(",", p));

public static class PrimeFactors
{
    public static List<long> appendFactors(List<long> factors, long number, long divisor)
    {
        if (number == 1) // No longer divisible by prime
            return factors;
        if (number % divisor == 0) // Valid divisor
        {   
            factors.Add(divisor);
            // Try again with the same divisor recursively
            return appendFactors(factors, number/divisor, divisor);
        }
        else // Divisor did not match
            return appendFactors(factors, number, divisor+1); // Increment
    }
    public static long[] Factors(long number)
    {
        List<long> factors = new List<long>();
        return appendFactors(factors, number, 2).ToArray(); // Start at 2
    }
}