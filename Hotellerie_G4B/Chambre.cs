using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Chambre
    {
        private string nbRoom;
        private string type;
        private string disponibility;
        private string tarif;

        public Chambre(string nbRoom, string type, string disponibility, string tarif)
        {
            this.nbRoom = nbRoom;
            this.type = type;
            this.disponibility = disponibility;
            this.tarif = tarif;
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

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Disponibility
        {
            get
            {
                return disponibility;
            }
            set
            {
                disponibility = value;
            }
        }

        public string Tarif
        {
            get
            {
                return tarif;
            }
            set
            {
                tarif = value;
            }
        }

        public void VerifDispo()
        {
            throw new NotImplementedException();
        }

        public void Reserver()
        {
            throw new NotImplementedException();
        }

        internal void AttribuerChambre(Client clientSelectionne)
        {
            throw new NotImplementedException();
        }
    }
}