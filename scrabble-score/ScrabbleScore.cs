using System;
using System.Collections.Generic;

public static class ScrabbleScore
{

    public static Dictionary<string, int> makeScrabbleDict()
    {
        Dictionary<string, int> scrabbleDict = new Dictionary<string, int>();
        
        var oneArray = new string[] {"A", "E", "I", "O", "U", "L", "N", "R", "S", "T"};
        var twoArray  = new string[] {"D", "G"};
        var threeArray = new string[] {"B", "C", "M", "P"};
        var fourArray = new string[] {"F", "H", "V", "W", "Y"};
        var fiveArray = new string[] {"K"};
        var eightArray = new string[] {"J", "X"};
        var tenArray = new string[] {"Q", "Z"};

        foreach(string letter in oneArray)
        {
            scrabbleDict.Add(letter.ToString(), 1);
        }
        foreach(string letter in twoArray)
        {
            scrabbleDict.Add(letter.ToString(), 2);
        }
        foreach(string letter in threeArray)
        {
            scrabbleDict.Add(letter.ToString(), 3);
        }
        foreach(string letter in fourArray)
        {
            scrabbleDict.Add(letter.ToString(), 4);
        }
        foreach(string letter in fiveArray)
        {
            scrabbleDict.Add(letter.ToString(), 5);
        }
        foreach(string letter in eightArray)
        {
            scrabbleDict.Add(letter.ToString(), 8);
        }
        foreach(string letter in tenArray)
        {
            scrabbleDict.Add(letter.ToString(), 10);
        }
        return scrabbleDict;
    }

    public static int Score(string input)
    {
        var scrabbleDict = makeScrabbleDict();

        int score = 0;

        foreach(char letter in input)
        {
            score += scrabbleDict[char.ToUpper(letter).ToString()];
        }
        return score;
    }
}