using Controllers;
using Models;
using System;
using static System.Console;
using static View.Tools;

namespace View
{
    public static class Menu
    {
        public static void Deployer(ClientController clientController, LocationController locationController)
        {
            int choix = -1;

            WriteLine("*** Ménu Gestion des Locations ***" +
                "\n1.- Ajouter un Client" +
                "\n2.- Afficher la liste des Clients" +
                "\n3.- Afficher un Client" +
                "\n4.- Modifier un Client" +
                "\n5.- Ajouter une Location" +
                "\n6.- Afficher la liste des Locations" +
                "\n0.- Sortir");

            while (choix != 0)
            {
                choix = GetIntConsole("\nQuelle action voulez vouz effectuer : ");

                switch (choix)
                {
                    case 1: OptionAddClient(clientController); break;

                    case 2: Write(string.Join("\n", clientController.GetClients())); break;

                    case 3: OptionGetClientById(clientController); break;

                    case 4: OptionUdpateClient(clientController); break;

                    case 5: OptionCreateLocation(locationController); break;

                    case 6: Write(string.Join("\n", locationController.GetListLocations())); break;

                    case 0: WriteLine("à bientôt..."); break;

                    default: WriteLine("Action non reconnue..."); break;
                }
            }
        }

        private static void OptionCreateLocation(LocationController locationController)
        {
            var location = new Location()
            {
                IdClient = GetIntConsole("Id client : "),
                IdVehicule = GetIntConsole("Id vehicule : "),
                NbKm = GetIntConsole("NbKm"),
                DateDebut = GetDateConsole("Date debut : "),
                DateFin = GetDateConsole("Date fin : ")
            };

            WriteLine(locationController.CreateLocation(location));
        }

        private static void OptionUdpateClient(ClientController clientController)
        {
            int id = GetIntConsole("Tapez l'id du client : ");
            Client client = clientController.GetClientById(id);

            if (client == null) WriteLine("L'id n'existe pas en base");
            else
            {
                String propModif = "";

                while (propModif != "n" && propModif != "p" && propModif != "d" && propModif != "a" && propModif != "c" && propModif != "v" && propModif != "all")
                    propModif = GetStringConsole("Choisissez l'élement à modifier " +
                    "\nn : Nom, p : Prenom, d : Date de Naissance, a : Adresse, c : CodePostal, v : Ville, all : toute les éléments ");

                switch (propModif)
                {
                    case "n": client.Nom = GetStringConsole(client.Nom + " : "); break;
                    case "p": client.Prenom = GetStringConsole(client.Prenom + " : "); break;
                    case "d": client.DateNaissance = GetDateConsole(client.DateNaissance.ToString("dd/MM/yy") + " : "); break;
                    case "a": client.Adresse = GetStringConsole(client.Adresse + " : "); break;
                    case "c": client.CodePostal = GetStringConsole(client.CodePostal + " : "); break;
                    case "v": client.Ville = GetStringConsole(client.Ville + " : "); break;
                    case "all":
                        client = new Client()
                        {
                            Id = client.Id,
                            Nom = GetStringConsole("Nom : "),
                            Prenom = GetStringConsole("Prenom : "),
                            DateNaissance = GetDateConsole("Date Naissance : "),
                            Adresse = GetStringConsole("Adresse : "),
                            CodePostal = GetStringConsole("Code Postal : "),
                            Ville = GetStringConsole("Ville : "),
                        }; break;
                    default: break;
                }

                clientController.UpdateClient(client);
                WriteLine(clientController.GetClientById(id));
            }
        }

        private static void OptionGetClientById(ClientController clientController)
        {
            int id = GetIntConsole("Tapez l'id du client : ");
            Client client = clientController.GetClientById(id);

            if (client == null) WriteLine("L'id n'existe pas en base");
            else WriteLine(client);
        }

        private static void OptionAddClient(ClientController clientController)
        {
            var client = new Client()
            {
                Nom = GetStringConsole("Tapez le Nom : "),
                Prenom = GetStringConsole("Tapez le Prenom : "),
                DateNaissance = GetDateConsole("Tapez la date de Naissance :"),
            };

            WriteLine(clientController.CreateClient(client));
        }
    }
}
