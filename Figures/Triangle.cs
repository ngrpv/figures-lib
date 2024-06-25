namespace Figures;

public class Triangle : IFigure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    
    public Triangle(double a, double b, double c)
    {
        if(a < 0 || b < 0 || c < 0)
            throw new ArgumentException("Sides should be non-negative");
        
        if (!IsValidTriangle(a, b, c))
            throw new ArgumentException("Sides do not form a valid triangle");
        
        A = a;
        B = b;
        C = c;
    }
    
    public double CalculateArea()
    {
        var halfPerimeter = (A + B + C) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
    }

    public bool IsRightAngled()
    {
        var sides = new[] { A, B, C };
        Array.Sort(sides);
        var hypotenuse = sides[2];
        var leg1 = sides[0];
        var leg2 = sides[1];
        var sumOfSquaredLegs = leg1 * leg1 + leg2 * leg2;
        return Math.Abs(sumOfSquaredLegs - hypotenuse * hypotenuse) < 1e-10;
    }
    
    private static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}