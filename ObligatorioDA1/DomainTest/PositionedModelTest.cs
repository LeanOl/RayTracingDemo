using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class PositionedModelTest
    {
        [TestMethod]
        public void CreatePositionedModelSuccessfully()
        {
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = new Model(),
                Position = new Vector()
            };
            Assert.IsNotNull(positionedModel);
        }
    }
}
