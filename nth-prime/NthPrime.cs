using System;
using System.Collections.Generic;
using System.Linq;

public static class NthPrime
{
    // See Sieve of Eratosthenes
    // https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
    public static bool IsNumberPrime(int x)
    {      
        // If the number is divisible only by itself and 1, it is prime
        if (x == 2)
            return true;

        for (int i = 2; i < x; i++)
        {
            if (x % i == 0)
                return false;
        }
        return true;
    }
    public static int Prime(int nth)
    {
        if (nth < 1)
            throw new ArgumentOutOfRangeException("No prime number for nth < 1");

        int num = 0;
        for (int x = 2; x < int.MaxValue; x++)
        {
            if (IsNumberPrime(x))
            {
                num++;
                if (num == nth)
                {
                    return x;
                }
            }
        }
        return 0;
    }
}