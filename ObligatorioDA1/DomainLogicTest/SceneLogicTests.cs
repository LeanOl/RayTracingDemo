using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;

namespace DomainLogicTest
{
    [TestClass]
    public class SceneLogicTests
    {
        SceneLogic _logic = new SceneLogic();
        private Client _proprietary = new Client { Username = "John" };
        [TestMethod]
        public void CreateEmptySceneSuccessfully()
        {
            _logic.CreateEmptyScene(_proprietary);
            Assert.IsNotNull(_logic.GetSceneByName("Empty Scene"));
        }
    }
}
