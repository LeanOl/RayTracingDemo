using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using Domain;
using Repository;
using Repository.DBRepository;

namespace RepositoryTests.DBRepositoryTests
{
    [TestClass]
    public class ClientDbRepositoryTests
    {
        private IClientRepository _clientDBRepository;
        private static RayTracingContext _testContext;

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _testContext = new RayTracingContext();
            _testContext.Database.Initialize(true);
            _clientDBRepository = new ClientDbRepository(_testContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testContext.Dispose();
        }

        [TestMethod]
        public void AddClientOk()
        {
            Client aClient = new Client
            {
                Username = "John",
                Password = "John123",
                RegisterDate = DateTime.Now
            };
            _clientDBRepository.AddClient(aClient);
            Assert.AreEqual(aClient, _clientDBRepository.GetClientByUsername("John"));
        }
    }
}
