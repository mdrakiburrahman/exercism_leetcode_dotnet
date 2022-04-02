using System;

var inputBase = 2;
var digits = new[] { 1, 0, 1, 0, 1, 0 };
var outputBase = 10;
AllYourBase.Rebase(inputBase, digits, outputBase);

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


    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        // Error handling
        if (inputBase < 2 || outputBase < 2 || baseValidChecker(inputDigits, inputBase) == false)
        {
            throw new ArgumentException("Base must be >= 2, digits must be base > d >= 0");
        }
        // Edge case: empty array, or same base
        if(inputDigits.Length == 0 || inputBase == outputBase)
        {
            return inputDigits;
        }
        // Normalize to Base 10 first
        int numBase10 = convertBaseTen(inputDigits, inputBase);

        // Convert from Base 10 to desired base



        return new int[] { };
    }
}