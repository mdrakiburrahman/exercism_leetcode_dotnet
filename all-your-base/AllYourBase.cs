using System;
using System.Collections.Generic;

public static class AllYourBase
{
    public static bool baseValidChecker(int[] array, int b)
    {
        for(int i=0; i < array.Length; i++)
        {
            if(array[i] >= b || array[i] < 0)
            {
                return false;
            }
        }
        return true;
    }

    public static int convertBaseTen(int[] array, int b)
    {
        int output = 0;
        for(int i=0; i < array.Length; i++)
        {
            // array[i] + base^position from the right
            output += array[i] * (int)Math.Pow(b, array.Length - 1 - i);
        }
        return output;
    }

    public static List<int> baseConvArray(int n, int b)
    {
        var result = new List<int>();
        while (n > 0)
        {
            result.Add(n%b);
            n /= b;
        }
        if (n == 0 && result.Count == 0)
        {
            return new List<int>() { 0 };
        }
        result.Reverse();
        return result;
    }

    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        // Error handling
        if (inputBase < 2 || outputBase < 2 || baseValidChecker(inputDigits, inputBase) == false)
        {
            throw new ArgumentException("Base must be >= 2, digits must be base > d >= 0");
        }
        // Edge case: empty array, or same base
        if(inputDigits.Length == 0)
        {
            return new int[] { 0 };
        }
        // Same base
        if(inputBase == outputBase)
        {
            return inputDigits;
        }

        // Normalize to Base 10 first
        int numBase10 = convertBaseTen(inputDigits, inputBase);

        // Convert from Base 10 to desired base
        return baseConvArray(numBase10, outputBase).ToArray();
    }
}