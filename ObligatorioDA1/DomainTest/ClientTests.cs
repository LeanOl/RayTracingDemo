using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class ClientTests
    {

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
        private const string UsernameNotAlphanumericMessage = "Username has to be alphanumeric";
        private const string PasswordWithNoCapsMessage = "Your password has to have at least 1 Capital letter";
        private const string PasswordWithNoNumberMessage = "Your password has to have at least 1 number";
        private const string PasswordBelowCharLimitMessage = "Your password has to be at least 5 characters long";
        private const string PasswordAboveCharLimitMessage = "Your password has to be at most 25 characters long";
        DateTime testDate = DateTime.Now;

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void ClientUsernameBelowCharacterLimit_ThrowException()
        {

            Client aClient = new Client()
            {
                Username = UsernameBelowCharLimit,
                Password = ValidPassword,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
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
            Client aClient = new Client()
            {
                Username = UsernameAboveCharLimit,
                Password = ValidPassword,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameAboveCharLimitMessage, ex.Message);
            }
        }

        [TestMethod]
        public void ClientPasswordNoCaps_ThrowException()
        {
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = PasswordWithNoCaps,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
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
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = PasswordWithNoNumber,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
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
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = PasswordBelowCharLimit,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
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
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = PasswordAboveCharLimit,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
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
            Client aClient = new Client()
            {
                Username = UsernameNotAlphanumeric,
                Password = ValidPassword,
                RegisterDate = testDate
            };

            try
            {
                aClient.Validate();
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(UsernameNotAlphanumericMessage, ex.Message);
            }

        }


    }
}
