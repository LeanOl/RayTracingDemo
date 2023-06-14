
using System;
using System.Data.Entity;
using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.DBRepository;
using Repository;

namespace LogicTest
{
    [TestClass]
    public class SessionLogicTests
    {
        private Client _aClient;
        private ClientLogic _clientLogic;
        private SessionLogic _sessionLogic;
        private RayTracingContext _context;
        const string Username = "John";
        const string Password = "Abc12345";
        const string WrongCredentialsMessage = "Incorrect user or password";
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

            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _context = new RayTracingContext();
            _context.Database.Initialize(true);
            IClientRepository repository = new ClientDbRepository(_context);
            
            _clientLogic = new ClientLogic(repository); ;
            _sessionLogic= SessionLogic.Instance;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ClientLogic.Reset();
            SessionLogic.Reset();
        }

        [TestMethod]
        public void LogInWithCorrectCredentials()
        {
            _clientLogic.CreateClient(Username,Password);
            _sessionLogic.LogIn(Username, Password);
            Client activeUser= _sessionLogic.GetActiveUser();
            Assert.AreEqual(activeUser,_aClient);

        }

        [TestMethod]
        public void LogInWithNonExistentUsername_ThrowException()
        {
            const string WrongUsername = "BCDE123";
            
            _clientLogic.CreateClient(Username, Password);
            try
            {
                _sessionLogic.LogIn(WrongUsername, Password);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(WrongCredentialsMessage, ex.Message);
            }
            
        }
        [TestMethod]
        public void LogInWithWrongPassword_ThrowException()
        {
            const string WrongPassword = "dasdasdasdad";

            _clientLogic.CreateClient(Username, Password);
            try
            {
                _sessionLogic.LogIn(Username, WrongPassword);
                Assert.Fail("Should throw exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(WrongCredentialsMessage, ex.Message);
            }

        }

        [TestMethod]
        public void LogOutAfterLogInSuccessfully()
        {
            _clientLogic.CreateClient(Username, Password);
            _sessionLogic.LogIn(Username, Password);
            _sessionLogic.LogOut();
            Assert.IsNull(_sessionLogic.GetActiveUser());

        }

    }
}
