using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface ILocationRepository
    {
        Location CreateClient(Location location);
        List<Location> GetListClients(string strConnexion);
    }
}
