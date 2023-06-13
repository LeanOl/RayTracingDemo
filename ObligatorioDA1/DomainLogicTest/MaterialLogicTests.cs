using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Logic;
using System.Collections.Generic;
using Repository;
using Repository.DBRepository;
using System.Data.Entity;

namespace LogicTest
{
    [TestClass]
    public class MaterialLogicTests
    {
        private Client _someClient;
        private MaterialLogic _logic;
        private RayTracingContext _context;
        private Color _color;
        private const string ValidName = "Figure";
        private const string EmptyNameMessage = "Figure name should not be empty";
        private const string StartsOrEndsWithWhitespaceMessage = "Figure name should not start or end with whitespaces";
        private const string DuplicateNameMessage = "There is already a figure with this name";

        [TestInitialize]
        public void Initialize()
        {

            DateTime testDate = DateTime.Now;
            const string username = "John";
            const string password = "Abc12345";
            _color = Color.FromArgb(205, 215, 235);
            _someClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = testDate
            };

            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _context = new RayTracingContext();
            _context.Database.Initialize(true);
            IMaterialRepository repository = new MaterialDbRepository(_context);
            IModelRepository modelRepository= new ModelDbRepository(_context);
            ModelLogic modelLogic = new ModelLogic(modelRepository);
            _logic = new MaterialLogic(repository,modelLogic);
            _context.Clients.Add(_someClient); 
            _context.SaveChanges();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void CreatedLambertianSuccessfully()
        {
            Material testMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = ValidName,
                Color = _color
            };
            _logic.CreateLambertian(_someClient, ValidName, _color);
            Assert.AreEqual(testMaterial,_logic.GetMaterialByName(ValidName));
            
        }
        
        [TestMethod]
        public void CreateLambertianDuplicatedName_ThrowException()
        {
            _logic.CreateLambertian(_someClient, ValidName, _color);
            try
            {
                _logic.CreateLambertian(_someClient, ValidName, _color);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(DuplicateNameMessage, ex.Message);

            }
        }
        [TestMethod]
        public void GetClientMaterialsSuccessfully()
        {
            List<Material> clientMaterials = new List<Material>();
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "Material1",
                Color = _color

            };
            clientMaterials.Add(someMaterial);
            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "Material2",
                Color = _color

            };
            clientMaterials.Add(someMaterial2);
            _logic.CreateLambertian(_someClient, "Material1", _color);
            _logic.CreateLambertian(_someClient, "Material2", _color);
            
            CollectionAssert.AreEquivalent(clientMaterials,_logic.GetClientMaterials(_someClient));

        }
        [TestMethod]
        public void DeleteMaterialSuccessfully()
        {

            Color materialColor = Color.FromArgb(205, 215, 235);
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "Material1",
                Color = materialColor

            };
            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "Material2",
                Color = materialColor
            };
            _context.Materials.Add(someMaterial);
            _context.Materials.Add(someMaterial2);
            _context.SaveChanges();
            _logic.DeleteMaterial(someMaterial);
            CollectionAssert.DoesNotContain(_logic.GetClientMaterials(_someClient), someMaterial);
        }

        [TestMethod]
        public void CreateMetallicSuccessfully()
        {
            Metallic testMaterial = new Metallic()
            {
                Proprietary = _someClient,
                Name = ValidName,
                Color = _color,
                Roughness = 0.5m
            };
            _logic.CreateMetallic(testMaterial);
            Assert.AreEqual(testMaterial, _logic.GetMaterialByName(ValidName));
        }

        [TestMethod]
        public void DeleteMaterialUsedByModel_ThrowException()
        {
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "Material1",
                Color = _color
            };
            _context.Materials.Add(someMaterial);

            Figure someFigure = new Sphere()
            {
                Name = "Sphere1",
                Proprietary = _someClient,
                Radius = 1
            };
            _context.Figures.Add(someFigure);

            Model someModel = new Model()
            {
                Proprietary = _someClient,
                Name = "Model1",
                Material = someMaterial,
                Figure = someFigure
            };
            _context.Models.Add(someModel);

            _context.SaveChanges();

            try
            {
                _logic.DeleteMaterial(someMaterial);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("This material is used by a model", ex.Message);
            }

        }
        

        

    }
}