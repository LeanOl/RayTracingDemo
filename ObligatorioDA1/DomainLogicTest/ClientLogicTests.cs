using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class ClientLogicTests
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
            logic = ClientLogic.Instance;
        }

        [TestCleanup]
        public void Cleanup()
        {
            ClientLogic.Reset();
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
        public void ClientConfirmPasswordDoesNotMatch_ThrowException()
        {
            const string password1= "Abc234";
            const string password2 = "Abc235";
            const string PasswordDoesNotMatchMessage = "Password does not match";
            try
            {
                logic.ValidateConfirmPassword(password1, password2);
                Assert.Fail("Should throw exception");

            }
            catch (Exception ex)
            {
                Assert.AreEqual(PasswordDoesNotMatchMessage, ex.Message);
            }
        }
        [TestMethod]
        public void GetClientByUsernameSuccessfully()
        {
            logic.CreateClient(ValidUsername,ValidPassword);
            Client resultClient=logic.GetClientByUsername(ValidUsername);
            Assert.AreEqual(resultClient.Username,ValidUsername);
        }



    }

  
}
