using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Logic;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogicTest
{
    [TestClass]
    public class MaterialLogicTests
    {
        private Client _someClient;
        private MaterialLogic _logic;
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
            _logic = new MaterialLogic();
            
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
                Assert.AreEqual(EmptyNameMessage,ex.Message);

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
            _logic.CreateLambertian(_someClient,"Material1",materialColor);
            _logic.CreateLambertian(_someClient, "Material2", materialColor);


            _logic.DeleteMaterial(someMaterial);
            CollectionAssert.DoesNotContain(_logic.GetClientMaterials(_someClient), someMaterial);
        }

    }
}