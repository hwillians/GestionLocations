using Models;
using Repository.Contracts;
using System;
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

        public Client CreateClient(Client client) => ClientRepo.CreateClient(client);

        public List<Client> GetClients() => ClientRepo.GetClients();

        public Client GetClientById(int id) => ClientRepo.GetClientById(id);

        public void UpdateClient(Client client) => ClientRepo.UpdateClient(client);
    }
}
