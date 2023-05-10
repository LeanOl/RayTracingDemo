using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;
using System.Collections.Generic;
using System.Dynamic;

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
                Name = "Empty Scene",
                Proprietary = _proprietary
            };
            Scene testScene2 = new Scene
            {
                Name = "Empty Scene 1",
                Proprietary = _proprietary
            };
            Scene testScene3 = new Scene
            {
                Name = "Empty Scene 2",
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

        [TestMethod]
        public void AddModelToSceneSuccessfully()
        {
            _logic.CreateEmptyScene(_proprietary);
            Scene testScene =  _logic.GetSceneByName("Empty Scene");
            Model testModel = new Model
            {
                Name = "New Model",
                Proprietary = _proprietary,
            };
            Vector position = new Vector{X=0,Y=0,Z=0};
            _logic.AddModelToScene(testScene, testModel,position);

           
        }

        [TestMethod]
        public void DeleteModelFromScene()
        {
            _logic.CreateEmptyScene(_proprietary);
            Scene testScene = _logic.GetSceneByName("Empty Scene");
            Model testModel = new Model
            {
                Name = "New Model",
                Proprietary = _proprietary,
            };
            Vector position = new Vector { X = 0, Y = 0, Z = 0 };
            PositionedModel testPositionedModel = new PositionedModel
            {
                Model = testModel,
                Position = position
            };
            _logic.AddModelToScene(testScene, testModel, position);
            _logic.DeleteModelFromScene(testScene, testPositionedModel);
            Assert.IsTrue(testScene.ModelList.Count == 0);
        }

        [TestMethod]
        public void ChangeCameraSettings()
        {
            _logic.CreateEmptyScene(_proprietary);
            Scene testScene = _logic.GetSceneByName("Empty Scene");
            Vector lookFrom = new Vector { X = 2, Y = 2, Z = 2 };
            Vector lookAt = new Vector { X = 3, Y = 3, Z = 3 };
            _logic.ChangeCameraSettings(testScene, lookFrom, lookAt, 25);
            Assert.IsTrue(testScene.Camera.LookFrom == lookFrom);
            Assert.IsTrue(testScene.Camera.LookAt == lookAt);
            Assert.IsTrue(testScene.Camera.FieldOfView == 25);
        }
        
    }
}
