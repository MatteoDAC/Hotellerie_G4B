using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Chambre
    {
        private double nbChambre;
        private string type;
        private bool disponibilite;
        private string tarif;

        public Chambre(double nbChambre, string type, bool disponibilite, string tarif)
        {
            this.nbChambre = nbChambre;
            this.type = type;
            this.disponibilite = disponibilite;
            this.tarif = tarif;
        }
        public double NbChambre
        {
            get
            {
                return nbChambre;
            }
            set
            {
                nbChambre = value;
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

        public bool Disponibilite
        {
            get
            {
                return disponibilite;
            }
            set
            {
                disponibilite = value;
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

    }
}