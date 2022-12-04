using MindboxGeometry.Interfaces;

namespace Mindbox.ShapeTextInfo
{
    public class ShapeInfoProvider : IShapeDescriptionProvider
    {
        public IShapeAdditionalInfoProvider AdditionalInfoProvider { get; }

        public ShapeInfoProvider(IShapeAdditionalInfoProvider additionalInfoProvider)
        {
            AdditionalInfoProvider = additionalInfoProvider;
        }

        public string GetInfo(IShape shape)
            => ConcatInfoString($"Shape type:{shape.GetType().Name}",
                $"Square:{shape.Square}",
                shape.Accept(AdditionalInfoProvider));

        private string ConcatInfoString(params string[] lines)
            => String.Join(Environment.NewLine, lines.Where(line => !String.IsNullOrWhiteSpace(line)));
    }
}