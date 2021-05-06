using Models;
using System.Collections.Generic;

namespace Repository.Contracts
{
    public interface ILocationRepository
    {
        Location CreateLocation(Location location);
        List<Location> GetListLocations();
    }
}
