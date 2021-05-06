using Controllers;
using Repository;
using Repository.Contracts;
using System;
using System.Data.SqlClient;
using Unity;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {

            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<ClientController, ClientController>();
            unityContainer.RegisterType<IClientRepository, ClientRepository>();
            unityContainer.RegisterType<ILocationRepository, LocationRepository>();
           
           

            var clientController = unityContainer.Resolve<ClientController>();

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

            Tools.Menu(clientController, strConnexion);
        }
    }
}
