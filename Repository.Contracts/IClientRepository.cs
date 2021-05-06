using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface IClientRepository
    {
        Client CreateClient(Client client, string strConnexion);
        Client GetClientById(int id, string strConnexion);
        List<Client> GetClients(string strConnexion);
    }
}
