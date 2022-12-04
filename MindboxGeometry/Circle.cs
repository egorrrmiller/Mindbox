using MindboxGeometry.Interfaces;

namespace MindboxGeometry;

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Square => Math.PI * Radius * Radius;

    public T      Accept<T>(IShapeVisitor<T> shapeVisitor)
        => shapeVisitor.Visit(this);
}