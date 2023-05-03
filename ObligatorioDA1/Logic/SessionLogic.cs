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
        private readonly ClientLogic _clientLogic;
        private Session _session;
        

        public SessionLogic(ClientLogic clientLogic)
        {
            _clientLogic=clientLogic;
            _session = new Session();
        }


        public void LogIn(string username, string password)
        {
            Client aClient = _clientLogic.GetClientByUsername(username);
            Authenticate(password,aClient);
            
            _session.ActiveUser = aClient;

        }

        private void Authenticate(string password,Client aClient)
        {
            VerifyUserExists(aClient);
            VerifyPassword(password, aClient);
        }

        private void VerifyPassword(string password, Client aClient)
        {
            if (aClient.Password != password)
                throw new InvalidCredentialException("Incorrect user or password");
        }

        private void VerifyUserExists(Client aClient)
        {
            if (aClient == null)
                throw new InvalidCredentialException("Incorrect user or password");
        }

        public Client GetActiveUser()
        {
            return _session.ActiveUser;
        }

        public void LogOut()
        {
            _session.ActiveUser=null;
        }
    }


}

