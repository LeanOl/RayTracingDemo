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
        const string ValidUsername = "John";
        const string ValidPassword = "Abc12345";
        const string emptyName = "   ";
        const string whitespaceFirstName = "  Figure";
        const string whitespaceAtEndName = "Figure  ";
        private const string EmptyNameMessage = "Figure name should not be empty";
        private const string StartsOrEndsWithWhitespaceMessage = "Figure name should not start or end with whitespaces";
        Color materialColor = Color.FromArgb(205, 215, 235);

        [TestInitialize]
        public void Initialize()
        {
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

            Assert.AreEqual(aMaterial, aMaterial2);
        }

        [TestMethod]
        public void CreateLambertianEmptyName_ThrowException()
        {
            Material aMaterial = new Lambertian()
            {
                Proprietary = _aClient,
                Name = emptyName,
                Color = materialColor
            };

            try
            {
                aMaterial.Validate();
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
            Material aMaterial = new Lambertian()
            {
                Proprietary = _aClient,
                Name = whitespaceAtEndName,
                Color = materialColor
            };

            try
            {
                aMaterial.Validate();
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
            Material aMaterial = new Lambertian()
            {
                Proprietary = _aClient,
                Name = whitespaceFirstName,
                Color = materialColor
            };

            try
            {
                aMaterial.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(StartsOrEndsWithWhitespaceMessage, ex.Message);
            }
        }
    }
}
