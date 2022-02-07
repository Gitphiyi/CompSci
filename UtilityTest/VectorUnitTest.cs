using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace UtilityTest
{
    [TestClass]
    public class VectorUnitTest
    {
        Vector vec1 = new Vector(3, -5, 0);
        Vector vec2 = new Vector(1, -5, 0);
        Vector vec3 = new Vector(0, 0, 0);
        [TestMethod]
        public void AdditionTest()
        {
            var vec1 = new Vector(1, -4, 6.7);
            var vec2 = new Vector(0, 9, 14);
            var answer = vec1 + vec2;
            var realAnswer = new Vector(1, 5, 20.7);
            Assert.AreEqual(realAnswer, answer);

            var subtractionAnswer = vec1 - vec2;
            var realSubtractionAnswer = new Vector(1, -13, -7.3);
            Assert.AreEqual(realSubtractionAnswer, subtractionAnswer);
        }
        [TestMethod]
        public void MultiplicationTest()
        {
            var vec1 = new Vector(3, 0, 1);
            double scalar = 2.5;
            var answer = vec1 * scalar;
            var realAnswer = new Vector(7.5, 0, 2.5);
            Assert.AreEqual(realAnswer, answer);
        }
        [TestMethod]
        public void DivisionTest()
        {
            Vector vector = new(1, -5, 1);
            Assert.ThrowsException<ArgumentException>(() => vec2 / 0);

            Vector answer = vector / 5;
            Vector realAnswer = new Vector((double)1/5, -1,(double) 1/5);
            Console.WriteLine(realAnswer.Y);
            Assert.AreEqual(answer, realAnswer);
        }
        [TestMethod]
        public void DotProductTest()
        {
            double answer = Vector.DotProduct(vec1, vec2);
            double realAnswer = 28;
            Assert.AreEqual(answer, realAnswer);
        }
        [TestMethod]
        public void EqualsTest()
        {
            Vector vec1 = new Vector(1, -1, 1);
            Vector vec2 = new Vector(1, -1, 1);
            Assert.AreEqual(vec1 == vec2, true);
            vec1 = new Vector(0, -2, 1 / 3);
            vec2 = new Vector(0, -2, 1 / 3);
            Assert.AreEqual(vec1 == vec2, true);
        }
        [TestMethod]
        public void InequalsTest()
        {
            bool answer = vec1 != vec2;
            bool realAnswer = true;
            Assert.AreEqual(answer, realAnswer);
        }
        [TestMethod]
        public void MagnitudeTest()
        {
            double answer = vec1.Magnitude;
            double realAnswer = Math.Sqrt(34);
            Assert.AreEqual(answer, realAnswer);
            answer = vec3.Magnitude;
            realAnswer = 0;
            Assert.AreEqual(answer, realAnswer);
        }
        [TestMethod]
        public void NormalTest()
        {
            Vector vec1 = new (3, 4, 0);
            Vector answer = Vector.NormalizeVector(vec1);
            Vector realAnswer = vec1 / vec1.Magnitude;
            Assert.AreEqual(answer,realAnswer);
        }
        [TestMethod]
        public void ToStringTest()
        {
            String answer = vec1.ToString();
            String realAnswer = "<3,-5,0>";
            Assert.AreEqual(answer, realAnswer);
        }
    }
}