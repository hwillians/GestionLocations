using Models;
using Repository.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class LocationRepository : ILocationRepository
    {
        public Location CreateLocation(Location location, string strConnexion)
        {

            using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO LOUE(ID_CLIENT, ID_VEHICULE, NB_KM, DATE_DEBUT, DATE_FIN)" +
                    "VALUES (@ID_CLIENT, @ID_VEHICULE, @NB_KM, @DATE_DEBUT, @DATE_FIN);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", sqlConnection);

                sqlCommand.Parameters.AddWithValue("ID_CLIENT", location.IdClient);
                sqlCommand.Parameters.AddWithValue("ID_VEHICULE", location.IdVehicule);
                sqlCommand.Parameters.AddWithValue("NB_KM", location.NbKm);
                sqlCommand.Parameters.AddWithValue("DATE_DEBUT", location.DateDebut.ToString("MM/dd/yyyy"));
                sqlCommand.Parameters.AddWithValue("DATE_FIN", location.DateFin.ToString("MM/dd/yyyy"));

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                location.Id = sqlDataReader.GetInt32(0);
            }

            return location;
        }

        public List<Location> GetListLocations(string strConnexion)
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
