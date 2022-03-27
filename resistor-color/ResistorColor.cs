using System;
using System.Collections.Generic;

public static class ResistorColor
{
    public static Dictionary<string, int> map = new Dictionary<string, int>() {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };
    public static int ColorCode(string color)
    {
        return map[color];
    }
    public static string[] Colors()
    {
        var myarray = new string[map.Count];
        int i = 0;
        foreach(var kvp in map) {
            myarray[i] = kvp.Key;
            i++;
        }
        return myarray;
    }
}