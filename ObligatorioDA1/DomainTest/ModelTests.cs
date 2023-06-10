using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class ModelTests
    {
        private Client _proprietary;
        private Figure _figure;
        private Material _material;
        private const string ValidModelName = "Modelo";
        private const string NameThatEndsWithSpaces = "Model1 ";
        private const string NameEmpty = "";
        private const string MessageNameThatEndsWithSpaces = "Model name should not start or end with whitespaces";
        private const string MessageNameEmpty = "Model name should not be empty";
        private const string MessageNullFigure = "Figure should not be null";
        private const string MessageNullMaterial = "Material should not be null";

        [TestInitialize]
        public void Initialize()
        {
            const string ValidUsername = "John";
            const string ValidPassword = "Abc12345";
            DateTime testDate = DateTime.Now;

            _proprietary = new Client()
            {
                Username = ValidUsername,
                Password = ValidPassword,
                RegisterDate = testDate
            };
             _figure = new Sphere()
            {
                Proprietary = _proprietary,
                Name = "Figura",
                Radius = 12
            };
             Color materialColor = Color.FromArgb(205, 215, 235);
              _material = new Lambertian()
             {
                 Proprietary = _proprietary,
                 Name = "New Color",
                 Color = materialColor

             };

        }
        [TestMethod]
        public void CreateModelSuccessfully()
        {
            Image preview=null;
            Model model = new Model()
            {
                Proprietary=_proprietary,
                Name="Modelo",
                Figure=_figure,
                Material=_material,
                Preview= null

            };
            Assert.IsNotNull(model);
            Assert.AreEqual(_proprietary, model.Proprietary);
            Assert.AreEqual("Modelo", model.Name);
            Assert.AreEqual(_figure, model.Figure);
            Assert.AreEqual(_material, model.Material);
            Assert.AreEqual(preview, model.Preview);

        }

        [TestMethod]
        public void GeneratePreviewOk()
        {
            Image preview = null;
            Model model = new Model()
            {
                Proprietary = _proprietary,
                Name = "Modelo",
                Figure = _figure,
                Material = _material,
                Preview = null
            };
            model.GeneratePreview();
            Assert.IsNotNull(model.Preview);
        }

        [TestMethod]
        public void ModelNameEndsWhitespace_ThrowException()
        {
            Model model = new Model()
            {
                Proprietary = _proprietary,
                Name = NameThatEndsWithSpaces,
                Figure = _figure,
                Material = _material,
            };

            try
            {
                model.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual(MessageNameThatEndsWithSpaces, e.Message);
            }
        }

        [TestMethod]
        public void ModelFigureNull_ThrowException()
        {
            Model model = new Model()
            {
                Proprietary = _proprietary,
                Name = ValidModelName,
                Figure = null,
                Material = _material,
            };

            try
            {
                model.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual(MessageNullFigure, e.Message);
            }

        }

        [TestMethod]
        public void CreateModelEmptyName_ThrowException()
        {
            Model model = new Model()
            {
                Proprietary = _proprietary,
                Name = NameEmpty,
                Figure = _figure,
                Material = _material,
            };
            try
            {
                model.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual(MessageNameEmpty, e.Message);
            }
        }

        [TestMethod]
        public void ModelMaterialNull_ThrowException()
        {
            Model model = new Model()
            {
                Proprietary = _proprietary,
                Name = ValidModelName,
                Figure = _figure,
                Material = null,
            };

            try
            {
                model.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception e)
            {
                Assert.AreEqual(MessageNullMaterial, e.Message);
            }

        }
    }
}
