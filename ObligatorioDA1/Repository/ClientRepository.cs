using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    
    public class ClientRepository : IClientRepository
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
