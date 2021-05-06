using System;

namespace Models
{
    public class Location
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdVehicule { get; set; }
        public int NbKm { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - Id client : {1}, Id vehicule : {2}, {3}Km  du {4} au {5}",
                Id, IdClient, IdVehicule, NbKm, DateDebut.ToString("dd/MM/yyyy"), DateFin.ToString("dd/MM/yyyy"));
        }
    }
}
