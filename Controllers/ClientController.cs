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

        public  List<Client> GetListClient(string strConnexion)
        {
            return ClientRepo.GetListClients(strConnexion);
        }


    }
}
