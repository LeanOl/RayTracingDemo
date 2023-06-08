using System;
using System.Drawing;
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
        public void CreateLambertianEmptyName_ThrowException()
        {
            const string emptyName = "   ";
            try
            {
                _logic.CreateLambertian(_someClient, emptyName, _color);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(EmptyNameMessage, ex.Message);

            }

        }

        [TestMethod]
        public void CreateLambertianEndsWithWhitespace_ThrowException()
        {
            const string whitespaceAtEndName = "Figure  ";
            try
            {
                _logic.CreateLambertian(_someClient, whitespaceAtEndName, _color);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(StartsOrEndsWithWhitespaceMessage, ex.Message);

            }
        }

        [TestMethod]
        public void CreateLambertianBeginsWithWhitespace_ThrowException()
        {
            const string whitespaceFirstName = "  Figure";
            try
            {
                _logic.CreateLambertian(_someClient, whitespaceFirstName, _color);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(StartsOrEndsWithWhitespaceMessage, ex.Message);

            }
        }

    }
}
