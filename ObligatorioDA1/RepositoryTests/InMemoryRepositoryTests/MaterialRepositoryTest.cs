using System;
using System.Collections.Generic;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.InMemoryRepository;

namespace RepositoryTests.InMemoryRepositoryTests
{
    [TestClass]
    public class MaterialRepositoryTest
    {
        private Client _someClient;
        private MaterialRepository _repository;

        [TestInitialize]
        public void Initialize()
        {

            DateTime testDate = DateTime.Now;
            const string username = "John";
            const string password = "Abc12345";

            _someClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = testDate
            };
            _repository = new MaterialRepository();
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
            _repository.Add(someMaterial);
            Assert.AreEqual(someMaterial,_repository.GetByName("New Material"));

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
            _repository.Add(someMaterial);
            clientMaterials.Add(someMaterial);
            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material2",
                Color = materialColor

            };
            _repository.Add(someMaterial2);
            clientMaterials.Add(someMaterial2);

            CollectionAssert.AreEquivalent(clientMaterials, _repository.GetMaterialsByClient(_someClient));
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
            _repository.Add(someMaterial);
    
            Material someMaterial2 = new Lambertian()
            {
                Proprietary = _someClient,
                Name = "New Material2",
                Color = materialColor

            };
            _repository.Add(someMaterial2);
          

            _repository.Delete(someMaterial);
            CollectionAssert.DoesNotContain(_repository.GetMaterialsByClient(_someClient), someMaterial);
        }

    }
}