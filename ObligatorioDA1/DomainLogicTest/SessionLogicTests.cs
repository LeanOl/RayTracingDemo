
using System;
using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace DomainLogicTest
{
    [TestClass]
    public class SessionLogicTests
    {
        private Client _aClient;
        private ClientRepository _clientRepository;
        private ClientLogic _clientLogic;
        private SessionLogic _sessionLogic;
        const string Username = "John";
        const string Password = "Abc12345";
        [TestInitialize]
        public void Initialize()
        {
            
            DateTime testDate = DateTime.Now;

            _aClient = new Client()
            {
                Username = Username,
                Password = Password,
                RegisterDate = testDate
            };
            _clientRepository=new ClientRepository();
            _clientLogic=new ClientLogic(_clientRepository);
            _sessionLogic=new SessionLogic(_clientRepository);

            
        }

        [TestMethod]
        public void LogInWithCorrectCredentials()
        {
            _clientLogic.CreateClient(Username,Password);
            _sessionLogic.LogIn(Username, Password);
            Client activeUser= _sessionLogic.GetActiveUser();
            Assert.AreEqual(activeUser,_aClient);

        }
    }
}
