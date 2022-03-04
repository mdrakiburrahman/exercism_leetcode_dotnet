using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message) 
    {
        this.Operand1 = operand1;
        this.Operand2 = operand2;     
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
        try {
            // Call multiply, if no exception is thrown, return "Multiply succeeded"
            this.Multiply(x, y);
            return "Multiply succeeded";
        } catch (CalculationException e) when (e.Operand1 < 0 && e.Operand2 < 0) {
            // If x and y is negative, return "Multiply failed for negative operands. ${message}"
            return $"Multiply failed for negative operands. {e.Message}";
        }  catch (CalculationException e) {
            // If at least x or y is positive and exception still thrown, return "Multiply failed for mixed or positive operands. ${message}"
            return $"Multiply failed for mixed or positive operands. {e.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            this.calculator.Multiply(x, y);
        }
        catch (OverflowException e) // If multiply fails in Calculator - catch Overflow
        {
            // Wrap operands in CalculationException
            throw new CalculationException(x, y, e.Message, e);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
