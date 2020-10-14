using GraduateDotNet2020.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1Is1()
        {
            Assert.AreEqual("1", GetValueAtPos(1));
        }
        [TestMethod]
        public void Test2Is2()
        {
            Assert.AreEqual("2", GetValueAtPos(2));
        }
        [TestMethod]
        public void Test3IsFizz()
        {
            Assert.AreEqual("Fizz", GetValueAtPos(3));
        }
        [TestMethod]
        public void Test4Is4()
        {
            Assert.AreEqual("4", GetValueAtPos(4));
        }
        [TestMethod]
        public void Test5IsBuzz()
        {
            Assert.AreEqual("Buzz", GetValueAtPos(5));
        }
        [TestMethod]
        public void Test15IsFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", GetValueAtPos(15));
        }
        [TestMethod]
        public void TestLongSequence()
        {
            var fizzBuzz = new FizzBuzz();
            var isEqual = fizzBuzz.Generate().Take(20).SequenceEqual(new[] {"1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz"});
            Assert.IsTrue(isEqual);
        }


        private static string GetValueAtPos(int pos)
        {
            var fizzBuzz = new FizzBuzz();
            var value = fizzBuzz.Generate().Skip(pos - 1).First();
            return value;
        }
    }
}
