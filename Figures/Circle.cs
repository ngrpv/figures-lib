namespace Figures;

public class Circle : IFigure
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius should be non-negative");
        
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}