using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MBTestLib
{
    public abstract class Figure
    {
        public double Square { get; set; } 

        public abstract double CalculateSquare();

        public Figure ()
        {
            Square = CalculateSquare();
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }

        public override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }

        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Negative radius!");

            Radius = radius;
        }
        
        }
    public class Triangle : Figure
    {
        public bool IsRightAngled { get; set; }

        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }

        public override double CalculateSquare()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            double firstSideCoef = semiPerimeter - FirstSide;
            double secondSideCoef = semiPerimeter - SecondSide;
            double thirdSideCoef = semiPerimeter - ThirdSide;

            return Math.Sqrt(semiPerimeter * firstSideCoef * secondSideCoef * thirdSideCoef);
        }

        public bool CheckIsRightAngled()
        {
            var maxSide = new[] { FirstSide, SecondSide, ThirdSide }.Max();
            var maxSideSqr = maxSide * maxSide;
            return maxSideSqr + maxSideSqr == FirstSide * FirstSide + SecondSide * SecondSide + ThirdSide * ThirdSide;
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
                throw new ArgumentOutOfRangeException("Negative side!");

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            IsRightAngled = CheckIsRightAngled();
        }
    }
}
