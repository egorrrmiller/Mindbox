using FluentAssertions;
using MindboxGeometry;
using MindboxGeometry.Interfaces;
using Moq;

namespace MindboxTest
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1, 3.14)]
        [InlineData(10, 314)]
        public void Square(double radius, double square)
            => new Circle(radius).Square.Should().BeApproximately(square, square * 0.01);

        [Fact]
        public void Accept_VisitWithCircle()
        {
            var visitorMoq = new Mock<IShapeVisitor<int>>();
            var circle     = new Circle(1);

            circle.Accept(visitorMoq.Object);

            visitorMoq.Verify(visitor => visitor.Visit(circle), Times.Once);
        }
    }
}