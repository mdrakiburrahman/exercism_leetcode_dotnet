using System;

class RemoteControlCar
{
    private int speed, batteryDrain, distanceDriven, battery;
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.distanceDriven = 0;
        this.battery = 100;
    }

    public bool BatteryDrained()
    {
        return (this.battery - this.batteryDrain < 0); // If we cannot do one more drive, battery is "drained"
    }

    public int BatteryRemaining()
    {
        return this.battery;
    }

    public int DistanceDriven()
    {
        return this.distanceDriven;
    }

    public int DistanceRemaining()
    {
        return ((this.battery / this.batteryDrain) * this.speed);
    }

    public void Drive()
    {
        if (!this.BatteryDrained()) // Check if one more drive is possible
        {   
            this.battery -= this.batteryDrain;
            this.distanceDriven += this.speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(speed: 50, batteryDrain: 4);
    }
}

class RaceTrack
{
    private int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool CarCanFinish(RemoteControlCar car)
    {
        return car.DistanceDriven() + car.DistanceRemaining() >= this.distance;
    }
}
