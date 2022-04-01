using System;

public static class Raindrops
{
    public static string Convert(int x)
    {
        string s = "";

        if (x % 3 == 0)
        {
            s += "Pling";
        }
        if (x % 5 == 0)
        {
            s += "Plang";
        }
        if (x % 7 == 0)
        {
            s += "Plong";
        }
        if (s == "")
        {
            s = x.ToString();
        }
        return s;
    }
}