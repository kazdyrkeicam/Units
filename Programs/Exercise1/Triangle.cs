namespace ConsoleApp1;

public class Triangle
{
    private int a;
    private int b;
    private int c;

    public Triangle(int a, int b, int c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new Exception("Cannot create triangle");
        }
        
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double Area()
    {
        var p = (a + b + c) / 2;
        return Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 2);
    }
}