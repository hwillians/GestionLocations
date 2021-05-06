using Models;
using Repository.Contracts;
using System.Collections.Generic;

namespace Repository
{
    public class LocationRepository : ILocationRepository
    {
        public Location CreateClient(Location location)
        {
            return location;
        }

        public List<Location> GetListClients()
        {
            return new List<Location>();
        }
    }
}
