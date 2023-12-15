using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G4bDev_Hôtellerie
{
    public partial class FormListePersonnel : Form
    {
        private ListBox listePersonnelListBox;
        private Button supprimerPersonnelSelectionneButton;
        private List<Personnel> listePersonnel;

        public FormListePersonnel(List<Personnel> personnelList)
        {
            InitializeComponent();
            listePersonnel = personnelList;
            RafraichirListePersonnel();
        }

        public int Id { get; internal set; }

        public FormListePersonnel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            listePersonnelListBox = new ListBox();
            listePersonnelListBox.SelectedIndexChanged += ListePersonnelListBox_SelectedIndexChanged;
            supprimerPersonnelSelectionneButton = new Button();

            // Configuration des propriétés de la ListBox
            listePersonnelListBox.FormattingEnabled = true;
            listePersonnelListBox.Location = new System.Drawing.Point(10, 10);
            listePersonnelListBox.Size = new System.Drawing.Size(300, 200);
            listePersonnelListBox.SelectedIndexChanged += ListePersonnelListBox_SelectedIndexChanged;

            // Configuration des propriétés du bouton
            supprimerPersonnelSelectionneButton.Location = new System.Drawing.Point(10, 220);
            supprimerPersonnelSelectionneButton.Size = new System.Drawing.Size(150, 30);
            supprimerPersonnelSelectionneButton.Text = "Supprimer";
            supprimerPersonnelSelectionneButton.Click += SupprimerPersonnelSelectionneButton_Click;

            // Configuration du formulaire
            this.ClientSize = new System.Drawing.Size(320, 260);
            this.Controls.Add(listePersonnelListBox);
            this.Controls.Add(supprimerPersonnelSelectionneButton);
            this.Text = "Liste du Personnel";

            // Écouteur d'événement pour le clic sur le bouton "Supprimer"
            supprimerPersonnelSelectionneButton.Click += SupprimerPersonnelSelectionneButton_Click;

            listePersonnelListBox.SelectedIndexChanged += ListePersonnelListBox_SelectedIndexChanged;

            listePersonnel = DBconnector.GetListePersonnel();
            foreach (Personnel personnel in listePersonnel)
            {
                listePersonnelListBox.Items.Add($"{personnel.FirstName} {personnel.LastName} - {personnel.Poste}");
            }
        }

        private void ListePersonnelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listePersonnelListBox.SelectedIndex >= 0 && listePersonnelListBox.SelectedIndex < listePersonnel.Count)
            {
                Personnel personnelSelectionne = listePersonnel[listePersonnelListBox.SelectedIndex];
            }
        }

        private void SupprimerPersonnelSelectionneButton_Click(object sender, EventArgs e)
        {
            if (listePersonnelListBox.SelectedItem != null)
            {
                int selectedIndex = listePersonnelListBox.SelectedIndex;

                Personnel personnelSelectionne = listePersonnel[selectedIndex];

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un personnel à supprimer.");
            }
        }
        private void RafraichirListePersonnel()
        {
            listePersonnelListBox.Items.Clear();
            foreach (var personnel in listePersonnel)
            {
                listePersonnelListBox.Items.Add($"{personnel.FirstName} {personnel.LastName} - {personnel.Poste}");
            }
        }
    }
}