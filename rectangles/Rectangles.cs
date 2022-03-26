using System;
using System.Collections.Generic;


var strings = new[]
        {
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        };

Rectangles.Count(strings);

public static class Rectangles
{

    // A single x-y coordinate
    public class coord {
        public int x;
        public int y;
    }

    // A board
    public class board {
        public int width, height;
        public Dictionary<coord, string> points;
        public List<coord> filter (string c)
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
    public class rectangle {
        public int[] x = new int[2];
        public int[] y = new int[2];
    }

    public static int Count(string[] diagram)
    {
        foreach (string row in diagram)
        {
            Console.WriteLine(row);
        };

        // ##########################################################
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

        // Validate
        Console.WriteLine($"width: {myBoard.width}");
        Console.WriteLine($"height: {myBoard.height}");

        // 2. Loop through all the "+", and for each one, see if a 4-sided rectangle can be formed.
        var groupByX = new Dictionary<int, List<int>>(); // Map to group the co-ordinates by X for easier calculations
        var rectangles = new List<rectangle>(); // List of rectangles

        // Do a pass through our list of "+" points and create a dictionary, grouping them by x coordinate.
        // Basically, each x coordinate corresponds to a list of y coordinates.
        List<int> current_Y;
        foreach(coord c in myBoard.filter("+"))
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
        for (int x1 = 0; x1 < width; x1++)
        {
            for (int x2 = x1 + 1; x2 < width; x2++)
            {
                if (groupByX[x1] != null && groupByX[x2] != null) { // Valid X values
                    var x = new int[2] { x1, x2 };



                }
            }
        }


        // ##########################################################
        Console.WriteLine("\ndone.\n");
        return 0;
    }

    // Find the intersection of two lists
    public static int[] intersection(int[] x1, int[] x2)
    {

        // Continue from here
    }
}