using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainLogicTest
{
    [TestClass]
    public class FigureLogicTests
    {
        private Client aClient;
        private Figure aFigure;
        private const string ValidFigureName = "Ball";
        private const string ValidUsername = "John";
        private int ValidRadius = 5;

        [TestInitialize]
        public void initialize()
        {
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

        [TestMethod]
        public void CreateFigureTestAndCheckIfItExists()
        {
            Exception exceptionCaught = null;
            bool figureWasCreated = false;
            FigureLogic logic = new FigureLogic();

            try
            {
                logic.CreateFigure(aFigure);

                figureWasCreated = logic.FigureExists(aFigure.Name);
            }catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNull(exceptionCaught);
            Assert.IsTrue(figureWasCreated);
        }

        public void CheckIfFigureDoesNotExist()
        {
            Exception exceptionCaught = null;

            //Initialized on true to prevent the test from succeding on accident
            bool figureWasCreated = true; 

            FigureLogic logic = new FigureLogic();

            try
            {
                figureWasCreated = logic.FigureExists(aFigure.Name);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNull(exceptionCaught);
            Assert.IsFalse(figureWasCreated);
        }

    }
}
