using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        public Client CreateClient(Client client)
        {
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
