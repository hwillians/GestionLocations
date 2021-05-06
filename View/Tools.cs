using System;
using static System.Console;

namespace View
{
    public static class Tools
    {
        public static void Menu()
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
                        WriteLine("Afficher un client");
                        break;

                    case 2:
                        ;
                        break;
                    case 3:
                        WriteLine("Ajouter une Location");
                        break;
                    case 4:
                        WriteLine("Afficher la liste des Locations");
                        break;

                    case 0: WriteLine("à bientôt..."); break;

                    default: WriteLine("Action non reconnue..."); break;
                }
            }
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
