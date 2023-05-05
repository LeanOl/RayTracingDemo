using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainTest
{
    [TestClass]
    public class ClientTests
    {
        private const string ValidUsername = "John";
        private const string ValidPassword = "Abc12345";
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
    }
}
