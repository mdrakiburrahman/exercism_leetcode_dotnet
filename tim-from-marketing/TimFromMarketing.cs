using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {   
        department = department?.ToUpper();
        if (department == null) {
            department = "OWNER";
        }
        if (id == null)
        {
            return $"{name} - {department}";
        }
        else
        {
            return $"[{id}] - {name} - {department}";
        }
    }
    // MAIN FOR TEST
    // public static void Main(string[] args)
    // {
    //     Console.WriteLine(Print(id: 734, name: "Ernest Johnny Payne", department: "Strategic Communication"));
    //     Console.WriteLine(Print(id: null, name: "Jane Johnson", department: "Procurement"));
    //     Console.WriteLine(Print(254, "Charlotte Hale", department: null));
    //     Console.WriteLine(Print(id: null, "Charlotte Hale", department: null));
    // }
}
