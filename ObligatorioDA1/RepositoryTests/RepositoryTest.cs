using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class RepositoryTest
    {
        private const string ValidUsername = "John";
        private const string ValidUserPassword = "Abc12345";
        private DateTime TestDate = DateTime.Now;
        [TestMethod]
        public void AddClient()
        {
            ClientRepository aRepository = new ClientRepository();
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = ValidUserPassword,
                RegisterDate = TestDate
            };
            aRepository.AddClient(aClient);
            Assert.AreEqual(aRepository.GetClientByName(ValidUsername),aClient);
        }
    }
}
