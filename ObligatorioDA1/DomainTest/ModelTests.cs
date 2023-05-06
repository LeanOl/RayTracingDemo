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
                Propietary = _proprietary,
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
                Preview= preview

            };
            Assert.IsNotNull(model);
            Assert.AreEqual(_proprietary, model.Proprietary);
            Assert.AreEqual("Modelo", model.Name);
            Assert.AreEqual(_figure, model.Figure);
            Assert.AreEqual(_material, model.Material);
            Assert.AreEqual(preview, model.Preview);

        }
    }
}
