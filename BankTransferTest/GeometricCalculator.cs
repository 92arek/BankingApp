using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTransferTest
{
    public interface ICalculationService
    {
        decimal Result { get; set; }
        string ResultText();
        void CalculateArea();
    }

    public interface ICalculateVolumetricFigures : ICalculationService
    {
        decimal? VolumeResult { get; set; }
        void CalculateVolume();
    }

    public class Triangle : ICalculationService
    {
        public Triangle(int length, int height)
        {
            Length = length;
            Height = height;
        }

        public int Length { get; }
        public int Height { get; }
        public decimal Result { get; set; }

        public void CalculateArea()
        {
            Result = Height * Length * 0.5m;
        }

        public string ResultText()
        {
            return $"Area of triangle is: {Result}";
           
        }
    }

  
    public class Square : ICalculationService
    {
        public Square(int sideLength)
        {
            SideLength = sideLength;
        }

        public int SideLength { get; }
        public decimal Result { get; set; }

        public void CalculateArea()
        {
            Result = SideLength * SideLength;
        }

        public string ResultText()
        {
            return $"Area of square is: {Result}";
        }

        
    }

    public class Circle : ICalculationService
    {
        public Circle(int circleRadius)
        {
            CircleRadius = circleRadius;
        }

        public int CircleRadius { get; }
        public decimal Result { get; set; }

        public void CalculateArea()
        {
            Result =  Convert.ToDecimal(Math.Pow((double)CircleRadius, 2) * Math.PI);
        }

        public string ResultText()
        {
            return $"Area of circle is: {Result}";
        }
    }

    public class Hexagon : ICalculateVolumetricFigures
    {
        public Hexagon(int hexaSide)
        {
            HexaSide = hexaSide;
        }

        public int HexaSide { get; }

        public decimal Result { get; set; }
        public decimal? VolumeResult { get; set; }

        public void CalculateArea()
        {
            Result = Convert.ToDecimal(Math.Pow((double)HexaSide, 2)*6);
        }

        public void CalculateVolume()
        {
            VolumeResult = Convert.ToDecimal(Math.Pow((double)HexaSide, 3));
        }

        public string ResultText() => VolumeResult != null ? $"Area is {Result} and Volume is {VolumeResult.Value}" : $"Area is {Result}";
    }
}
