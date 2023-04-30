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
        private const string NameAboveCharLimit = "abcdefdsddessssasddeeeeeeeeeeeee";
        private const string ValidPassword = "Abc12345";
        private DateTime TestDate = DateTime.Now;
        private const string UsernameBelowCharLimitMessage = "Username has to be at least 3 characters long";
        private const string UsernameAboveCharLimitMessage = "Username has to be at most 20 characters long";
        private const string UsernameDuplicatedMessage = "The Username already exists";

        [TestInitialize]
        public void TestInit()
        {
            logic = new ClientLogic();
        }
        [TestMethod]
        public void CreateClientObjectSuccessfully()
        {

            Client aClient = new Client()
            {
                Username = ValidName,
                Password = ValidPassword,
                RegisterDate = TestDate
            };
           
            Assert.IsNotNull(aClient);
            Assert.AreEqual(ValidName, aClient.Username);
            Assert.AreEqual(ValidPassword, aClient.Password);
            Assert.AreEqual(TestDate, aClient.RegisterDate);

        }
       
        [TestMethod]
        public void ClientUsernameBelowCharacterLimit_ThrowException()
        {

            try
            {
                logic.CreateClient(NameBelowCharLimit,ValidPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameBelowCharLimitMessage, ex.Message);
            }



        }
        [TestMethod]
        public void ClientUsernameAboveCharacterLimit_ThrowException()
        {

            try
            {
                logic.CreateClient(NameAboveCharLimit,ValidPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameAboveCharLimitMessage,ex.Message );
            }

        }
        [TestMethod]
        public void ClientUsernameDuplicated_ThrowException()
        {

            logic.CreateClient(ValidName,ValidPassword);

            try
            {
                logic.CreateClient(ValidName, ValidPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameDuplicatedMessage, ex.Message);
            }



        }


    }

  
}
