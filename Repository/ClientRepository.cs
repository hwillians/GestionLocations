using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        public Client CreateClient(Client client, string strConnexion)
        {
            using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO CLIENT(NOM,PRENOM,DATE_NAISSANCE) VALUES(@Nom,@Prenom,@DataNaissance);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", sqlConnection);

                sqlCommand.Parameters.AddWithValue("Nom", client.Nom);
                sqlCommand.Parameters.AddWithValue("Prenom", client.Prenom);
                sqlCommand.Parameters.AddWithValue("DataNaissance", client.DateNaissance.ToString("MM/dd/yyyy"));

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                client.Id = sqlDataReader.GetInt32(0);

            }

            return client;
        }

        public List<Client> GetListClients(string strConnexion)
        {
            var clients = new List<Client>();
            using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Client", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    clients.Add(new Client()
                    {
                        Id = sqlDataReader.GetInt32(0),
                        Nom = sqlDataReader.GetString(1),
                        Prenom = sqlDataReader.GetString(2),
                    });
                }
            }

            return clients;
        }
    }
}
