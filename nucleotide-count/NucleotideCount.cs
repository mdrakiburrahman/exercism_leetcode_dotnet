using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    static Dictionary<char, int> map;
    public static IDictionary<char, int> Count(string sequence)
    {
        map = new Dictionary<char, int> // <-- initialize the map
                {
                    ['A'] = 0,
                    ['C'] = 0,
                    ['G'] = 0,
                    ['T'] = 0
                };

        foreach(char c in sequence)
        {
            if(!map.ContainsKey(c))
            {
                throw new ArgumentException("Invalid nucleotide in strand");
            }
            map[c]++;
        }
        return map;
    }
}