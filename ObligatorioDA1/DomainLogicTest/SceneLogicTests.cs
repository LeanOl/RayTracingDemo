using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;
using System.Collections.Generic;

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

        [TestMethod]
        public void CreateThreeEmptyScenesSuccessfully()
        {
            _logic.CreateEmptyScene(_proprietary);
            _logic.CreateEmptyScene(_proprietary);
            _logic.CreateEmptyScene(_proprietary);
            Assert.IsNotNull(_logic.GetSceneByName("Empty Scene"));
            Assert.IsNotNull(_logic.GetSceneByName("Empty Scene 1"));
            Assert.IsNotNull(_logic.GetSceneByName("Empty Scene 2"));
        }
        [TestMethod]
        public void GetClientScenes()
        {
            _logic.CreateEmptyScene(_proprietary);
            _logic.CreateEmptyScene(_proprietary);
            _logic.CreateEmptyScene(_proprietary);
            Scene testScene = new Scene
            {
                Name = "New Scene",
                Proprietary = _proprietary
            };
            Scene testScene2 = new Scene
            {
                Name = "New Scene 1",
                Proprietary = _proprietary
            };
            Scene testScene3 = new Scene
            {
                Name = "New Scene 2",
                Proprietary = _proprietary
            };
            List<Scene> clientScenes = new List<Scene>
            {
                testScene,
                testScene2,
                testScene3
            };
            CollectionAssert.AreEquivalent(clientScenes, _logic.GetClientScenes(_proprietary));
        }
    }
}
