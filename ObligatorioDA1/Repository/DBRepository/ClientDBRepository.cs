using System.Linq;
using Domain;

namespace Repository.DBRepository
{
    public class ClientDBRepository : IClientRepository
    {
        private RayTracingContext _context;

        public ClientDBRepository(RayTracingContext context)
        {
            _context = context;
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