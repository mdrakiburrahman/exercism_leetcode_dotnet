using System;
using System.Globalization;



Console.WriteLine($"1: {Appointment.ShowLocalTime(new DateTime(2030, 7, 25, 13, 45, 0))}");

Console.WriteLine($"2: {Appointment.Schedule("7/25/2030 13:45:00", Location.Paris)}");

Console.WriteLine($"3: {Appointment.GetAlertTime(new DateTime(2030, 7, 25, 14, 45, 0), AlertLevel.Early)}");
Console.WriteLine($"3: {Appointment.GetAlertTime(new DateTime(2030, 7, 25, 14, 45, 0), AlertLevel.Late)}");

Console.WriteLine($"4: {Appointment.HasDaylightSavingChanged(new DateTime(2020, 3, 30, 14, 45, 0), Location.London)}");
Console.WriteLine($"4: {Appointment.HasDaylightSavingChanged(new DateTime(2019, 3, 13, 0, 0, 0), Location.NewYork)}");
Console.WriteLine($"4: {Appointment.HasDaylightSavingChanged(new DateTime(2019, 12, 25, 0, 0, 0), Location.NewYork)}");

Console.WriteLine($"5: {Appointment.NormalizeDateTime("25/11/2019 13:45:00", Location.London)}");

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }


    public static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        switch (location)
        {
            case Location.NewYork:
                return TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            case Location.London:
                return TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            case Location.Paris:
                return TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            default:
                throw new ArgumentException("Invalid location");
        }
    }

    public static CultureInfo GetCultureInfo(Location location)
    {
        switch (location)
        {
            case Location.NewYork:
                return new CultureInfo("en-US");
            case Location.London:
                return new CultureInfo("en-GB");
            case Location.Paris:
                return new CultureInfo("fr-FR");
            default:
                throw new ArgumentException("Invalid location");
        }
    }

    // Takes a location and time string and returns the UTC time of the appointment.
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var localTime = DateTime.Parse(appointmentDateDescription); // Convert to datetime
        TimeZoneInfo zone = GetTimeZoneInfo(location); // Get the timezone info from location enum

        return TimeZoneInfo.ConvertTimeToUtc(localTime, zone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddHours(-24);
            case AlertLevel.Standard:
                return appointment.AddHours(-1).AddMinutes(-45);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
            default:
                throw new ArgumentException("Invalid alert level");
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo zone = GetTimeZoneInfo(location);

        // Check if 7 days ago was DST and today is not DST or vice versa
        return !(zone.IsDaylightSavingTime(dt.AddDays(-7)) == zone.IsDaylightSavingTime(dt));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        DateTime dateResult;

        // Parse a date and time with no styles.
        string dateString = "03/01/2009 10:00 AM";
        CultureInfo culture = GetCultureInfo(location);
        DateTimeStyles styles = DateTimeStyles.None;
        if (DateTime.TryParse(dateString, culture, styles, out dateResult))
            Console.WriteLine("{0} converted to {1} {2}.", dateString, dateResult, dateResult.Kind);
        else
            Console.WriteLine("Unable to convert {0} to a date and time.", dateString);

        return DateTime.MinValue;
    }
}
