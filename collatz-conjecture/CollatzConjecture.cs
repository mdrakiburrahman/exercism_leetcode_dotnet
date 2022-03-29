using System;

public static class CollatzConjecture
{
    public static int Steps(int n)
    {
        int count = 0;

        if (n <= 0)
            throw new ArgumentOutOfRangeException("number must be positive");
        
        while (n != 1)
        {
            count++;
            if (n%2 == 0)
                n = n/2;
            else
                n = 3*n + 1;
        }
        return count;
    }
}