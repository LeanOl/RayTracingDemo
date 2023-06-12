using System.Linq;
using Domain;

namespace Repository.DBRepository
{
    public class ClientDbRepository : IClientRepository
    {
        private RayTracingContext _context;

        public ClientDbRepository(RayTracingContext context)
        {
            _context = context;
        }

        public ClientDbRepository()
        {
            _context = new RayTracingContext();
        }

        public void AddClient(Client aClient)
        {
            _context.Clients.Add(aClient);
            _context.SaveChanges();
        }

        public Client GetClientByUsername(string username)
        {
            return _context.Clients.FirstOrDefault(aClient => aClient.Username == username);
        }
    }
}