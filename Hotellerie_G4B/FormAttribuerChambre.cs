using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G4bDev_Hôtellerie
{
    public partial class FormAttribuerChambre : Form
    {
        private Label labelDetailsChambre;
        private ComboBox listeClientsComboBox;
        private Button attribuerChambreButton;
        private Room roomSelectionnee;

        public string FirstNameClient { get; private set; }
        public string LastNameClient { get; private set; }

        public DialogResult DialogResult { get; private set; }

        public FormAttribuerChambre(Room room, List<Client> listeClients)
        {
            InitializeComponent();
            AfficherDetailsChambre(room);
            ChargerListeClients(listeClients);
        }

        public FormAttribuerChambre(Room roomSelectionnee)
        {
            this.roomSelectionnee = roomSelectionnee;
        }

        private void InitializeComponent()
        {
            labelDetailsChambre = new Label();
            listeClientsComboBox = new ComboBox();
            attribuerChambreButton = new Button();

            labelDetailsChambre.Location = new System.Drawing.Point(10, 10);
            labelDetailsChambre.Name = "labelDetailsChambre";
            labelDetailsChambre.Size = new System.Drawing.Size(400, 20);
            labelDetailsChambre.TabIndex = 0;
            labelDetailsChambre.Text = "Détails de la chambre";

            listeClientsComboBox.Location = new System.Drawing.Point(10, 60);
            listeClientsComboBox.Size = new System.Drawing.Size(200, 23);
            listeClientsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            attribuerChambreButton.Location = new System.Drawing.Point(10, 100);
            attribuerChambreButton.Size = new System.Drawing.Size(150, 30);
            attribuerChambreButton.Text = "Attribuer la chambre";
            attribuerChambreButton.Click += AttribuerChambreButton_Click;

            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(labelDetailsChambre);
            this.Controls.Add(listeClientsComboBox);
            this.Controls.Add(attribuerChambreButton);
        }

        private void AfficherDetailsChambre(Room room)
        {
            // Afficher les détails de la chambre
            labelDetailsChambre.Text = $"Détails de la chambre : Chambre {room.NbRoom}, Type : {room.Type}, Disponibilité : {room.Disponibility}, Tarif : {room.Tarif}";
        }

        private void ChargerListeClients(List<Client> listeClients)
        {
            listeClientsComboBox.Items.Clear();

            listeClients = DBconnector.GetListeClients();
            foreach (Client client in listeClients)
            {
                listeClientsComboBox.Items.Add($"{client.FirstName} {client.LastName}");
            }
        }

        private void AttribuerChambreButton_Click(object sender, EventArgs e)
        {
            string selectedClient = listeClientsComboBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedClient))
            {
                string[] clientNames = selectedClient.Split(' ');

                if (clientNames.Length >= 2)
                {
                    FirstNameClient = clientNames[0];
                    LastNameClient = clientNames[1];

                    // Enregistrez la réservation
                    DBconnector.EnregistrerReservation(FirstNameClient, LastNameClient, roomSelectionnee.NbRoom, "DateDebutFin");

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Format de nom de client invalide.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client pour attribuer la chambre.");
            }
        }
    }
}
