using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;
using Repository;
using Repository.DBRepository;
using System.Data.Entity;

namespace DomainLogicTest
{
    [TestClass]
    public class ModelLogicTests
    {
        private ModelLogic _modelLogic;
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
            _modelLogic = new ModelLogic(repository);
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
            _modelLogic.CreateModel("Model1", _proprietary, _figure, _material);
            _modelLogic.DeleteModel(_modelLogic.GetModelByName("Model1"));
            Assert.IsNull(_modelLogic.GetModelByName("Model1"));
        }
    }
}
