using System;
using System.Collections.Generic;
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
    }
}
