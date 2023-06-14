using Domain;

namespace Repository
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        Client GetClientByUsername(string username);
    }
}