using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
            ValidatePassword(password);
            if (!username.All(Char.IsLetterOrDigit))
            {
                throw new ArgumentException("Username has to be alphanumeric");
            }
            Client aClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = DateTime.Today
            };
            _repository.AddClient( aClient );
            
        }

        private void ValidatePassword(string password)
        {
            ValidatePasswordHasCaps(password);

            ValidatePasswordHasNumber(password);

            ValidatePasswordLengthBelowLimit(password);

            ValidatePasswordLengthAboveLimit(password);
        }

        private void ValidatePasswordLengthAboveLimit(string password)
        {
            const int maxLength = 25;
            if (password.Length > maxLength)
            {
                throw new ArgumentException($"Your password has to be at most {maxLength} characters long");
            }
        }

        private void ValidatePasswordLengthBelowLimit(string password)
        {
            const int minLength = 5;
            if (password.Length < minLength)
            {
                throw new ArgumentException($"Your password has to be at least {minLength} characters long");
            }
        }

        private void ValidatePasswordHasNumber(string password)
        {
            if (!password.Any(Char.IsDigit))
            {
                throw new ArgumentException("Your password has to have at least 1 number");
            }
        }

        private void ValidatePasswordHasCaps(string password)
        {
            if (password == password.ToLower())
            {
                throw new ArgumentException("Your password has to have at least 1 Capital letter");
            }
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
            const int maxLength = 20;
            if (username.Length > maxLength)
            {
                throw new ArgumentException($"Username has to be at most {maxLength} characters long");
            }
        }

        private void ValidateUsernameLengthBelowLimit(string username)
        {
            const int minLength = 3;
            if (username.Length < minLength)
            {
                throw new ArgumentException($"Username has to be at least {minLength} characters long");
            }
        }
    }
}
