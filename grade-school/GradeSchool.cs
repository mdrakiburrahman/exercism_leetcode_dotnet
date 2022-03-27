using System;
using System.Collections.Generic;

public class GradeSchool
{
    // We use SortedDictionary because we need grades in order
    private SortedDictionary<int, List<string>> grades;

    public GradeSchool()
    {
        this.grades = new SortedDictionary<int, List<string>>();
    }

    // Add student to a Grade - whether or not the Grade exists is handled
    public void Add(string student, int g)
    {
        // Check if Dictionary has grade
        if (grades.ContainsKey(g))
        {
            // Add studnent to grade
            grades[g].Add(student); 
        } else {
            // Add a new list of students for the grade
            grades.Add(g, new List<string> { student } );
        }
    }

    // First sorts grades, then names within grades, then appends it all and returns names
    public IEnumerable<string> Roster()
    {
        var roster = new List<string>();
        foreach(var grade in grades.Keys)
        {
            roster.AddRange(Grade(grade));
        }
        return roster;
    }

    // Returns the list of students in a grade in Alphabetical order
    public IEnumerable<string> Grade(int grade)
    {
        // Handle if key is not in dictionary
        if (!this.grades.ContainsKey(grade))
        {
            return new List<string>();
        }

        this.grades[grade].Sort();
        return this.grades[grade];
    }
}