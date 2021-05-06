using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface IClientRepository
    {
        Client CreateClient(Client client, string strConnexion);
        List<Client> GetListClients(string strConnexion);
    }
}
