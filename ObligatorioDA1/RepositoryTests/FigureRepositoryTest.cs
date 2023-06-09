using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Repository;
using System.Collections.Generic;

namespace RepositoryTests
{

    [TestClass]
    public class FigureRepositoryTest
    {
        private const string ValidFigureName = "Ball";
        private const string ValidUsername = "John";
        private decimal ValidRadius = 5;

        private Client aClient;
        private Figure aFigure;

        [TestInitialize]
        public void initialize()
        {
            aClient = new Client()
            {
                Username = ValidUsername
            };
            aFigure = new Sphere()
            {
                Proprietary = aClient,
                Name = ValidFigureName,
                Radius = ValidRadius
            };

        }

        [TestMethod]
        public void AddFigureTest()
        {
            FigureRepository repository = new FigureRepository();
            repository.AddFigure(aFigure);
            Figure storedFigure = repository.GetFigureByName(ValidFigureName);

            Assert.IsNotNull(storedFigure);
            Assert.AreEqual(aClient.Username, storedFigure.Proprietary.Username);
            Assert.AreEqual(ValidFigureName, storedFigure.Name);
            Assert.AreEqual(ValidRadius, ((Sphere)storedFigure).Radius);
        }

        [TestMethod]
        public void DetectingFigureDoesntExist()
        {
            FigureRepository repository = new FigureRepository();

            Assert.IsFalse(repository.FigureExists(ValidFigureName, ValidUsername));
        }
    

        [TestMethod]
        public void DetectingFigureExists()
        {
            FigureRepository repository = new FigureRepository();
            repository.AddFigure(aFigure);

            Assert.IsTrue(repository.FigureExists(ValidFigureName, aFigure.Proprietary.Username));
        }

        [TestMethod]
        public void RemoveFigureTest()
        {
            FigureRepository repository = new FigureRepository();
            repository.AddFigure(aFigure);

            Assert.IsTrue(repository.FigureExists(ValidFigureName, aFigure.Proprietary.Username));

            repository.RemoveFigureByName(ValidFigureName, aFigure.Proprietary.Username);

            Assert.IsFalse(repository.FigureExists(ValidFigureName, aFigure.Proprietary.Username));
        }
    

        [TestMethod]
        public void GetFiguresByClientSuccessfully()
        {
            FigureRepository repository = new FigureRepository();
            List<Figure> repositoryCollection = repository.GetFiguresByClient(aClient);

            List<Figure> figureCollection = new List<Figure>();

            repository.AddFigure(aFigure);

            CollectionAssert.AreEquivalent(figureCollection, repositoryCollection);
        }
    }
}