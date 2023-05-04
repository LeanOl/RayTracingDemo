using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Logic;

namespace DomainLogicTest
{
    [TestClass]
    public class MaterialLogicTests
    {
        private Client _someClient;
        private MaterialLogic _logic;
        private Color _color;
        private const string ValidName = "Figure";
        
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
            _logic = new MaterialLogic();
            
        }

        [TestMethod]
        public void CreatedLambertianSuccessfully()
        {
            Material testMaterial = new Lambertian()
            {
                Owner = _someClient,
                Name = ValidName,
                Color = _color
            };
            _logic.CreateLambertian(_someClient, ValidName, _color);
            Assert.AreEqual(testMaterial,_logic.GetMaterialByName(ValidName));
        }
    }
}