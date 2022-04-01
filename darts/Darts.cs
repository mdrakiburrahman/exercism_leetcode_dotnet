using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var r = Math.Sqrt(x * x + y * y);
        if (r > 10) // Outside
            return 0;
        if (r > 5 && r <= 10) // Outer circle
            return 1;
        if (r > 1 && r <= 5) // Middle circle
            return 5;
        if (r <= 1) // Inner circle
            return 10;
        return -1; // Not possible
    }
}
