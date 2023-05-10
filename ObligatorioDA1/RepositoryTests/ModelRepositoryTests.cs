using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Domain;
using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class ModelRepositoryTests
    {
        private ModelRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new ModelRepository();
        }
        [TestMethod]
        public void AddModelToRepositoryOk()
        {
            Model testModel = new Model{Name = "Model"};
            _repository.AddModel(testModel);
            Assert.AreEqual(testModel,_repository.GetModelByName("Model"));

        }

        [TestMethod]
        public void GetClientModelsOk()
        {
            Client testClient = new Client { Username = "John"};
            Model testModel = new Model { Name = "Model" ,Proprietary = testClient };
            List<Model> clientModels = new List<Model>
            {
                testModel
            };
            _repository.AddModel(testModel);
            CollectionAssert.AreEqual(clientModels,_repository.GetClientModels(testClient));
            
            
        }
        
    }
}
