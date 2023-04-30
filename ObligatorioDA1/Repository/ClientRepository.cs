using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    
    public static class ClientRepository
    {
         private static List<Client> Clients { get; set; }
         static ClientRepository()
        {
            Clients = new List<Client>();
        }

        public static void AddClient(Client aClient)
        {
            Clients.Add(aClient);
        }

        public static  Client GetClientByName(string username)
        {
            return Clients.FirstOrDefault(aClient => aClient.Username == username);
        }
    }
}
