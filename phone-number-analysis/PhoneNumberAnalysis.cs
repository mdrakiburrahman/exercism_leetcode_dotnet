using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        return(IsNewYork: phoneNumber.Split('-')[0] == "212",
               IsFake: phoneNumber.Substring(4,3) == "555", 
               LocalNumber: phoneNumber.Substring(8,4));
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
    // MAIN FOR TEST
    // public static void Main(string[] args)
    // {
    //     Console.WriteLine(Analyze("631-555-1234"));
    //     Console.WriteLine(IsFake(Analyze("631-555-1234")));
    // }
}
