using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using System.Collections.Generic;

namespace LogicTest
{
    [TestClass]
    public class FigureLogicTests
    {
        private Client aClient;
        private Figure aFigure;
        private FigureLogic logic;
        private const string validFigureName = "Ball";
        private const string validUsername = "John";
        private decimal validRadius = 5;
       
        private const string figureAlreadyExistsMessage = "A figure with that name already exists";
        private const string figuredIsUsedByModelMessage = "This figure cannot be removed because a model is using it";

        [TestInitialize]
        public void initialize()
        {
            aClient = new Client()
            {
                Username = validUsername
            };
            aFigure = new Sphere()
            {
                Propietary = aClient,
                Name = validFigureName,
                Radius = validRadius
            };
            logic = FigureLogic.Instance;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            FigureLogic.Reset();
        }
         
        [TestMethod]
        public void CreateFigureTestAndCheckIfItExists()
        {
            Exception exceptionCaught = null;
            bool figureWasCreated = false;
             
            try
            {
                logic.CreateFigure(aFigure);
                figureWasCreated = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            }catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNull(exceptionCaught);
            Assert.IsTrue(figureWasCreated);
        }

        [TestMethod]
        public void CheckIfFigureDoesNotExist()
        {
            Exception exceptionCaught = null;

            //Initialized on true to prevent the test from succeding on accident
            bool figureWasCreated = true; 


            try
            {
                figureWasCreated = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNull(exceptionCaught);
            Assert.IsFalse(figureWasCreated);
        }

        [TestMethod]
        public void FigureAlreadyExistsError(){
            Exception exceptionCaught = null;


            logic.CreateFigure(aFigure);

            try
            {
                logic.CreateFigure(aFigure);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ElementAlreadyExistsException));
            Assert.AreEqual(exceptionCaught.Message, figureAlreadyExistsMessage);
        }   

        [TestMethod]
        public void RemoveAFigureSuccessfully()
        {
            bool itExists = false;


            logic.CreateFigure(aFigure);
            
            itExists = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            Assert.IsTrue(itExists);

            logic.RemoveFigure(aFigure.Name, aFigure.Propietary.Username);
 
            itExists = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            Assert.IsFalse(itExists);

        }

        [TestMethod]
        public void RemoveAFigureUsedByAModelError()
        {

            Exception exceptionCaught = null;

            logic.CreateFigure(aFigure);

            bool itExists = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            Assert.IsTrue(itExists);

            try
            {
                logic.RemoveFigure(aFigure.Name, aFigure.Propietary.Username);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            itExists = logic.FigureExists(aFigure.Name, aFigure.Propietary.Username);
            Assert.IsTrue(itExists);

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(CannotDeleteException));
            Assert.AreEqual(exceptionCaught.Message, figuredIsUsedByModelMessage);
             
        }

        [TestMethod]
        public void GetFiguresByClientSuccessfully()
        {
            List<Figure> repositoryCollection = logic.GetFiguresByClient(aClient);

            List<Figure> figureCollection = new List<Figure>();

            logic.CreateFigure(aFigure);

            CollectionAssert.AreEquivalent(figureCollection, repositoryCollection);
        }
    }   
}
