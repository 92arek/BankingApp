using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BankTransferTest
{
    public class ReferenceTypeClass
    {
        public string Name { get; set; }
    }

    public sealed class ValueTypesInClass
    {
        public int X_Value { get; set; }
        public int Y_Value { get; set; }
    }

    public enum StuctureType
    {
        TwojaStara,
        TwojStary
    }
    
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void Test_Where_You_Expect_That_Value_Object_Will_Not_Affect_Each_Other()
        {
            var myValueTypeClass = new ValueTypesInClass();
            myValueTypeClass.X_Value = 1;
            myValueTypeClass.Y_Value = myValueTypeClass.X_Value;

            Assert.AreEqual(myValueTypeClass.X_Value, myValueTypeClass.Y_Value);

            myValueTypeClass.X_Value = 2;
            
            Assert.AreNotEqual(myValueTypeClass.X_Value, myValueTypeClass.Y_Value);
        }

        [TestMethod]
        public void Test_Where_You_Expect_That_Reference_Objects_Will_Affect_Each_Other()
        {
            var myReferenceTypeClass = new ReferenceTypeClass();
            myReferenceTypeClass.Name = "pies";

            var myReferenceTypeClassCopy = myReferenceTypeClass;
            myReferenceTypeClassCopy.Name = "wilk";

            Assert.AreEqual(myReferenceTypeClass.Name, myReferenceTypeClassCopy.Name);

            var myValueTypeClass = new ValueTypesInClass();
            myValueTypeClass.X_Value = 1;
            myValueTypeClass.Y_Value = myValueTypeClass.X_Value;

            var copy = myValueTypeClass;

            copy.X_Value = 3;

            Assert.AreEqual(myValueTypeClass.X_Value, copy.X_Value);
            Assert.AreNotEqual(myValueTypeClass.X_Value, copy.Y_Value);

            var isItTrue = myValueTypeClass.Equals(copy);

            Assert.IsTrue(isItTrue);
        }

        [TestMethod]
        public void Calculate_Figures()
        {
            var listOfFigures = new List<ICalculationService>();

            listOfFigures.Add(new Triangle(5,3));
            listOfFigures.Add(new Square(5));
            listOfFigures.Add(new Circle(10));
            listOfFigures.Add(new Hexagon(10));

            StringBuilder stringBuilder = new StringBuilder();
            
            listOfFigures.ForEach(f => Calc(stringBuilder, f));

            foreach (var f in listOfFigures)
            {
                Calc(stringBuilder, f);
            }

            var resultString = stringBuilder.ToString();

            var listOfValueFigures = new List<ICalculateVolumetricFigures>();
            listOfValueFigures.Add(new Hexagon(5));

            listOfValueFigures.ForEach(f => CalcVolume(stringBuilder, f));

            var resultString2 = resultString.ToString();
        }

        private void Calc(StringBuilder sb, ICalculationService figure)
        {
            figure.CalculateArea();
            sb.Append($"{figure.ResultText()}, ");
        }

        private void CalcVolume(StringBuilder sb, ICalculateVolumetricFigures figure)
        {
            figure.CalculateVolume();
            sb.AppendLine();
            sb.AppendLine();
            Calc(sb, figure);
        }
    }
}
