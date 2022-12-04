using FluentAssertions;
using MindboxGeometry;

namespace MindboxTest
{
    public class ShapeTests
    {
        [Fact]
        public void CircleFromRadius_PositiveRadius_Success()
            => Shape.CircleFromRadius(1).Should().NotBeNull();

        [Fact]
        public void CircleFromRadius_ZeroRadius_Fail()
            => CreateCircleFromRadius(0).Should().Throw<ArgumentOutOfRangeException>();

        [Fact]
        public void CircleFromRadius_NegativeRadius_Fail()
            => CreateCircleFromRadius(-1).Should().Throw<ArgumentOutOfRangeException>();

        [Fact]
        public void CircleFromRadius_NaNRadius_Fail()
            => CreateCircleFromRadius(double.NaN).Should().Throw<ArgumentOutOfRangeException>();

        [Theory]
        [InlineData(3, 4, 5, false)]
        [InlineData(1, 1, 1, false)]
        [InlineData(3, 4, -1, true)]
        [InlineData(3, 4, 10, true)]
        [InlineData(3, 4, double.NaN, true)]
        public void TriangleFromSides(double firstSide, double secondSide, double thirdSide, bool shouldFail)
        {
            if (!shouldFail)
            {
                Shape.TriangleFromSides(firstSide, secondSide, thirdSide).Should().NotBeNull();
                Shape.TriangleFromSides(thirdSide, firstSide, secondSide).Should().NotBeNull();
                Shape.TriangleFromSides(secondSide, thirdSide, firstSide).Should().NotBeNull();
            }
            else
            {
                CreateTriangleFromSides(firstSide, secondSide, thirdSide).Should().Throw<ArgumentException>();
                CreateTriangleFromSides(thirdSide, firstSide, secondSide).Should().Throw<ArgumentException>();
                CreateTriangleFromSides(secondSide, thirdSide, firstSide).Should().Throw<ArgumentException>();
            }
        }

        private static Action CreateCircleFromRadius(double radius) => () => Shape.CircleFromRadius(radius);
        private static Action CreateTriangleFromSides(double firstSide, double secondSide, double thirdSide)
            => () => Shape.TriangleFromSides(firstSide, secondSide, thirdSide);
    }
}