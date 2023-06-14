using Domain;
using Domain.GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
