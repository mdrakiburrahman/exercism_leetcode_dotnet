using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        foreach(var keyValue in old)
        {
            foreach(var v in keyValue.Value)
            {
                result.Add(v.ToLower(), keyValue.Key);
            }
        }
        return result;
    }
}