using System;

public static class Triangle
{
    public enum Kind
    {
        Equilateral,
        Isosceles,
        Scalene,
        NotATriangle
    }
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return KindFromSides(side1, side2, side3, Kind.Scalene);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        return KindFromSides(side1, side2, side3, Kind.Isosceles);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return KindFromSides(side1, side2, side3, Kind.Equilateral);
    }
    public static bool KindFromSides(double a, double b, double c, Kind k)
    {
        // Check if triangle
        if (a <= 0 || b <= 0 || c <= 0) // Negative or 0 sides
        {
            return false;
        } else if (a + b < c || a + c < b || b + c < a) // Triangle inequality fails
        {
            return false;
        }

        switch (k)
        {
            case Kind.Equilateral:
                return a == b && b == c;
            case Kind.Isosceles:
                return a == b || b == c || a == c;
            case Kind.Scalene:
                return a != b && b != c && a != c;
            default:
                return false;
        }
    }
}