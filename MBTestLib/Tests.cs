using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MBTestLib;

namespace MBTestLib
{
    public class Tests
    {
        [Fact]
        public void Circle_RadiusIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-2));
        }

        [Fact]
        public void Circle_ShouldCalculateSquare()
        {
            Circle circle = new Circle(2);
            double? expected = Math.PI * 2 * 2;
            double? actual = circle.CalculateSquare();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_ShouldCalculateSquare()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            double? expected = 6;
            double? actual = triangle.CalculateSquare();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_SidesIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -2, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 0, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, -2, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, 0, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, -2, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2, -2, -2));
        }

        [Fact]
        public void Triangle_ShouldBeRightAngled()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            bool? expected = true;
            bool? actual = triangle.CheckIsRightAngled();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_ShouldNotBeRightAngled()
        {
            Triangle triangle = new Triangle(6, 7, 8);
            bool? expected = false;
            bool? actual = triangle.CheckIsRightAngled();
            Assert.Equal(expected, actual);
        }
    }
}
