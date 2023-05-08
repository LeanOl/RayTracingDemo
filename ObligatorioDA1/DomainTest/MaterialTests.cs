using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTest
{
    [TestClass]
    public class MaterialTests
    {
        private Client _aClient;
        [TestInitialize]
        public void Initialize()
        {
            const string ValidUsername = "John";
            const string ValidPassword = "Abc12345";
            DateTime testDate = DateTime.Now;

            _aClient = new Client()
            {
                Username = ValidUsername,
                Password = ValidPassword,
                RegisterDate = testDate
            };

        }
        [TestMethod]
        public void CreateLambertianMaterialSuccessfully()
        {
            Color materialColor = Color.FromArgb(205, 215, 235);
            Material aMaterial = new Lambertian()
            {
                Proprietary = _aClient,
                Name = "New Color",
                Color= materialColor

            };
            Assert.IsNotNull(aMaterial);
            Assert.AreEqual(materialColor, aMaterial.Color);
            Assert.AreEqual(_aClient,aMaterial.Proprietary);
            
        }

        [TestMethod]
        public void EqualMaterialsTrue()
        {
            Color materialColor = Color.FromArgb(205, 215, 235);
            Material aMaterial = new Lambertian()
            {
                Proprietary = _aClient,
                Name = "New Color",
                Color = materialColor

            };

            Material aMaterial2 = new Lambertian()
            {
                Proprietary = _aClient,
                Name = "New Color",
                Color = materialColor

            };

            Assert.AreEqual(aMaterial,aMaterial2);
            
        }

        [TestMethod]
        public void LambertianCalculateColor()
        {

        }
    }
}
