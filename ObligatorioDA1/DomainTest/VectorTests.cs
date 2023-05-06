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
    }
}
