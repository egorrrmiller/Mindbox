using FluentAssertions;
using MindboxGeometry;
using MindboxGeometry.Interfaces;
using Moq;

namespace MindboxTest
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(2, 2, 2, 1.73)]
        [InlineData(2, 3, 4, 2.9)]
        [InlineData(4, 2, 3, 2.9)]
        public void Square(double firstSide, double secondSide, double thirdSide, double square)
            => new Triangle(firstSide, secondSide, thirdSide).Square.Should().BeApproximately(square, square * 0.01);

        [Theory]
        [InlineData(2, 2, 2, false)]
        [InlineData(3, 4, 5, true)]
        [InlineData(5, 4, 3, true)]
        public void IsRightAngled(double firstSide, double secondSide, double thirdSide, bool isRight)
            => new Triangle(firstSide, secondSide, thirdSide).IsRightAngled.Should().Be(isRight);


        [Fact]
        public void Accept_VisitWithTriangle()
        {
            var visitorMoq = new Mock<IShapeVisitor<int>>();
            var circle     = new Triangle(1, 1, 1);

            circle.Accept(visitorMoq.Object);

            visitorMoq.Verify(visitor => visitor.Visit(circle), Times.Once);
        }
    }
}