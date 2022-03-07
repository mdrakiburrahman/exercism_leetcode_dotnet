using System;
using System.Collections.Generic;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord top_left { get; }
    public Coord top_right { get; }
    public Coord bottom_left { get; }
    public Coord bottom_right { get; }
    public Plot(Coord top_left, Coord top_right, Coord bottom_left, Coord bottom_right)
    {
        this.top_left = top_left;
        this.top_right = top_right;
        this.bottom_left = bottom_left;
        this.bottom_right = bottom_right;
    }
    // Crappy implementation of perimeter, not using Pythagoras for simple tests
    public ushort LongestSide()
    {
        var x_length = Math.Abs(top_left.X - top_right.X) + Math.Abs(bottom_left.X - bottom_right.X);
        var y_length = Math.Abs(top_left.Y - bottom_left.Y) + Math.Abs(top_right.Y - bottom_right.Y);
        return (ushort)Math.Max(x_length, y_length);
    }
    public override bool Equals(object other)
    
    {
        // Note the syntax for overriding Equals in struct is different than class
        if (!(other is Plot))
          return false;

        Plot my_plot = (Plot)other;

        return top_left.Equals(my_plot.top_left) &&
            top_right.Equals(my_plot.top_right) &&
            bottom_left.Equals(my_plot.bottom_left) &&
            bottom_right.Equals(my_plot.bottom_right);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(top_left, top_right, bottom_left, bottom_right);
    }
}


public class ClaimsHandler
{
    // Cache the Plots that came in
    public List<Plot> Plots { get; set; } = new List<Plot>();
    // For storing hashes of the Plots to spot duplicates
    private HashSet<Plot> registered = new HashSet<Plot>();
    
    public void StakeClaim(Plot plot)
    {
        if (!registered.Contains(plot))
        {
            Plots.Add(plot);
            registered.Add(plot);
        }
    }

    public bool IsClaimStaked(Plot plot)
    {
        return registered.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return plot.Equals(Plots[Plots.Count - 1]);
    }

    public Plot GetClaimWithLongestSide()
    {
        ushort longest_length = 0;
        Plot longest_plot = new Plot();
        foreach(Plot p in Plots)
        {
            if (p.LongestSide() > longest_length)
            {
                longest_length = p.LongestSide();
                longest_plot = p;
            }
        }
        return longest_plot;
    }
}
