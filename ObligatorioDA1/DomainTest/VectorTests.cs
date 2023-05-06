using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void CreateVectorSuccessfully()
        {
            Vector vector = new Vector()
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Assert.IsNotNull(vector);
        }

        [TestMethod]
        public void AddTwoVectorsSuccessfully()
        {
            Vector vector1 = new Vector()
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector()
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector3 = vector1.Add(vector2);
            Assert.AreEqual(2, vector3.X);
            Assert.AreEqual(4, vector3.Y);
            Assert.AreEqual(6, vector3.Z);
        }

        [TestMethod]
        public void SubstractTwoVectorsSuccessfully()
        {
                        Vector vector1 = new Vector()
                        {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector()
            {
                X = 2,
                Y = 2,
                Z = 2
            };
            Vector vector3 = vector1.Subtract(vector2);
            Assert.AreEqual(-1, vector3.X);
            Assert.AreEqual(0, vector3.Y);
            Assert.AreEqual(1, vector3.Z);
        }
    }
}

