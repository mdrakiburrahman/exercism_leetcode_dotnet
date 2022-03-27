using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    public List<int> list;
    public HighScores(List<int> list)
    {
        this.list = list;
    }

    // Returns list of scores as is
    public List<int> Scores()
    {
        return list;
    }

    // Returns latest score
    public int Latest()
    {
        return list[list.Count - 1];
    }

    // Return largest score
    public int PersonalBest()
    {
        return list.Max();
    }

    // Return top three scores
    public List<int> PersonalTopThree()
    {
        var sortedList = new List<int>(list); // Copy without reference
        sortedList.Sort(); // Sorts in place
        sortedList.Reverse(); // Reverses in place

        if (sortedList.Count < 3)
        {
            return sortedList;
        }
        else
        {
            return sortedList.GetRange(0, 3);
        }
    }
}