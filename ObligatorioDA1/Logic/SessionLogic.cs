using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;

namespace Logic
{
    public class SessionLogic
    {
        private readonly ClientRepository _repository;
        private Session _session;
        

        public SessionLogic(ClientRepository clientRepository)
        {
            _repository=clientRepository;
            _session = new Session();
        }


        public void LogIn(string username, string password)
        {
            Client aClient = _repository.GetClientByUsername(username);
            Authenticate(username,aClient);
            _session.ActiveUser = aClient;

        }

        private void Authenticate(string username, Client aClient)
        {
            if (aClient == null)
                throw new InvalidCredentialException("Incorrect user or password");
        }

        public Client GetActiveUser()
        {
            return _session.ActiveUser;
        }
    }


}

