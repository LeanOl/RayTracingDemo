using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DBRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain;
using Domain.GraphicsEngine;

namespace RepositoryTests.DBRepositoryTests
{
    [TestClass]
    public class ModelDbRepositoryTests
    {
        private static RayTracingContext _testContext;
        private ModelDbRepository _modelDbRepository;
        private Client _someClient;
        private Figure _someFigure;
        private Material _someMaterial;

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _testContext = new RayTracingContext();
            _testContext.Database.Initialize(true);
            _modelDbRepository = new ModelDbRepository(_testContext);
            _someClient = new Client
            {
                Username = "John",
                Password = "John123",
                RegisterDate = DateTime.Now
            };
            _someFigure = new Sphere
            {
                Name = "Sphere",
                Radius = 1,
                Proprietary = _someClient
            };
            _someMaterial = new Lambertian
            {
                Name = "Lambertian",
                Color = System.Drawing.Color.FromArgb(255, 255, 255),
                Proprietary = _someClient
            };
            _testContext.Clients.Add(_someClient);
            _testContext.Figures.Add(_someFigure);
            _testContext.Materials.Add(_someMaterial);
            _testContext.SaveChanges();


        }

        [TestMethod]
        public void AddModelOk()
        {
            Model model = new Model
            {
                Name = "Model",
                Proprietary = _someClient,
                Figure = _someFigure,
                Material = _someMaterial
            };
            _modelDbRepository.AddModel(model);
            Assert.AreEqual(model, _modelDbRepository.GetModelByName("Model"));
        }

        [TestMethod]
        public void GetClientModelsOk()
        {
            Model model = new Model
            {
                Name = "Model",
                Proprietary = _someClient,
                Figure = _someFigure,
                Material = _someMaterial
            };
            List<Model> models = new List<Model>
            {
                model
            };
            _modelDbRepository.AddModel(model);
            CollectionAssert.AreEquivalent(models, _modelDbRepository.GetClientModels(_someClient));
        }

        [TestMethod]
        public void DeleteMaterialOk()
        {
            Model model = new Model
            {
                Name = "Model",
                Proprietary = _someClient,
                Figure = _someFigure,
                Material = _someMaterial
            };

            _modelDbRepository.AddModel(model);

            _modelDbRepository.DeleteModel(model);
            Assert.IsNull(_modelDbRepository.GetModelByName("Model"));
        }
        
    }
}
