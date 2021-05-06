using Models;
using Repository.Contracts;
using System.Collections.Generic;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        public Client CreateClient(Client client)
        {
            return client;
        }

        public List<Client> GetListClients()
        {
            return new List<Client>();
        }
    }
}
