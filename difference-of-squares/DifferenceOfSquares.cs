using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int n)
    {
        int sum = 0;
        for(int i = 1; i <= n; i++)
        {
            sum += i;
        }
        return sum*sum;
    }

    public static int CalculateSumOfSquares(int n)
    {
        int sum = 0;
        for(int i = 1; i <= n; i++)
        {
            sum += i*i;
        }
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int n)
    {
        return CalculateSquareOfSum(n) - CalculateSumOfSquares(n);
    }
}