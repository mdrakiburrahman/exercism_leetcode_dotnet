using System;

public class Player
{
    public int RollDie()
    {
        return new Random().Next(1, 18);
    }   

    public double GenerateSpellStrength()
    {
        return (double)new Random().Next(1, 100);
    }
}
