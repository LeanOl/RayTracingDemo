using Domain.GraphicsEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System.Collections.Generic;
using Domain;

namespace RepositoryTests
{
    [TestClass]
    public class SceneRepositoryTests
    {

        private Client _someClient;
        private SceneRepository _repository;
        [TestMethod]
        public void AddSceneSuccessfully()
        {
            _repository= new SceneRepository();
            const string username = "John";
            _someClient = new Client()
            {
                Username = username,
            };
            Scene testScene = new Scene
            {
                Name= "New Scene"
            };
            _repository.Add(testScene);
            Assert.AreEqual(testScene, _repository.GetByName("New Scene"));

        }
        [TestMethod]
        public void GetClientScenes()
        {
            _repository = new SceneRepository();
            const string username = "John";
            const string username2 = "Alan";
            _someClient = new Client()
            {
                Username = username,
            };
            Client someClient2 = new Client()
            {
                Username = username2,
            };
            Scene testScene = new Scene
            {
                Name = "New Scene",
                Proprietary=_someClient
            };
            Scene testScene2 = new Scene
            {
                Name = "New Scene 1",
                Proprietary = _someClient
            };
            Scene testScene3 = new Scene
            {
                Name = "New Scene 2",
                Proprietary = someClient2
            };
            _repository.Add(testScene);
            _repository.Add(testScene2);
            _repository.Add(testScene3);
            List<Scene> client1Scenes = new List<Scene>
            {
                testScene,
                testScene2,
            };

            CollectionAssert.AreEquivalent(client1Scenes,
                _repository.GetScenesByClient(_someClient));

        }

        [TestMethod]
        public void DeleteSceneSuccessfully()
        {
            _repository = new SceneRepository();
            const string username = "John";
            _someClient = new Client()
            {
                Username = username,
            };
            Scene testScene = new Scene
            {
                Name = "New Scene",
                Proprietary = _someClient
            };
            _repository.Add(testScene);
            _repository.Delete(testScene);
            Assert.IsNull(_repository.GetByName("New Scene"));
        }
    }
}



