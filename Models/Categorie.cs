namespace Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int PrixKm { get; set; }

        public override string ToString() => $"{Id} {Libelle} {PrixKm} Euro/Km";
    }
}
