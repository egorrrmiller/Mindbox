namespace MindboxGeometry;

public class Shape
{
    public static Circle CircleFromRadius(double radius)
    {
        if (!(radius > Double.Epsilon))
            throw new ArgumentOutOfRangeException(nameof(radius));
        return new Circle(radius);
    }
    
    public static Triangle TriangleFromSides(double firstSide, double secondSide, double thirdSide)
    {
        if (!(firstSide > Double.Epsilon))
            throw new ArgumentOutOfRangeException(nameof(firstSide));
        if (!(secondSide > Double.Epsilon))
            throw new ArgumentOutOfRangeException(nameof(secondSide));
        if (!(thirdSide > Double.Epsilon))
            throw new ArgumentOutOfRangeException(nameof(thirdSide));
        if (firstSide + secondSide + thirdSide < Math.Max(firstSide, Math.Max(secondSide, thirdSide)) * 2)
            throw new ArgumentException("Lesser sides sum must be greater than bigger side");

        return new Triangle(firstSide, secondSide, thirdSide);
    }
}