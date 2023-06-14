using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using Domain;
using Logic;
using Repository;
using Repository.DBRepository;

namespace LogicTest
{
    [TestClass]
    public class ClientLogicTests
    {
        private ClientLogic logic;
        private RayTracingContext _context ;
        private const string ValidUsername = "John";
        private const string ValidPassword = "Abc12345";
        private const string UsernameDuplicatedMessage = "The Username already exists";

        [TestInitialize]
        public void TestInit()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RayTracingContext>());
            _context = new RayTracingContext();
            _context.Database.Initialize(true);
            IClientRepository repository = new ClientDbRepository(_context);
            logic = new ClientLogic(repository);
        }

        [TestCleanup]
        public void Cleanup()
        {
          _context.Dispose();
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
