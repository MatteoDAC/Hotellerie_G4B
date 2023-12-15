using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4bDev_Hôtellerie
{
    public class Personnel
    {

        public int Id { get; set; }
        private string firstName;
        private string lastName;
        private string poste;

        public Personnel(string firstName, string lastName, string poste)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.poste = poste;
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

        public string Poste
        {
            get
            {
                return poste;
            }
            set
            {
                poste = value;
            }
        }

        public void AjoutPersonnel()
        {
            DBconnector.AjoutPersonnel(firstName, lastName, poste);
        }

        public void ModifInfo()
        {
            throw new NotImplementedException();
        }

        public void SuppPersonnel(int id)
        {
            DBconnector.SuppPersonnel(id);
        }
    }
}