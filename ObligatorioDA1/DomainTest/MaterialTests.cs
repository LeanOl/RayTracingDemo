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
        private Client aClient;
        [TestInitialize]
        public void Initialize()
        {
            const string ValidUsername = "John";
            const string ValidPassword = "Abc12345";
            DateTime testDate = DateTime.Now;

            aClient = new Client()
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
                Owner = aClient,
                Name = "New Color",
                Color= materialColor

            };
            Assert.IsNotNull(aMaterial);
            Assert.AreEqual(materialColor, aMaterial.Color);
            Assert.AreEqual(aClient,aMaterial.Owner);
            
        }
    }
}
