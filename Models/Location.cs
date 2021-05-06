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
            return $"ID : {Id} ID_CLIENT : {IdClient}  ID_VEHICULE : {IdVehicule} NB_KM {NbKm} DATE_DEBUT {DateDebut} DATE_FIN {DateFin}";
        }
    }
}
