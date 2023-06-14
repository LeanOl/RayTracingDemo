using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.GraphicsEngine;

namespace DomainTest
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void CreateVectorSuccessfully()
        {
            Vector vector = new Vector
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
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector
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
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector
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

        [TestMethod]
        public void MultiplyVectorNumber()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = vector1.Multiply(2);
            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(6, vector2.Z);
        }

        [TestMethod]
        public void DivideVectorNumber()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            
            Vector vector2 = vector1.Divide(2);
            Assert.AreEqual(0.5m, vector2.X);
            Assert.AreEqual(1m, vector2.Y);
            Assert.AreEqual(1.5m, vector2.Z);
        }

        [TestMethod]
        public void AddToVector()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            vector1.AddTo(vector2);
            Assert.AreEqual(2, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(6, vector1.Z);
        
        }

        [TestMethod]
        public void GetSquaredLength()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            decimal squaredLength = vector1.SquaredLength();
            Assert.AreEqual(14m, squaredLength);
        }

        [TestMethod]
        public void GetLength()
        {
            Vector vector1 = new Vector
            {
                X = 2,
                Y = 2,
                Z = 1
            };
            decimal length = vector1.Length();
            Assert.AreEqual(3m, length);
        }

        [TestMethod]
        public void GetUnit()
        {
            Vector vector1 = new Vector
            {
                X = 3,
                Y = 4,
                Z = 5
            };
            Vector unitVector = vector1.Unit();
            Assert.AreEqual(0.424264m, Math.Round(unitVector.X, 6));
            Assert.AreEqual(0.565685m, Math.Round(unitVector.Y, 6));
            Assert.AreEqual(0.707107m, Math.Round(unitVector.Z, 6));
            
        }

        [TestMethod]
        public void GetDotProduct()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            decimal dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(14m, dotProduct);
        }

        [TestMethod]
        public void GetCrossProduct()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            Vector vector2 = new Vector
            {
                X = 1,
                Y = 3,
                Z = 3
            };
            Vector crossProduct = vector1.CrossProduct(vector2);
            Assert.AreEqual(-3m, crossProduct.X);
            Assert.AreEqual(0m, crossProduct.Y);
            Assert.AreEqual(1m, crossProduct.Z);
        }

        [TestMethod]
        public void VectorToString()
        {
            Vector vector1 = new Vector
            {
                X = 1,
                Y = 2,
                Z = 3
            };
            string vectorString = vector1.ToString();
            Assert.AreEqual("(1, 2, 3)", vectorString);
        }
        
    }
}

