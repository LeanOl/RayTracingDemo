using System;
using System.Linq;
using Domain;
using Exceptions;

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
            _context = RayTracingContext.Instance;
        }

        public void AddClient(Client aClient)
        {
            try
            {
                _context.Clients.Add(aClient);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
            
        }

        public Client GetClientByUsername(string username)
        {
            try
            {
                return _context.Clients.FirstOrDefault(aClient => aClient.Username == username);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
            
        }
    }
}