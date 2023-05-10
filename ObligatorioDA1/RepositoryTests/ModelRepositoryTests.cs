using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    }
}
