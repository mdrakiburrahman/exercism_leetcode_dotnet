using System;
using System.Collections.Generic;

public static class Sieve
{

    public static int[] generateNums(int limit)
    {
        int[] nums = new int[limit-1];
        for (int i = 0; i < limit-1; i++)
        {
            nums[i] = i + 2;
        }
        return nums;
    }
    
   public static int nextNonZeroIndex(int[] l, int i)
    {
        i++; // start at next index
        if (i >= l.Length)
        {
            return l.Length - 1; // End of array
        }
        while (l[i] == 0 && i < l.Length - 1)
        {
            i++;
        }
        return i;
    }
    public static int[] sieve(int[] l, int i, int limit)
    {
        int n = 1; // Multiplier
        bool flag = true;
        while(flag) // When flag is false, we are out of bound
        {
            if ((i + l[i]*n) >= l.Length) // Out of bound
            {
                flag = false;
                break;
            } else {
                l[i + l[i]*n] = 0; // Weed out Prime multiples
                n++;
            }
        }
        i = nextNonZeroIndex(l, i); // Find next non-zero index for new prime
        if(i == l.Length - 1) // End of array
        {
            return l; // returns with zeros
        } else {
            return sieve(l, i, limit);
        }
    }
    public static int[] Primes(int limit)
    {
        if (limit <= 0) // Negative
        {
            throw new ArgumentOutOfRangeException("limit", "Limit must be greater than 0");
        } else if (limit  == 1) // 1 is not prime
        {
            return new int[0];
        }
        var l = generateNums(limit);
        l = sieve(l, 0, limit);

        // Remove all zeros and create new array
        var primes = new List<int>() {};
        for (int i = 0; i < l.Length; i++)
        {
            if (l[i] != 0)
            {
                primes.Add(l[i]);
            }
        }        
        return primes.ToArray();
    }
}