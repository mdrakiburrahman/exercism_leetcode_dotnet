using System;

public static class Globals {
    public static int[] GlobalNum = new int[] { 0, 0, 0 }; // can change because not const
}

public class Robot
{
    private string myName;
    public string Name
    {
        get { return myName; }
        set { myName = value;}
    }

    public Robot()
    {
        // Calculate new name based on GlobalNum
        myName = calculateName(Globals.GlobalNum);
        // Increment GlobalNum
        Globals.GlobalNum = incrementNum(Globals.GlobalNum);
        // Set name
        this.myName = calculateName(Globals.GlobalNum);
    }
    public void Reset()
    {
        // Increment GlobalNum to get non-conflicting name
        Globals.GlobalNum = incrementNum(Globals.GlobalNum);
        // Calculate new name based on GlobalNum
        myName = calculateName(Globals.GlobalNum);
        // Increment GlobalNum again for next guy
        Globals.GlobalNum = incrementNum(Globals.GlobalNum);
        // Set name
        this.myName = calculateName(Globals.GlobalNum);
    }
    // Increment GlobalNum according to our algorithm
    public int[] incrementNum(int[] num)
    {
        num[2]++;
        // Increment second char
        if(num[2] >= 500)
        {
            num[1]++;
            num[2] = 0; // Back to 0
        }
        // Increment first char
        if (num[1] >= 26)
        {
            num[0]++;
            num[1] = 0; // Back to 0
        }
        // Check if we have reached the end
        if (num[0] >= 26 && num[2] > 0)
        {
            throw new Exception("We have reached the end of the alphabet");
        }
        return num;
    }

    // Uses num to deterministically calculate the name of the robot
    public string calculateName(int[] num)
    {
        // Represents 'AA000'
        var arr = new int[] { 65, 65, 0 };
        string str = "";
        // Calculate name[0]
        str += (char)(arr[0] + num[0]);
        // Calculate name[1]
        str += (char)(arr[1] + num[1]);
        // Pad num[2] with zeros such that it is 3 digits long
        str += string.Format("{0:D3}", num[2]);
        return str;
    }
}