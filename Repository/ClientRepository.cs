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
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO CLIENT (NOM, PRENOM, DATE_NAISSANCE, ADRESSE, CODE_POSTAL, VILLE)" +
                    "VALUES (@NOM, @PRENOM, @DATE_NAISSANCE, @ADRESSE, @CODE_POSTAL, @VILLE)" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", sqlConnection);

                sqlCommand.Parameters.AddWithValue("NOM", client.Nom);
                sqlCommand.Parameters.AddWithValue("PRENOM", client.Prenom);
                sqlCommand.Parameters.AddWithValue("DATE_NAISSANCE", client.DateNaissance.ToString("MM/dd/yyyy"));

                if (client.Adresse != null) sqlCommand.Parameters.AddWithValue("ADRESSE", client.Adresse);
                else sqlCommand.Parameters.AddWithValue("ADRESSE", DBNull.Value);

                if (client.CodePostal != null) sqlCommand.Parameters.AddWithValue("CODE_POSTAL", client.CodePostal);
                else sqlCommand.Parameters.AddWithValue("CODE_POSTAL", DBNull.Value);

                if (client.Ville != null) sqlCommand.Parameters.AddWithValue("VILLE", client.Ville);
                else sqlCommand.Parameters.AddWithValue("VILLE", DBNull.Value);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                client.Id = sqlDataReader.GetInt32(0);

            }
            return client;
        }

        public Client GetClientById(int id, string strConnexion)
        {
            Client client = null;

            using (SqlConnection sqlConnection = new SqlConnection(strConnexion))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Client where ID = @ID", sqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", id);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read()) 
                    client = new Client()
                    {
                        Id = sqlDataReader.GetInt32(0),
                        Nom = sqlDataReader.GetString(1),
                        Prenom = sqlDataReader.GetString(2),
                        DateNaissance = sqlDataReader.GetDateTime(3),
                        Adresse = !sqlDataReader.IsDBNull(4) ? sqlDataReader.GetString(4) : null,
                        CodePostal = !sqlDataReader.IsDBNull(5) ? sqlDataReader.GetString(5) : null,
                        Ville = !sqlDataReader.IsDBNull(6) ? sqlDataReader.GetString(6) : null,
                    };
            }
            return client;
        }

        public List<Client> GetClients(string strConnexion)
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
                        DateNaissance = sqlDataReader.GetDateTime(3),
                        Adresse = !sqlDataReader.IsDBNull(4) ? sqlDataReader.GetString(4) : null,
                        CodePostal = !sqlDataReader.IsDBNull(5) ? sqlDataReader.GetString(5) : null,
                        Ville = !sqlDataReader.IsDBNull(6) ? sqlDataReader.GetString(6) : null,
                    });
                }
            }

            return clients;
        }
    }
}
