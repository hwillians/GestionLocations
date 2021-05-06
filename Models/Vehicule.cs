namespace Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Immatriculation { get; set; }
        public string Modele { get; set; }
        public string Couleur { get; set; }
        public int IdMarque { get; set; }
        public int IdCategorie { get; set; }

        public override string ToString() => $"{Id} - {Immatriculation} {Modele} {Couleur}";
    }
}
