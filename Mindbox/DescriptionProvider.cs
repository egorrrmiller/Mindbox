using Mindbox.ShapeTextInfo;

namespace Mindbox;

public class Description
{
    public static IShapeDescriptionProvider DescriptionProvider { get; } = new ShapeInfoProvider(new ShapeAdditionalInfoProvider());

}