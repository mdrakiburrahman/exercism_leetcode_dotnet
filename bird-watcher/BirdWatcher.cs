using System;

// int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
// var birdCount = new BirdCount(birdsPerDay);
// Console.WriteLine($"1: {String.Join(", ", BirdCount.LastWeek())}");
// Console.WriteLine($"2: {birdCount.Today()}");
// birdCount.IncrementTodaysCount();
// Console.WriteLine($"2: {birdCount.Today()}");
// Console.WriteLine($"4: {birdCount.HasDayWithoutBirds()}");
// Console.WriteLine($"5: {birdCount.CountForFirstDays(4)}");
// Console.WriteLine($"6: {birdCount.BusyDays()}");

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today()
    {
        return this.birdsPerDay[this.birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        this.birdsPerDay[this.birdsPerDay.Length - 1]++; // This works in C# - you can increment an array element in place
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int count in this.birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            count += this.birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (int count in this.birdsPerDay)
        {
            if (count >= 5)
            {
                busyDays++;
            }
        }
        return busyDays;
    }
}
