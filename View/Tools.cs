using Controllers;
using Models;
using System;
using static System.Console;

namespace View
{
    public static class Tools
    {
        public static void Menu(ClientController clientController, LocationController locationController, string strConnexion)
        {
            int choix = -1;

            WriteLine("*** Ménu Gestion des Locations ***" +
                "\n1.- Ajouter un Client" +
                "\n2.- Afficher la liste des Clients" +
                "\n1.- Ajouter une Location" +
                "\n2.- Afficher la liste des Locations" +
                "\n0.- Sortir");

            while (choix != 0)
            {
                choix = GetIntConsole("\nQuelle action voulez vouz effectuer : ");

                switch (choix)
                {
                    case 1:
                        var newClient = new Client()
                        {
                            Nom = GetStringConsole("Tapez le Nom : "),
                            Prenom = GetStringConsole("Tapez le Prenom : "),
                            DateNaissance = GetDateConsole("Tapez la date de Naissance :"),
                        };

                        WriteLine(clientController.CreateClient(newClient, strConnexion));
                        break;

                    case 2:
                        Write(string.Join("\n", clientController.GetListClient(strConnexion)));
                        break;
                    case 3:
                        WriteLine("Ajouter une Location");
                        break;
                    case 4:
                        Write(string.Join("\n", locationController.GetListClient(strConnexion)));
                        break;

                    case 0: WriteLine("à bientôt..."); break;

                    default: WriteLine("Action non reconnue..."); break;
                }
            }
        }

        public static DateTime GetDateConsole(string message = "Tapez une date : ")
        {
            DateTime date;
            var saisi = GetStringConsole(message);
            while (!DateTime.TryParse(saisi, out date)) saisi = GetStringConsole("La saisie n'est pas valide : ");
            return date;
        }

        public static string GetStringConsole(string messag = "Valeur ")
        {
            Write(messag);
            var s = ReadLine();
            while (String.IsNullOrEmpty(s))
            {
                Write("Le text ne peut pas être vide : ");
                s = ReadLine();
            }
            return s;
        }

        public static double GetDoubleConsole(string messag)
        {
            double valeur;
            while (!double.TryParse(GetStringConsole(messag), out valeur))
                Write("Verifiez votre saisie : ");

            return valeur;
        }

        public static int GetIntConsole(string messag)
        {
            int valeur;
            while (!int.TryParse(GetStringConsole(messag), out valeur))
                Write("Verifiez votre saisie : ");

            return valeur;
        }
    }
}
