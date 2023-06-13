using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Domain;
using Logic;
using Repository;
using Repository.DBRepository;
using System.Data.Entity;
using System.Linq;

namespace DomainLogicTest
{
    [TestClass]
    public class ModelLogicTests
    {
        private ModelLogic _modelLogic;
        private SceneLogic _sceneLogic;
        private Client _proprietary;
        private Figure _figure;
        private Material _material;
        private RayTracingContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _proprietary = new Client
            {
                Username = "John" ,
                RegisterDate = DateTime.Now
                
            };
            _figure = new Sphere{ Name = "Figure1"};
            _material = new Lambertian { Name = "Material1"};

            
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _context = new RayTracingContext();
            _context.Database.Initialize(true);
            IModelRepository repository = new ModelDbRepository(_context);
            SceneDbRepository sceneDbRepository = new SceneDbRepository(_context);
            _sceneLogic = new SceneLogic(sceneDbRepository);
            _modelLogic = new ModelLogic(repository,_sceneLogic);
            _context.Clients.Add(_proprietary);
            _context.Figures.Add(_figure);
            _context.Materials.Add(_material);
            _context.SaveChanges();

        }
        [TestCleanup]
        public void TestCleanup()
        {
           _context.Dispose();
        }
        [TestMethod]
        public void CreateModelOk()
        {
            _modelLogic.CreateModel("Model1", _proprietary,_figure,_material);
            Assert.IsNotNull(_modelLogic.GetModelByName("Model1"));
        }

        [TestMethod]
        public void ModelNameStartsWhitespace_ThrowException()
        {
            try
            {
                _modelLogic.CreateModel(" Model1", _proprietary, _figure, _material);
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Model name should not start or end with whitespaces", e.Message);
            }
        }

        [TestMethod]
        public void DuplicatedModelName_ThrowException()
        {
            _modelLogic.CreateModel("Model1", _proprietary, _figure, _material);
            try
            {
                _modelLogic.CreateModel("Model1", _proprietary, _figure, _material);
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("There is already a model with this name", e.Message);
            }
        
        }

        [TestMethod]
        public void CreateModelWithPreviewOk()
        {
            _modelLogic.CreateModelWithPreview("Model1", _proprietary, _figure, _material);
            Assert.IsNotNull(_modelLogic.GetModelByName("Model1").Preview);
        }

        [TestMethod]
        public void GetClientModels()
        {
            _modelLogic.CreateModel("Model1", _proprietary, _figure, _material);
            _modelLogic.CreateModel("Model2", _proprietary, _figure, _material);
            Assert.AreEqual(2, _modelLogic.GetClientModels(_proprietary).Count);
        }

        [TestMethod]
        public void DeleteModel()
        {
            Model testModel = new Model()
            {
                Proprietary = _proprietary,
                Name = "Model1",
                Figure = _figure,
                Material = _material
            };
            _context.Models.Add(testModel);
            _context.SaveChanges();
            _modelLogic.DeleteModel(testModel);
            Assert.IsNull(_context.Models.FirstOrDefault(model => model.Name == "Model1"));
        }

        [TestMethod]
        public void DeleteModelUsedByScene_ThrowException()
        {
            Model testModel = new Model()
            {
                Proprietary = _proprietary,
                Name= "Model1",
                Figure = _figure,
                Material = _material
            };

            Scene testscene = new Scene
            {
                Proprietary = _proprietary,
                ModelList = new List<PositionedModel>()
                {
                    new PositionedModel
                    {
                        Model = testModel,
                        Position= new Vector
                        {
                            X=0,
                            Y=0,
                            Z=0
                        }
                    }
                },
                Name = "Scene1",
                CreationDate = DateTime.Now,
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now
            };
            _context.Models.Add(testModel);
            _context.Scenes.Add(testscene);
            _context.SaveChanges();
            try
            {
                _modelLogic.DeleteModel(testModel);
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual("This model is used by a scene", e.Message);
            }
        }
    }
}
