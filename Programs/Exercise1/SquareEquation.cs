namespace ConsoleApp1;

public class SquareEquation
{
    private double a;
    private double b;
    private double c;

    public SquareEquation(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double Delta()
    {
        return Math.Pow(b, 2) - (4 * a * c);
    }

    public IList<double> Results(double delta)
    {
        var result = new List<double>(2);
        if (delta > 0)
        {
            var x1 = Math.Round(((b * -1) - delta) / (2 * a), 2);
            var x2 = Math.Round(((b * -1) + delta) / (2 * a), 2);
            result.Add(x1);
            result.Add(x2);
        }
        else if (delta == 0)
        {
            var x = Math.Round((b * -1) / (2 * a), 2);
            result.Add(x);
        }

        return result;
    }
}