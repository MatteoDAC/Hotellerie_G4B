using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Reservation
    {
        private float nbReservation;
        private string client;
        private string dateDebutFin;
        private float chambreReserve;

        public Reservation(float nbReservation, string client, string dateDebutFin, float chambreReserve)
        {
            this.nbReservation = nbReservation;
            this.client = client;
            this.dateDebutFin = dateDebutFin;
            this.chambreReserve = chambreReserve;
        }

        public float NbReservation
        {
            get
            {
                return nbReservation;
            }
            set
            {
                nbReservation = value;
            }
        }

        public string Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
            }
        }

        public string DateDebutFin
        {
            get
            {
                return dateDebutFin;
            }
            set
            {
                dateDebutFin = value;
            }
        }
    }
}