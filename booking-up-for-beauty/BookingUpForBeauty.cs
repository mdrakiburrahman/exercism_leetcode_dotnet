using System;
using System.Globalization;
using System.Threading;

static class Appointment
{
    private static DateTime dateTime;
    public static DateTime Schedule(string appointmentDateDescription)
    {
        dateTime = DateTime.Parse(appointmentDateDescription);
        return dateTime;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return (appointmentDate.Hour >= 12 && appointmentDate.Hour < 18); // afternoon (>= 12:00 and < 18:00)
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
    }
}
