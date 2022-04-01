using System.Collections.Generic;

public class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var primes = new List<long>(); // List of Primae divisors
        int divisor = 2;
        while (number > 1) // Stop looping when remaining number is 1
        {
            while (number % divisor == 0) // If next number is a divisor, add it
            {
                primes.Add(divisor);
                number = number/divisor;
            }
            divisor++; // Increment divisor
        }
        return primes.ToArray();
    }
}