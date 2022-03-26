using System;
using System.Collections.Generic;

public static class Rectangles
{

    // A single x-y coordinate
    public class coord
    {
        public int x;
        public int y;

        public override bool Equals(object other) // This is needed for Custom Comparisons
        {
            return x == (other as coord).x && y == (other as coord).y;
        }
        public override int GetHashCode() // This is needed for Dictionary Comparisons
        {
            return HashCode.Combine(x, y);
        }
    }

    // A board
    public class board
    {
        public int width, height;
        public Dictionary<coord, string> points;
        public List<coord> filter(string c)
        {
            var filtered = new List<coord>();
            // Loop over all points to find the ones that match the given character
            foreach (var p in points)
            {
                if (p.Value == c) // If the value is c
                {
                    filtered.Add(p.Key); // Add the key, which is the co-ordinate
                }
            }
            return filtered;
        }
    }

    // Rectangle coordinates as integer array
    public class rectangle
    {
        public int[] x = new int[2];
        public int[] y = new int[2];
    }

    public static int Count(string[] diagram)
    {
        // Calculate the height and width of the board
        var height = diagram.Length;
        int width = 0;

        var points = new Dictionary<coord, string>();
        // Form a dictionary of the co-ordinates
        for (int i = 0; i < diagram.Length; i++)
        {
            var line = diagram[i];
            // If width is not set, set it to length of line - which is constant
            if (line.Length > width)
            {
                width = line.Length;
            }
            // Form the dictionary by looping over characters in the line
            for (int j = 0; j < line.Length; j++)
            {
                var p = new coord();
                p.x = j;
                p.y = i;
                points.Add(p, line[j].ToString());
            }
        }

        // 1. Map the co-ordinates of the board in a board object, we remove one to be zero indexed
        var myBoard = new board();
        myBoard.width = width - 1;
        myBoard.height = height - 1;
        myBoard.points = points;

        // 2. Loop through all the "+", and for each one, see if a 4-sided rectangle can be formed.
        var groupByX = new Dictionary<int, List<int>>(); // Map to group the co-ordinates by X for easier calculations
        var rectangles = new List<rectangle>(); // List of rectangles

        // Do a pass through our list of "+" points and create a dictionary, grouping them by x coordinate.
        // Basically, each x coordinate corresponds to a list of y coordinates.
        List<int> current_Y;
        foreach (coord c in myBoard.filter("+"))
        {
            // Check if the x coordinate is already in the dictionary
            if (groupByX.ContainsKey(c.x))
            {
                current_Y = groupByX[c.x]; // For the current x cord, pull out list of y's
                current_Y.Add(c.y); // Add current y
                groupByX[c.x] = current_Y; // Replace with it
            }
            else
            {
                current_Y = new List<int>();
                current_Y.Add(c.y); // Add current y
                groupByX.Add(c.x, current_Y); // Add new key to dictionary
            }
        }

        // Loop through the groups of Y's for possible X's and look for intersections
        // More than 2 intersections means we have rectangle(s)
        var intersections = new List<int>();

        for (int x1 = 0; x1 < width; x1++)
        {
            for (int x2 = x1 + 1; x2 < width; x2++)
            {
                if (groupByX.ContainsKey(x1) && groupByX.ContainsKey(x2)) // Check if the x1 and x2 are in the dictionary
                { // Valid X values
                    intersections = intersection(groupByX[x1], groupByX[x2]); // Intersection of the Y's
                    if (intersections.Count >= 2) // If rectangle
                    {
                        for (int left = 0; left < intersections.Count; left++)
                        {
                            for (int right = left + 1; right < intersections.Count; right++)
                            {
                                var myRectangle = new rectangle();
                                myRectangle.x[0] = x1;
                                myRectangle.x[1] = x2;
                                myRectangle.y[0] = intersections[left];
                                myRectangle.y[1] = intersections[right];
                                rectangles.Add(myRectangle); // Append to the list of found rectangles
                            }
                        }
                    }
                }
            }
        }
        
        // 3. Loop through the stack and check if the rectangle is valid as per the "-" and "|"
        int validRectangles = 0;

        // X1 --> X2, Y = Y1
        // X1 --> X2, Y = Y2
        // Y1 --> Y2, X = X1
        // Y1 --> Y2, X = X2
        foreach (rectangle r in rectangles)
        {
            if (traverseX(r.x[0], r.x[1], r.y[0], points) && traverseX(r.x[0], r.x[1], r.y[1], points) && traverseY(r.x[0], r.y[0], r.y[1], points) && traverseY(r.x[1], r.y[0], r.y[1], points))
            {
                validRectangles++;
            }
        }
        return validRectangles;
    }

    // Find the intersection of two lists
    public static List<int> intersection(List<int> s1, List<int> s2)
    {
        var inter = new List<int>(); // Return list
        var hash = new Dictionary<int, bool>();
        // Make a map of all integers in s1 with true
        foreach (int e in s1)
        {
            hash.Add(e, true);
        }
        // Loop through s2 and check if it is in the map
        // If so, add it to intersection if not already in there
        foreach (int e in s2)
        {
            if (hash.ContainsKey(e) && !inter.Contains(e))
            {
                inter.Add(e);
            }
        }
        return inter;
    }

    // Traverses the X axis and checks for valid characters
    public static bool traverseX(int x1, int x2, int y, Dictionary<coord, string> points)
    {           
        // Ensure everything in path is a "-" or "+"
        for (int x = x1 + 1; x < x2; x++)
        {   
            var c = new coord() { x = x, y = y };
            if (points.ContainsKey(c))
            {
                if (points[c] != "-" && points[c] != "+")
                {
                    return false;
                }
            }
        }
        return true;
    }
    // Traverses the Y axis and checks for valid characters
    public static bool traverseY(int x, int y1, int y2, Dictionary<coord, string> points)
    {   
        // Ensure everything in path is a "|" or "+"
        for (int y = y1 + 1; y < y2; y++)
        {   
            var c = new coord() { x = x, y = y };
            if (points.ContainsKey(c))
            {
                if (points[c] != "|" && points[c] != "+")
                {
                    return false;
                }
            }
        }
        return true;
    }
}