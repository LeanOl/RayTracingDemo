using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Drawing;

namespace RepositoryTests
{
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
                Owner = _someClient,
                Name = "New Material",
                Color = materialColor

            };
            _repository.Add(someMaterial);
            Assert.AreEqual(someMaterial,_repository.GetByName("New Material"));

        }
    }
}