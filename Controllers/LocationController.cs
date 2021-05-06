using Models;
using Repository.Contracts;
using System.Collections.Generic;

namespace Controllers
{
    public class LocationController
    {
        private ILocationRepository LocationRepo { get; }

        public LocationController(ILocationRepository locationRepo)
        {
            LocationRepo = locationRepo;
        }

        public List<Location> GetListClient(string strConnexion)
        {
            return LocationRepo.GetListClients(strConnexion);
        }

    }
}
