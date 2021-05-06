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

        public Location CreateLocation(Location location) => LocationRepo.CreateLocation(location);

        public List<Location> GetListLocations() => LocationRepo.GetListLocations();

    }
}
