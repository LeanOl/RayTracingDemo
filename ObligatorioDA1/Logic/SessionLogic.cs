using System;
using System.Collections.Generic;
using System.Linq;
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
            
            _session.ActiveUser= _repository.GetClientByUsername(username);

        }

        public Client GetActiveUser()
        {
            return _session.ActiveUser;
        }
    }
}
