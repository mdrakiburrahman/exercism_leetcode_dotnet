using System;

class RemoteControlCar
{
    private int distance = 0; // Distance driven by the car
    private int battery = 100; // Battery level
    public static RemoteControlCar Buy()
    {   
        var car = new RemoteControlCar();
        car.distance = 0;
        car.battery = 100;
        return car;
    }

    public string DistanceDisplay()
    {
        return $"Driven {distance} meters";
    }

    public string BatteryDisplay()
    {
        if (battery != 0)
        {
            return $"Battery at {battery}%";
        } else if (battery == 0) {
            return "Battery empty";
        } else {
            return "Battery is ?";
        }
    }

    public void Drive()
    {
        if (battery > 0)
        {
            distance += 20;
            battery -= 1;
        }
    }
    // MAIN FOR TEST
    // public static void Main(string[] args)
    // {
    //     var car = RemoteControlCar.Buy();
    //     Console.WriteLine($"Distance Driven: {car.DistanceDisplay()}");
    //     Console.WriteLine($"Battery Left: {car.BatteryDisplay()}");

    //     for (var i = 0; i < 1001; i++)
    //     {
    //         car.Drive();
    //     }

    //     Console.WriteLine($"Distance Driven: {car.DistanceDisplay()}");
    //     Console.WriteLine($"Battery Left: {car.BatteryDisplay()}");
    // }
}
