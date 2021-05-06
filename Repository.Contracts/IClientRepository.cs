using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface IClientRepository
    {
        Client CreateClient(Client client);
        Client GetClientById(int id);
        void UpdateClient(Client client);
        List<Client> GetClients();
    }
}
