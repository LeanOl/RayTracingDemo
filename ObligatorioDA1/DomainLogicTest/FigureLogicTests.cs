using Domain;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainLogicTest
{
    [TestClass]
    public class FigureLogicTests
    {
        private Client aClient;
        private Figure aFigure;
        private const string validFigureName = "Ball";
        private const string validUsername = "John";
        private int validRadius = 5;
        private const int negativeRadius = -5;
        
        private const string invalidRadiusMessage = "Radius must be a positive decimal number";
        private const string invalidEmptyNameMessage = "The name must not be empty";
        private const string invalidNameWithSpacesMessage = "Name must not start or end with spaces";
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

        [TestMethod]
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

        [TestMethod]
        public void FigureAlreadyExistsError(){
            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            try
            {
                

            }catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ElementAlreadyExistsException));
            Assert.AreEqual(exceptionCaught.Message, figureAlreadyExistsMessage);

        }

        [TestMethod]
        public void InvalidEmptyNameError()
        {
            Exception exceptionCaught = null;
            
            FigureLogic logic = new FigureLogic();

            Sphere invalidFigure = new Sphere()
            {
                Propietary = aClient,
                Name = "",
                Radius = validRadius
            };
            
            try
            {
                logic.CreateFigure(invalidFigure);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidEmptyNameMessage);
             
        }

        [TestMethod]
        public void InvalidNameWithSpacesInBeginningOrEndError()
        {
            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            Sphere invalidFigure = new Sphere()
            {
                Propietary = aClient,
                Name = "   ball  ",
                Radius = validRadius
            };

            try
            {
                logic.CreateFigure(invalidFigure);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidNameWithSpacesInBeginning()
        {
            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            Sphere invalidFigure = new Sphere()
            {
                Propietary = aClient,
                Name = "   ball",
                Radius = validRadius
            };

            try
            {
                logic.CreateFigure(invalidFigure);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidNameWithSpacesInEnd()
        {
            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            Sphere invalidFigure = new Sphere()
            {
                Propietary = aClient,
                Name = "ball    ",
                Radius = validRadius
            };

            try
            {
                logic.CreateFigure(invalidFigure);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidRadiusError()
        {
            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            Sphere invalidFigure = new Sphere()
            {
                Propietary = aClient,
                Name = validFigureName,
                Radius = negativeRadius
            };

            try
            {
                logic.CreateSphere(invalidFigure);

            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidRadiusMessage);

        }

        [TestMethod]
        public void RemoveAFigureSuccessfully()
        {
            bool itExists = false;
            FigureLogic logic = new FigureLogic();

            logic.CreateFigure(aFigure);
            
            itExists = logic.FigureExists(aFigure.Name);
            Assert.IsTrue(itExists);

            logic.RemoveFigure(aFigure.Name);
 
            itExists = logic.FigureExists(aFigure.Name);
            Assert.IsFalse(itExists);
        }
    

        [TestMethod]
        public void RemoveAFigureUsedByAModelError()
        {

            Exception exceptionCaught = null;

            FigureLogic logic = new FigureLogic();

            logic.CreateFigure(aFigure);

            bool itExists = logic.FigureExists(aFigure.Name);
            Assert.IsTrue(itExists);

            try
            {
                logic.RemoveFigure(aFigure.Name);
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            itExists = logic.FigureExists(aFigure.Name);
            Assert.IsTrue(itExists);

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(CannotDeleteException));
            Assert.AreEqual(exceptionCaught.Message, figuredIsUsedByModelMessage);

        }
    }   
}
