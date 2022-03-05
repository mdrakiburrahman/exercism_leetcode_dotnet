using System;

class WeighingMachine
{
    public int Precision { get; }

    private double _weight;
    public double Weight 
    { 
        get => _weight; 
        set
        {
            if ((value > 0))
            {
                 _weight = value;
            }
            else 
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public double TareAdjustment { get; set; } = 5.0; // Init

    public string DisplayWeight
    {
        get
        {
            return (Weight - TareAdjustment).ToString("0.000") + " kg";
        }
    }

    public WeighingMachine(int precision) 
    {
        this.Precision = precision;
    }
}
