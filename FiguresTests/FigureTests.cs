using System;
using Figures;
using FluentAssertions;
using NUnit.Framework;

namespace FiguresTests;

public class ShapeTests
{
    [Test]
    public void CircleAreaTest()
    {
        var circle = new Circle(5);
        circle.CalculateArea()
            .Should().Be(Math.PI * 25);
    }
    
    [Test]
    public void CircleAreaApproximatelyTest()
    {
        var circle = new Circle(3.3242);
        circle.CalculateArea()
            .Should().BeApproximately(Math.PI * 3.3242 * 3.3242, 1e-6);
    }
    
    [Test]
    public void CircleNegativeRaduisTest()
    {
        var circleCreation = () => new Circle(-5);
        circleCreation.Should().Throw<ArgumentException>();
    }

    [Test]
    public void TriangleAreaTest()
    {
        var triangle = new Triangle(3.5, 4, 5);
        triangle.CalculateArea().Should().BeApproximately(6.952686, 1e-6);
    }

    [Test]
    public void RightAngledTriangleTest()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.IsRightAngled().Should().BeTrue();
    }
    
    [Test]
    public void NotRightAngledTriangle()
    {
        var triangle = new Triangle(3, 3.33, 5);
        triangle.IsRightAngled().Should().BeFalse();
    }
    
    [Test]
    public void NotRightAngledTriangleButClose()
    {
        var triangle = new Triangle(3, 3.999, 5);
        triangle.IsRightAngled().Should().BeFalse();
    }

    [Test]
    public void NotATriangleTest()
    {
        var act = () => new Triangle(1, 2, 3);
        act.Should().Throw<ArgumentException>();
    }
    
    [Test]
    public void NegativeSideTriangleTest()
    {
        var act = () => new Triangle(1, -2.5, 3);
        act.Should().Throw<ArgumentException>();
    }
}