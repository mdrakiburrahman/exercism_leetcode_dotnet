using System;
using System.Collections.Generic;

// // 1.
// var prod = new ProductionRemoteControlCar();
// var exp = new ExperimentalRemoteControlCar();
// TestTrack.Race(prod);
// TestTrack.Race(exp);

// // 2.
// Console.WriteLine(prod.DistanceTravelled);
// Console.WriteLine(exp.DistanceTravelled);

// // 3.
// var prc1 = new ProductionRemoteControlCar();
// var prc2 = new ProductionRemoteControlCar();
// prc1.NumberOfVictories = 3;
// prc2.NumberOfVictories = 2;
// var rankings = TestTrack.GetRankedCars(prc1, prc2);
// Console.WriteLine(rankings[1] == prc1);
// Console.WriteLine(rankings[1] == prc2);

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
    public int CompareTo(ProductionRemoteControlCar other)
    {
        return this.NumberOfVictories >= other.NumberOfVictories ? 1 : -1;
    }
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
