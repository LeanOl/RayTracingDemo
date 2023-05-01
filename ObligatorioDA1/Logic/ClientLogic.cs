using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;


namespace Logic
{
    
    public class ClientLogic
    {
        private ClientRepository _repository;

        public ClientLogic()
        {
            _repository=new ClientRepository();
        }
        public void CreateClient(string username,string password )
        {
            ValidateUsername(username);
            if (password == password.ToLower())
            {
                throw new ArgumentException("Your password has to have at least 1 Capital letter");
            }

            if (!password.Any(Char.IsDigit))
            {
                throw new ArgumentException("Your password has to have at least 1 number");
            }

            if (password.Length < 5)
            {
                throw new ArgumentException("Your password has to be at least 5 characters long");
            }
            if (password.Length > 25)
            {
                throw new ArgumentException("Your password has to be at most 25 characters long");
            }
            Client aClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = DateTime.Today
            };
            _repository.AddClient( aClient );
            
        }

        private void ValidateUsername(string username)
        {
            ValidateUsernameLengthBelowLimit(username);

            ValidateUsernameLengthAboveLimit(username);
            ValidateDuplicateUsername(username);
        }

        private void ValidateDuplicateUsername(string username)
        {
            if (_repository.GetClientByUsername(username) != null)
            {
                throw new DuplicateNameException("The Username already exists");
            }
        }

        private void ValidateUsernameLengthAboveLimit(string username)
        {
            if (username.Length > 20)
            {
                throw new ArgumentException("Username has to be at most 20 characters long");
            }
        }

        private void ValidateUsernameLengthBelowLimit(string username)
        {
            if (username.Length < 3)
            {
                throw new ArgumentException("Username has to be at least 3 characters long");
            }
        }
    }
}
