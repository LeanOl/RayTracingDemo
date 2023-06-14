using System.Security.Authentication;
using Domain;

namespace Logic
{
    public class SessionLogic
    {
        private readonly ClientLogic _clientLogic;
        private Session _session;
        

        private SessionLogic()
        {
            _clientLogic=ClientLogic.Instance;
            _session = new Session();
        }
        public static SessionLogic Instance { get; } = new SessionLogic();

        public static void Reset()
        {
            Instance._session = new Session();
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

