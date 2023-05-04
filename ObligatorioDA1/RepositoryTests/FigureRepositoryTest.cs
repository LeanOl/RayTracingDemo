using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryTests
{

    [TestClass]
    public class FigureRepositoryTest
    {
        FigureRepository repository;
        Client aClient;
        Figure aFigure; 
        private const string ValidFigureName = "Ball";
        private const string ValidUsername = "John";
        private int ValidRadius = 5;

        [TestInitialize]
        public void TestInit()
        {
            repository = new FigureRepository();

            aClient = new Client()
            {
                Username = ValidUsername
            };

            aFigure = new Sphere()
            {
                Propietary = aClient,
                Name = ValidFigureName,
                Radius = ValidRadius
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
           repository = null;
           aClient = null;
           aFigure = null;
        }

        [TestMethod]
        public void AddFigure()
        {
            repository.AddFigure(aFigure);
            Figure storedFigure = repository.GetFigureByName();
            Assert.AreEqual(aClient, storedFigure.getPropietary());
            Assert.AreEqual(ValidFigureName, storedFigure.getName());
            Assert.AreEqual(ValidRadius, storedFigure.getRadius());
        }
    }
}
