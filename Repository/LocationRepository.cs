using Models;
using Repository.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class LocationRepository : ILocationRepository
    {
        public Location CreateClient(Location location)
        {
            return location;
        }

        public List<Location> GetListClients(string strConnexion)
        {
            var locations = new List<Location>();
            using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from loue", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    locations.Add(new Location()
                    {
                        Id = sqlDataReader.GetInt32(0),
                        IdClient = sqlDataReader.GetInt32(1),
                        IdVehicule = sqlDataReader.GetInt32(2),
                        NbKm = sqlDataReader.GetInt32(3),
                        DateDebut = sqlDataReader.GetDateTime(4),
                        DateFin = sqlDataReader.GetDateTime(5),
                    });
                }
            }

            return locations;
        }
    }
}
