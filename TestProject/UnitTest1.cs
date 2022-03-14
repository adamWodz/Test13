using CalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        // 0
        [DataRow("", 0)]
        [DataTestMethod]
        public void TestEmpty(string empty, int expected)
        {
            Assert.AreEqual(Calculator.Add(empty), expected);
        }

        // 1
        [DataRow("5", 5)]
        [DataRow("6", 6)]
        [DataRow("8", 8)]
        [DataTestMethod]
        public void TestSingle(string num, int expected)
        {
            Assert.AreEqual(Calculator.Add(num), expected);
        }

        // 2
        [DataRow("4,2", 6)]
        [DataRow("3,8", 11)]
        [DataTestMethod]
        public void TestTwoDevidedWithComma(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 3
        [DataRow("5\n2\n2", 9)]
        [DataRow("4\n2", 6)]
        [DataTestMethod]
        public void TestTwoDevidedWithNewline(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 3.2
        [DataRow("4\n2,2", 8)]
        [DataRow("4,2\n2", 8)]
        [DataRow("3\n1\n1", 5)]
        [DataRow("1,1,5", 7)]
        [DataTestMethod]
        public void TestDividedWithCommaAndNewline(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 4
        [DataRow("//;\n1;2", 3)]
        [DataRow("//\n\n1\n2\n3", 6)]
        [DataTestMethod]
        public void CustomSeparatorTest(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 5
        [DataRow("4\n2,-2")]
        [DataRow("-76\n3\n-2")]
        [DataTestMethod]
        public void NegativeNumber(string nums)
        {
            Assert.ThrowsException<Exception>(() => { Calculator.Add(nums); });
        }

        // 6
        [DataRow("2\n1001", 2)]
        [DataRow("//,\n2,1001", 2)]
        [DataRow("1001,1002", 0)]
        [DataRow("1000,1000\n3", 2003)]
        [DataTestMethod]
        public void NumberBiggerThan1000Ignored(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 7
        [DataRow("//[***]\n1***2***3", 6)]
        [DataRow("//[\n\n\n]\n1\n\n\n2\n\n\n4\n\n\n1001", 7)]
        [DataTestMethod]
        public void CustomSeparatorLengthTest(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 8
        [DataRow("//[*][%]\n1*2%3", 6)]
        [DataRow("//[*][\n]\n1*2\n3", 6)]
        [DataRow("//[[][\n]\n1[2\n3", 6)]
        [DataTestMethod]
        public void ManyCustomSeparatorsTest(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }

        // 9
        [DataRow("//[***][%%]\n1***2%%3", 6)]
        [DataRow("//[\n*[][%%]\n1\n*[2%%3", 6)]
        [DataTestMethod]
        public void ManyCustomLengthSeparatorsTest(string nums, int expected)
        {
            Assert.AreEqual(Calculator.Add(nums), expected);
        }
    }
}
