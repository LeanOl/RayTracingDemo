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
        public void CreateClient(string username,string password )
        {
            ValidateUsername(username);
            if (ClientRepository.GetClientByUsername(username) != null)
            {
                throw new DuplicateNameException("The Username already exists");
            }
            Client aClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = DateTime.Today
            };
            ClientRepository.AddClient( aClient );
            
        }

        private static void ValidateUsername(string username)
        {
            ValidateUsernameLengthBelowLimit(username);

            ValidateUsernameLengthAboveLimit(username);
        }

        private static void ValidateUsernameLengthAboveLimit(string username)
        {
            if (username.Length > 20)
            {
                throw new ArgumentException("Username has to be at most 20 characters long");
            }
        }

        private static void ValidateUsernameLengthBelowLimit(string username)
        {
            if (username.Length < 3)
            {
                throw new ArgumentException("Username has to be at least 3 characters long");
            }
        }
    }
}
