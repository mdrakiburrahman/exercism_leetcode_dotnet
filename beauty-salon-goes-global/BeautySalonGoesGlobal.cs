using System;
using System.Globalization;

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
        DateTime dateResult; // Return variable
        CultureInfo culture = GetCultureInfo(location); // Get culture from custom method
        if (!DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out dateResult)) // If pasring is successful, updates TryParse updates dateResult
        {
            // Otherwise, we catch the boolean and return the min value
            dateResult = DateTime.MinValue;
        }   
        return dateResult;
    }
}
