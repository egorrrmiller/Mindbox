namespace MindboxGeometry.Interfaces
{
    public interface IShapeVisitor<out T>
    {
        T Visit(Circle circle);
        T Visit(Triangle triangle);
    }
}