using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;

namespace RepositoryTests
{
    [TestClass]
    public class SceneRepositoryTests
    {

        private Client _someClient;
        private SceneRepository _repository;
        [TestMethod]
        public void AddSeneSuccessfully()
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
    }
}



