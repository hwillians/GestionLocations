using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface ILocationRepository
    {
        Location CreateLocation(Location location, string strConnexion);
        List<Location> GetListLocations(string strConnexion);
    }
}
