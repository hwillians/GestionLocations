using System;
using System.Data.SqlClient;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string strConnexion = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=SSPI;Initial Catalog=Location";
            try
            {
                using (var sqlConnection = new SqlConnection(strConnexion))
                {
                    sqlConnection.Open();
                    Console.WriteLine("Etat de la connexion:" + sqlConnection.State);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur :" + e.Message);
            }

            Tools.Menu();
        }
    }
}
