using System;
using static System.Console;

namespace View
{
    public static class Tools
    {
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
