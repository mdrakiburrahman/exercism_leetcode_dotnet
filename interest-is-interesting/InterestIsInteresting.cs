using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0.0m)
        {
            return 3.213f;
        }
        else if (balance < 1000.0m)
        {
            return 0.5f;
        }
        else if (balance >= 1000.0m && balance < 5000.0m)
        {
            return 1.621f;
        }
        else if (balance >= 5000.0m)
        {
            return 2.475f;
        }
        else
        {
            return 0.0f;
        }
    }

    public static decimal Interest(decimal balance)
    {
        return (decimal)(balance * (decimal)InterestRate(balance) / 100.0m);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;

        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        
        return years;
    }
}
