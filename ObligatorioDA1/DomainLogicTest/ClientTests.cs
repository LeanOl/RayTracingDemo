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
        private const string ValidUsername = "John";
        private const string UsernameBelowCharLimit = "A5";
        private const string UsernameAboveCharLimit = "abcdefdsddessssasddeeeeeeeeeeeee";
        private const string UsernameNotAlphanumeric = "A5#?_@";
        private const string ValidPassword = "Abc12345";
        private const string PasswordWithNoCaps = "abc12345";
        private const string PasswordWithNoNumber = "Abcdefg";
        private const string PasswordBelowCharLimit = "Ab1";
        private const string PasswordAboveCharLimit = "Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1Ab1";
        private const string UsernameBelowCharLimitMessage = "Username has to be at least 3 characters long";
        private const string UsernameAboveCharLimitMessage = "Username has to be at most 20 characters long";
        private const string UsernameDuplicatedMessage = "The Username already exists";
        private const string UsernameNotAlphanumericMessage = "Username has to be alphanumeric";
        private const string PasswordWithNoCapsMessage = "Your password has to have at least 1 Capital letter";
        private const string PasswordWithNoNumberMessage = "Your password has to have at least 1 number";
        private const string PasswordBelowCharLimitMessage = "Your password has to be at least 5 characters long";
        private const string PasswordAboveCharLimitMessage = "Your password has to be at most 25 characters long";


        [TestInitialize]
        public void TestInit()
        {
            logic = new ClientLogic();
        }

        [TestCleanup]
        public void Cleanup()
        {
            logic = null;
        }
        [TestMethod]
        public void CreateClientObjectSuccessfully()
        {
            DateTime testDate = DateTime.Now;

            Client aClient = new Client()
                {
                    Username = ValidUsername,
                    Password = ValidPassword,
                    RegisterDate = testDate
                };
               
            Assert.IsNotNull(aClient);
            Assert.AreEqual(ValidUsername, aClient.Username);
            Assert.AreEqual(ValidPassword, aClient.Password);
            Assert.AreEqual(testDate, aClient.RegisterDate);

        }
       
        [TestMethod]
        public void ClientUsernameBelowCharacterLimit_ThrowException()
        {

            try
            {
                logic.CreateClient(UsernameBelowCharLimit,ValidPassword);
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
                logic.CreateClient(UsernameAboveCharLimit,ValidPassword);
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

            logic.CreateClient(ValidUsername,ValidPassword);

            try
            {
                logic.CreateClient(ValidUsername, ValidPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameDuplicatedMessage, ex.Message);
            }
        }
        [TestMethod]
        public void ClientPasswordNoCaps_ThrowException()
        {

            try
            {
                logic.CreateClient(ValidUsername, PasswordWithNoCaps);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(PasswordWithNoCapsMessage, ex.Message);
            }

        }
        [TestMethod]
        public void ClientPasswordNoNumber_ThrowException()
        {

            try
            {
                logic.CreateClient(ValidUsername, PasswordWithNoNumber);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(PasswordWithNoNumberMessage, ex.Message);
            }

        }
        [TestMethod]
        public void ClientPasswordBelowCharLimit_ThrowException()
        {

            try
            {
                logic.CreateClient(ValidUsername, PasswordBelowCharLimit);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(PasswordBelowCharLimitMessage, ex.Message);
            }

        }
        [TestMethod]
        public void ClientPasswordAboveCharLimit_ThrowException()
        {

            try
            {
                logic.CreateClient(ValidUsername, PasswordAboveCharLimit);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(PasswordAboveCharLimitMessage, ex.Message);
            }

        }
        [TestMethod]
        public void ClientUsernameNotAlphanumeric_ThrowException()
        {

            try
            {
                logic.CreateClient(UsernameNotAlphanumeric, ValidPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameNotAlphanumericMessage, ex.Message);
            }

        }


    }

  
}
