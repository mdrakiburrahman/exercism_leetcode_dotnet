using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
      switch (shirtNum)
      {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                 throw new ArgumentOutOfRangeException(nameof(shirtNum), "Shirt number must be between 1 and 11.");
      }
    }

    public static string AnalyzeOffField(object report)
    {
        // So report can be of any type basically
        switch (report)
        {
            case int supporters:
                return $"There are {supporters} supporters at the match.";
            case string announcements:
                return announcements;
            case Incident incident:
                switch(incident)
                {
                    case Injury injury:
                        return $"Oh no! {injury.GetDescription()} Medics are on the field.";
                    default:
                        return incident.GetDescription();
                }
            case Manager manager:
                switch (manager.Club)
                {
                    case null:
                        return $"{manager.Name}";
                    default:
                        return $"{manager.Name} ({manager.Club})";
                }
            default:
                throw new ArgumentException("Type not suported!");
        }
    }
}
