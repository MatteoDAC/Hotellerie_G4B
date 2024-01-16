using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Reservation
    {
        private string nbReservation;
        private string client;
        private string dateDebutFin;
        private string nbRoom;
        private string firstName;
        private string lastName;

        public Reservation(string nbReservation, string client, string firstName, string lastName, string dateDebutFin, string nbRoom)
        {
            this.nbReservation = nbReservation;
            this.client = client;
            this.dateDebutFin = dateDebutFin;
            this.nbRoom = nbRoom;
            this.nbRoom = firstName;
            this.nbRoom = lastName;
        }

        public string NbReservation
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

        public string NbRoom
        {
            get
            {
                return nbRoom;
            }
            set
            {
                nbRoom = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }


    }
}