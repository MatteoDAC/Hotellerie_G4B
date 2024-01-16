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
        private room roomSelectionnee;

        public string FirstNameClient { get; private set; }
        public string LastNameClient { get; private set; }


        public FormAttribuerChambre(room room, List<Client> listeClients)
        {
            InitializeComponent();
            AfficherDetailsChambre(room);
            ChargerListeClients(listeClients);
        }

        public FormAttribuerChambre(room roomSelectionnee)
        {
            this.roomSelectionnee = roomSelectionnee;
        }

        private void InitializeComponent()
        {
            labelDetailsChambre = new Label();
            listeClientsComboBox = new ComboBox();
            attribuerChambreButton = new Button();
            SuspendLayout();
            // 
            // labelDetailsChambre
            // 
            labelDetailsChambre.Location = new Point(10, 10);
            labelDetailsChambre.Name = "labelDetailsChambre";
            labelDetailsChambre.Size = new Size(400, 20);
            labelDetailsChambre.TabIndex = 0;
            labelDetailsChambre.Text = "Détails de la chambre";
            // 
            // listeClientsComboBox
            // 
            listeClientsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            listeClientsComboBox.Location = new Point(10, 60);
            listeClientsComboBox.Name = "listeClientsComboBox";
            listeClientsComboBox.Size = new Size(200, 23);
            listeClientsComboBox.TabIndex = 1;
            listeClientsComboBox.SelectedIndexChanged += listeClientsComboBox_SelectedIndexChanged;
            // 
            // attribuerChambreButton
            // 
            attribuerChambreButton.Location = new Point(10, 100);
            attribuerChambreButton.Name = "attribuerChambreButton";
            attribuerChambreButton.Size = new Size(150, 30);
            attribuerChambreButton.TabIndex = 2;
            attribuerChambreButton.Text = "Attribuer la chambre";
            attribuerChambreButton.Click += AttribuerChambreButton_Click;
            // 
            // FormAttribuerChambre
            // 
            ClientSize = new Size(400, 150);
            Controls.Add(labelDetailsChambre);
            Controls.Add(listeClientsComboBox);
            Controls.Add(attribuerChambreButton);
            Name = "FormAttribuerChambre";
            ResumeLayout(false);
        }

        private void AttribuerChambreButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AfficherDetailsChambre(room room)
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

        private void AttribuerChambreButton_Click(object sender, EventArgs e, room room)
        {
            if (listeClientsComboBox.SelectedItem != null)
            {
                // Récupérer l'index du client sélectionné
                int selectedIndex = listeClientsComboBox.SelectedIndex;

                // Récupérer l'objet Client correspondant à l'index sélectionné
                Client clientSelectionne = DBconnector.GetListeClients()[selectedIndex];

                // Mettre à jour la chambre avec les informations du client
                room.AttribuerChambre(clientSelectionne);

                // Mettre à jour la disponibilité dans la base de données
                DBconnector.MettreAJourDisponibiliteChambre(nbRoom: room.NbRoom, "non");

                // Créer la réservation dans la base de données
                DBconnector.EnregistrerReservation(room.NbRoom, clientSelectionne.FirstName, clientSelectionne.LastName);

                MessageBox.Show($"Chambre {room.NbRoom} attribuée à {clientSelectionne.FirstName} {clientSelectionne.LastName}!");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client pour réserver la chambre.");
            }
        }

        private void listeClientsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
