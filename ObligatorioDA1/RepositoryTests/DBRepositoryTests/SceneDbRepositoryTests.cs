using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Domain;
using Repository;
using Repository.DBRepository;
using System.Data.Entity;

namespace RepositoryTests.DBRepositoryTests
{
    [TestClass]
    public class SceneDbRepositoryTests
    {
        private Client _someClient;
        private Figure _someFigure;
        private Material _someMaterial;
        private Model _someModel;
        private PositionedModel _somePositionedModel;
        private SceneDbRepository _repository;
        private static RayTracingContext _testContext;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _testContext = new RayTracingContext();
            _testContext.Database.Initialize(true);
            _repository = new SceneDbRepository(_testContext);
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
            _someModel= new Model
            {
                Name = "Model",
                Proprietary = _someClient,
                Figure = _someFigure,
                Material = _someMaterial
            };
            _somePositionedModel = new PositionedModel
            {
                Model = _someModel,
                Position = new Vector
                {
                    X=0,
                    Y=0,
                    Z=0
                },
            };
            _testContext.Clients.Add(_someClient);
            _testContext.Figures.Add(_someFigure);
            _testContext.Materials.Add(_someMaterial);
            _testContext.Models.Add(_someModel);
            _testContext.SaveChanges();
        }

        [TestMethod]
        public void CreateSceneSuccessfully()
        {
            Scene scene = new Scene
            {
                Name = "Scene",
                Proprietary = _someClient,
                ModelList = new List<PositionedModel>
                {
                    _somePositionedModel
                },
                CreationDate = DateTime.Now,
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                CameraLookFrom = new Vector
                {
                    X=0,
                    Y=0,
                    Z=0
                },
                CameraLookAt = new Vector
                {
                    X=0,
                    Y=0,
                    Z=0
                }

            };
            _repository.Add(scene);
            Scene sceneFromDb = _repository.GetByName("Scene");
            Assert.AreEqual(scene, sceneFromDb);
        }

        [TestMethod]
        public void GetScenesByClientSuccessfully()
        {
            Scene scene = new Scene
            {
                Name = "Scene",
                Proprietary = _someClient,
                ModelList = new List<PositionedModel>
                {
                    _somePositionedModel
                },
                CreationDate = DateTime.Now,
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                CameraLookFrom = new Vector
                {
                    X = 0,
                    Y = 0,
                    Z = 0
                },
                CameraLookAt = new Vector
                {
                    X = 0,
                    Y = 0,
                    Z = 0
                }
            };
            List<Scene> scenes = new List<Scene>
            {
                scene
            };
            _repository.Add(scene);
            List<Scene> scenesFromDb = _repository.GetScenesByClient(_someClient);
            CollectionAssert.AreEquivalent( scenes, scenesFromDb);
        }
    }
}
