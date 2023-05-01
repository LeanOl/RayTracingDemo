using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    
    public class ClientRepository
    {
         private List<Client> Clients { get; set; }
         public ClientRepository()
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client aClient)
        {
            Clients.Add(aClient);
        }

        public Client GetClientByUsername(string username)
        {
            return Clients.FirstOrDefault(aClient => aClient.Username == username);
        }
    }
}
