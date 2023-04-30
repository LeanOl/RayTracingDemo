using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Logic
{
    public class ClientLogic
    {
        public void CreateClient(string username,string password )
        {
            ValidateUsername(username);
            Client aClient = new Client()
            {
                Username = username,
                Password = password,
                RegisterDate = DateTime.Today
            };
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
