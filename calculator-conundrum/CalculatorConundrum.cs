using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
            case "*":
                return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}";
            case "/":
                if (operand2 == 0)
                {
                    return "Division by zero is not allowed.";
                } else {
                    return $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}";
                }
            default:
                switch (operation) // Exception based on operation
                {
                    case "-":
                        throw new ArgumentOutOfRangeException("Subtraction is not implemented: ", operation);
                    case "":
                        throw new ArgumentException("Empty operation not permitted: ", operation);
                    case null:
                        throw new ArgumentNullException("Null operation not permitted: ", operation);
                    default:
                        throw new ArgumentOutOfRangeException("Who knows whut happened: ", operation);
                }
        }
    }
}
