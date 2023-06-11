using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DBRepository;
using Repository;
using System;
using System.Data.Entity;
using System.Drawing;
using Domain;

namespace RepositoryTests.DBRepositoryTests
{
    [TestClass]
    public class MaterialDBRepositoryTests
    {
        private IMaterialRepository _materialDBRepository;
        private Client _someClient;
        private static RayTracingContext _testContext;

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _testContext = new RayTracingContext();
            _testContext.Database.Initialize(true);
            _materialDBRepository = new MaterialDBRepository(_testContext);
            DateTime testDate = DateTime.Now;
            const string username = "John";
            const string password = "Abc12345";

            _someClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = testDate
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testContext.Dispose();
        }
        [TestMethod]
        public void AddMaterialSuccessfully()
        {
            Color materialColor = Color.FromArgb(205, 215, 235);
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material",
                Color = materialColor
            };
            _materialDBRepository.Add(someMaterial);
            Assert.AreEqual(someMaterial, _materialDBRepository.GetByName("New Material"));
        }

    }
}
