using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G4bDev_Hôtellerie
{
    public partial class FormListeChambres : Form
    {
        private ListBox listeChambresListBox;
        private List<Chambre> listeChambres;

        public FormListeChambres()
        {
            InitializeComponent();
            ChargerListeChambres();
        }

        private void InitializeComponent()
        {
            listeChambresListBox = new ListBox();
            SuspendLayout();
            // 
            // listeChambresListBox
            // 
            listeChambresListBox.FormattingEnabled = true;
            listeChambresListBox.ItemHeight = 15;
            listeChambresListBox.Location = new Point(8, 34);
            listeChambresListBox.Name = "listeChambresListBox";
            listeChambresListBox.Size = new Size(300, 199);
            listeChambresListBox.TabIndex = 0;
            listeChambresListBox.DoubleClick += ListeChambresListBox_DoubleClick;
            // 
            // FormListeChambres
            // 
            ClientSize = new Size(320, 260);
            Controls.Add(listeChambresListBox);
            Name = "FormListeChambres";
            Text = "Liste des Chambres";
            ResumeLayout(false);
        }

        private void ChargerListeChambres()
        {
            listeChambresListBox.Items.Clear(); 

            listeChambres = DBconnector.GetListeChambres();

            foreach (var chambre in listeChambres)
            {
                listeChambresListBox.Items.Add($"{chambre.NbRoom} - {chambre.Type} - Disponible : {chambre.Disponibility} - Tarif : {chambre.Tarif} €");
            }
        }

       

        private void ListeChambresListBox_DoubleClick(object sender, EventArgs e)
        {
            if (listeChambresListBox.SelectedItem != null)
            {
                // Récupérer l'index de l'élément sélectionné
                int selectedIndex = listeChambresListBox.SelectedIndex;

                // Récupérer l'objet Chambre correspondant à l'index sélectionné
                Chambre chambreSelectionnee = listeChambres[selectedIndex];

                // Ouvrir la fenêtre des détails de la chambre
                FormDetailsChambre formDetailsChambre = new FormDetailsChambre(chambreSelectionnee);
                formDetailsChambre.ShowDialog();

                // Rafraîchir la liste des chambres après la mise à jour (si nécessaire)
                ChargerListeChambres();
            }
        }
    }
}
