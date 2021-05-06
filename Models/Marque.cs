namespace Models
{
    class Marque
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public override string ToString() => $"{Id} - {Nom}";
    }
}
