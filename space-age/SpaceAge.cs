using System;

public class SpaceAge
{
    private int seconds;
    public double earthYear = 31557600;
    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    public double OnEarth()
    {
        return seconds / (earthYear * 1); 
    }

    public double OnMercury()
    {
        return seconds / (earthYear * 0.2408467);
    }

    public double OnVenus()
    {
        return seconds / (earthYear * 0.61519726);
    }

    public double OnMars()
    {
        return seconds / (earthYear * 1.8808158);
    }

    public double OnJupiter()
    {
        return seconds / (earthYear * 11.862615);
    }

    public double OnSaturn()
    {
        return seconds / (earthYear * 29.447498);
    }

    public double OnUranus()
    {
        return seconds / (earthYear * 84.016846);
    }

    public double OnNeptune()
    {
        return seconds / (earthYear * 164.79132);
    }
}