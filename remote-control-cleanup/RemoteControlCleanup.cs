using System;

public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed { get; set; }
    public interface ITelemetry
    {
        // We need to declare the methods here, and define in the interface
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
    }

    private class TelemetryImpl : ITelemetry
    {
        private RemoteControlCar car;
        public TelemetryImpl(RemoteControlCar car)
        {
            this.car = car;
        }
        public void ShowSponsor(string sponsorName)
        {
            car.SetSponsor(sponsorName);
        }
        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
            car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public ITelemetry Telemetry;

    // Constructor
    public RemoteControlCar()
    {
        Telemetry = new TelemetryImpl(this);
    }

    // Class scoped methods
    private void SetSponsor(string sponsorName)
    {
        this.CurrentSponsor = sponsorName;
    }
    private void SetSpeed(Speed speed)
    {
        this.currentSpeed = speed;
    }
    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }
    
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}
