namespace MindboxGeometry.Interfaces
{
    public interface IShapeInfoProvider<out T>
    {
        T GetInfo(IShape shape);
    }
}