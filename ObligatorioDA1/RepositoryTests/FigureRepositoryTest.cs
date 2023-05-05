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
        private const string ValidFigureName = "Ball";
        private const string ValidUsername = "John";
        private int ValidRadius = 5;

        [TestMethod]
        public void AddFigureTest()
        {
            Client aClient = new Client()
            {
                Username = ValidUsername
            };

            Figure aFigure = new Sphere()
            {
                Propietary = aClient,
                Name = ValidFigureName,
                Radius = ValidRadius
            };

            FigureRepository repository = new FigureRepository();
            repository.AddFigure(aFigure);
            Figure storedFigure = repository.GetFigureByName(ValidFigureName);
            Assert.AreEqual(aClient.Username, storedFigure.Propietary.Username);
            Assert.AreEqual(ValidFigureName, storedFigure.Name);
            Assert.AreEqual(ValidRadius, ((Sphere)storedFigure).Radius);
        }
    }
}
