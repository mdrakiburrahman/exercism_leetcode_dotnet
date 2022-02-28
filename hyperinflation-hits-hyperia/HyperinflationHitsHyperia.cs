using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        long expr;
        try
        {
            expr = checked(@base * multiplier);
        }
        catch (System.OverflowException)
        {
            return "*** Too Big ***";
        }
        return expr.ToString();
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float expr = @base * multiplier;
        if (expr == float.PositiveInfinity || expr == float.NegativeInfinity)
        {
            return "*** Too Big ***";
        }
        return expr.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        decimal expr;
        try
        {
            expr = checked(salaryBase * multiplier);
        }
        catch (System.OverflowException)
        {
            return "*** Much Too Big ***";
        }
        return expr.ToString();
    }
}
