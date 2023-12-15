using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Client
    {
        private string firstName;
        private string lastName;
        private string nbTel;
        private string adress;

        public Client(string firstName, string lastName, string nbTel, string adress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.adress = adress;
            this.nbTel = nbTel;
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

        public string NbTel
        {
            get
            {
                return nbTel;
            }
            set
            {
                nbTel = value;
            }
        }

        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
            }
        }


        public void Enregistrer()
        {
            DBconnector.EnregistrerClient(firstName, lastName, nbTel, adress);
        }

        public void ModifierInformations()
        {
            throw new NotImplementedException();
        }

        public void AnnulerReservation()
        {
            throw new NotImplementedException();
        }
    }
}


