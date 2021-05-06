using Models;
using Repository.Contracts;
using System.Collections.Generic;

namespace Controllers
{
    public class ClientController
    {

        private IClientRepository ClientRepo { get; }

        public ClientController(IClientRepository clientRepo)
        {
            ClientRepo = clientRepo;
        }

        public Client CreateClient(Client client, string strConnexion) => ClientRepo.CreateClient(client, strConnexion);

        public List<Client> GetClients(string strConnexion) => ClientRepo.GetClients(strConnexion);

        public Client GetClientById(int id, string strConnexion) => ClientRepo.GetClientById(id, strConnexion);
    }
}
