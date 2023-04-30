using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;

namespace DomainLogicTest
{
    [TestClass]
    public class ClientTests
    {
        private ClientLogic logic;
        private const string ValidName = "John";
        private const string NameBelowCharLimit = "A5";
        private const string ValidPassword = "Abc12345";
        private DateTime TestDate = DateTime.Now;
        private const string UsernameBelowCharLimitMessage = "Username has to be at least 3 characters long";

        [TestInitialize]
        public void TestInit()
        {
            logic = new ClientLogic();
        }
        [TestMethod]
        public void CreateClientSuccessfully()
        {

            Client aClient = new Client()
            {
                Username = ValidName,
                Password = ValidPassword,
                RegisterDate = TestDate
            };
            
            Assert.IsNotNull(aClient);
            Assert.AreEqual(aClient.Username,ValidName);
            Assert.AreEqual(aClient.Password,ValidPassword);
            Assert.AreEqual(aClient.RegisterDate,TestDate);

        }
       
        [TestMethod]
        public void ClientUsernameBelowCharacterLimit_ThrowException()
        {

            Client aClient = new Client()
            {
                Username = NameBelowCharLimit,
                Password = ValidPassword,
                RegisterDate = TestDate
            };
            logic = new ClientLogic();
            try
            {
                logic.CreateClient(aClient);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message,UsernameBelowCharLimitMessage);
            }



        }

    }

  
}
