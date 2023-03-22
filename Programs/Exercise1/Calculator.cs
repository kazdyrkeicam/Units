namespace ConsoleApp1;

public class Calculator
{
    public double Add(double x, double y)
    {
        return Math.Round(x + y, 3);
    }

    public double Sub(double x, double y)
    {
        return Math.Round(x - y, 3);
    }

    public double Multiple(double x, double y)
    {
        return Math.Round(x * y, 3);
    }

    public double Divide(double x, double y)
    {
        return Math.Round(x / y, 3);
    }
}