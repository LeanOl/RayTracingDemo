using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainLogicTest
{
    [TestClass]
    public class MaterialLogicTests
    {
        private Client _someClient;
        //private MaterialLogic _logic;
        [TestInitialize]
        public void Initialize()
        {

            DateTime testDate = DateTime.Now;
            const string username = "John";
            const string password = "Abc12345";

            _someClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = testDate
            };
            
        }

        [TestMethod]
        public void CreatedLambertianSuccessfully()
        {

        }
    }
}