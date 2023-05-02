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
            if (_repository.GetClientByUsername(username) == null)
                throw new InvalidCredentialException("Incorrect user or password");
            _session.ActiveUser= _repository.GetClientByUsername(username);

        }

        public Client GetActiveUser()
        {
            return _session.ActiveUser;
        }
    }
}
