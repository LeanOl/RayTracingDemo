using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class SessionTests
    {
        private Client aClient;

        [TestInitialize]
        public void Initialize()
        {
            const string ValidUsername = "John";
            const string ValidPassword = "Abc12345";
            DateTime testDate = DateTime.Now;

            aClient = new Client()
            {
                Username = ValidUsername,
                Password = ValidPassword,
                RegisterDate = testDate
            };

        }


        [TestMethod]
        public void CreateSessionSuccessfully()
        {
            Session aSession = new Session()
            {
                ActiveUser = aClient
            };
            Assert.IsNotNull(aSession);
            Assert.AreEqual(aClient, aSession.ActiveUser);
        }
    }
}
