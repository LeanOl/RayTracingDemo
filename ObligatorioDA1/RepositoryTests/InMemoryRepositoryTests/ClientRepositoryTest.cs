using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.InMemoryRepository;

namespace RepositoryTests.InMemoryRepositoryTests
{
    [TestClass]
    public class ClientRepositoryTest
    {
        private const string ValidUsername = "John";
        private const string ValidUserPassword = "Abc12345";
        private DateTime TestDate = DateTime.Now;
        [TestMethod]
        public void AddClient()
        {
            
            Client aClient = new Client()
            {
                Username = ValidUsername,
                Password = ValidUserPassword,
                RegisterDate = TestDate
            };
            ClientRepository repository = new ClientRepository();
            repository.AddClient(aClient);
            Assert.AreEqual(aClient, repository.GetClientByUsername(ValidUsername));
        }
    }
}
