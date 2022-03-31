using System;
public class Clock
{
    public int _hours { get; set; }
    public int _minutes { get; set; }
    public Clock(int hours, int minutes)
    {
        // Turn everything into minutes
        minutes = hours * 60 + minutes;

        // Get hours and mins
        hours = (minutes / 60) % 24;
        minutes = minutes % 60;

        // Deal with negatives
        if (minutes < 0)
        {
            hours -= 1; // Roll back one hour
            minutes += 60; // Make mins positive
        }
        if (hours < 0)
        {
            hours += 24; // Normalize to 24 hour format
        }
        this._hours = hours;
        this._minutes = minutes;
    }
    public override string ToString()
    {
        return $"{this._hours:D2}:{this._minutes:D2}";
    }
    public override bool Equals(object other)
    {
        return this._hours == (other as Clock)._hours && this._minutes == (other as Clock)._minutes;
    }
    public override int GetHashCode()
    {
        return this._hours.GetHashCode() ^ this._minutes.GetHashCode();
    }
    public Clock Add(int minutesToAdd)
    {
        return new Clock(this._hours, this._minutes + minutesToAdd);
    }
    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(this._hours, this._minutes - minutesToSubtract);
    }
}
