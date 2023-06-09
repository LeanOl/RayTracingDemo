using System;
using System.Data;
using System.Linq;
using Domain;
using Repository;


namespace Logic
{
    
    public class ClientLogic
    {
        private ClientRepository _repository;
        
        private ClientLogic()
        {
            _repository=new ClientRepository();
        }
       public static ClientLogic Instance { get; } = new ClientLogic();

       public static void Reset()
       {
           Instance._repository = new ClientRepository();
       }
       public void CreateClient(string username,string password )
        {
            
            ValidateDuplicateUsername(username);
            
            
            Client aClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = DateTime.Today
            };

            aClient.Validate();

            _repository.AddClient( aClient );
            
        }

        private void ValidateDuplicateUsername(string username)
        {
            if (_repository.GetClientByUsername(username) != null)
            {
                throw new DuplicateNameException("The Username already exists");
            }
        }
        
        public void ValidateConfirmPassword(string password1, string password2)
        {
            if (password1 != password2)
            {
                throw new PasswordMismatchException("Password does not match");
            }
        }

        public Client GetClientByUsername(string validUsername)
        {
            return _repository.GetClientByUsername(validUsername);
        }
    }
}
