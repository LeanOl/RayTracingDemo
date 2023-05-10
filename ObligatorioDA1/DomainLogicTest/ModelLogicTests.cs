using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;

namespace DomainLogicTest
{
    [TestClass]
    public class ModelLogicTests
    {
        private ModelLogic _modelLogic;
        private Client _proprietary;
        private Figure _figure;
        private Material _material;
        [TestInitialize]
        public void Initialize()
        {
            _proprietary = new Client{Username = "John"};
            _modelLogic = new ModelLogic();
            _figure = new Sphere{ Name = "Figure1"};
            _material = new Lambertian { Name = "Material1"};

        }
        [TestMethod]
        public void CreateModelOk()
        {
            _modelLogic.CreateModel("Model1", _proprietary,_figure,_material);
            Assert.IsNotNull(_modelLogic.GetModelByName("Model1"));
        }
    }
}
