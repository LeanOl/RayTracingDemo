using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainLogicTest
{
    [TestClass]
    public class ClientTests
    {
        private const string TestName = "John";
        private const string TestPassword = "Abc12345";
        private DateTime TestDate = DateTime.Now;
        [TestMethod]
        public void CreateClientSuccessfully()
        {

            Client aClient = new Client()
            {
                Username = TestName,
                Password = TestPassword,
                RegisterDate = TestDate
            };
            
            Assert.IsNotNull(aClient);
            Assert.AreEqual(aClient.Username,TestName);
            Assert.AreEqual(aClient.Password,TestPassword);
            Assert.AreEqual(aClient.RegisterDate,TestDate);

        }

       
    }

  
}
