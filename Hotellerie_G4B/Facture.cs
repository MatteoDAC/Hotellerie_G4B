using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Facture
    {
        private double nbFacture;
        private string? client;
        private string? delaiService;
        private float coutTot;

        public Facture(double nbFacture, string client, string delaiService, float coutTot)
        {
            this.nbFacture = nbFacture;
            this.client = client;
            this.delaiService = delaiService;
            this.coutTot = coutTot;
        }

        public double NbFacture
        {
            get
            {
                return nbFacture;
            }
            set
            {
                nbFacture = value;
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

        public string DelaiService
        {
            get
            {
                return delaiService;
            }
            set
            {
                delaiService = value;
            }

        }

        public float CoutTot
        {
            get
            {
                return coutTot;
            }
            set
            {
                coutTot = value;
            }

        }

        public void GenererFacture()
        {
            throw new NotImplementedException();
        }

    }
}