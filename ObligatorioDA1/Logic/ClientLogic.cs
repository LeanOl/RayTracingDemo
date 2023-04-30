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
        public void CreateClient(Client aClient)
        {
            if (aClient.Username.Length < 3)
            {
                throw new ArgumentException( "Username has to be at least 3 characters long");
            }
        }
    }
}
