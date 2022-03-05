using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; set; }
    public void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
    // Note that CompareTo does some voodoo magic with the NumberofVictories to make this work.
    public int CompareTo(ProductionRemoteControlCar other) => this.NumberOfVictories.CompareTo(other.NumberOfVictories);
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        // The default sort order for cars should be ascending order of victories.
        var cars = new List<ProductionRemoteControlCar> { prc1, prc2 };
        cars.Sort(); // Note that because of the interface we can do this
        return cars;
    }
}
