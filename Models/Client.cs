using System;

namespace Models
{
    public class Client
    {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} ({3}), {4} {5} - {6}",
                Id, Nom, Prenom, DateNaissance.ToString("dd/MM/yy"), Adresse, CodePostal, Ville);
        }
    }
}
