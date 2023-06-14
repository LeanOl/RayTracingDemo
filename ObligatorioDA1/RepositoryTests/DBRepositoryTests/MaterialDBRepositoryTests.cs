using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DBRepository;
using Repository;
using System;
using System.Data.Entity;
using System.Drawing;
using Domain.GraphicsEngine;
using System.Collections.Generic;
using Domain;

namespace RepositoryTests.DBRepositoryTests
{
    [TestClass]
    public class MaterialDbRepositoryTests
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
            _materialDBRepository = new MaterialDbRepository(_testContext);
            DateTime testDate = DateTime.Now;
            const string username = "John";
            const string password = "Abc12345";

            _someClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = testDate
            };
            _testContext.Clients.Add(_someClient);
            _testContext.SaveChanges();
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

        [TestMethod]
        public void GetMaterialsByClientSuccessfully()
        {
            List<Material> clientMaterials = new List<Material>();
            Color materialColor = Color.FromArgb(205, 215, 235);
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material",
                Color = materialColor

            };
            _materialDBRepository.Add(someMaterial);
            clientMaterials.Add(someMaterial);
            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material2",
                Color = materialColor

            };
            _materialDBRepository.Add(someMaterial2);
            clientMaterials.Add(someMaterial2);

            CollectionAssert.AreEquivalent(clientMaterials, _materialDBRepository.GetMaterialsByClient(_someClient));
        }

        [TestMethod]
        public void DeleteMaterialSuccessfully()
        {
            Color materialColor = Color.FromArgb(205, 215, 235);
            Material someMaterial = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material",
                Color = materialColor

            };
            _materialDBRepository.Add(someMaterial);

            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material2",
                Color = materialColor

            };
            _materialDBRepository.Add(someMaterial2);


            _materialDBRepository.Delete(someMaterial);
            CollectionAssert.DoesNotContain(_materialDBRepository.GetMaterialsByClient(_someClient), someMaterial);
        }

    }
}
