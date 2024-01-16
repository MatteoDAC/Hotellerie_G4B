using System;
using System.Windows.Forms;

namespace G4bDev_Hôtellerie
{
    public partial class FormPersonnel : Form
    {
        private Label labelNomPersonnel;
        private TextBox nomPersonnelTextBox;
        private Label labelPrenomPersonnel;
        private TextBox prenomPersonnelTextBox;
        private Label labelPoste;
        private TextBox posteTextBox;
        private Button enregistrerPersonnelButton;
        private Button supprimerPersonnelButton;
        private FormListePersonnel formListePersonnel;

        public FormPersonnel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            labelNomPersonnel = new Label();
            nomPersonnelTextBox = new TextBox();
            labelPrenomPersonnel = new Label();
            prenomPersonnelTextBox = new TextBox();
            labelPoste = new Label();
            posteTextBox = new TextBox();
            enregistrerPersonnelButton = new Button();
            supprimerPersonnelButton = new Button();
            SuspendLayout();
            // 
            // labelNomPersonnel
            // 
            labelNomPersonnel.Location = new Point(10, 10);
            labelNomPersonnel.Name = "labelNomPersonnel";
            labelNomPersonnel.Size = new Size(100, 23);
            labelNomPersonnel.TabIndex = 0;
            labelNomPersonnel.Text = "Nom :";
            // 
            // nomPersonnelTextBox
            // 
            nomPersonnelTextBox.Location = new Point(120, 10);
            nomPersonnelTextBox.Name = "nomPersonnelTextBox";
            nomPersonnelTextBox.Size = new Size(200, 23);
            nomPersonnelTextBox.TabIndex = 1;
            // 
            // labelPrenomPersonnel
            // 
            labelPrenomPersonnel.Location = new Point(10, 40);
            labelPrenomPersonnel.Name = "labelPrenomPersonnel";
            labelPrenomPersonnel.Size = new Size(100, 23);
            labelPrenomPersonnel.TabIndex = 2;
            labelPrenomPersonnel.Text = "Prenom :";
            // 
            // prenomPersonnelTextBox
            // 
            prenomPersonnelTextBox.Location = new Point(120, 40);
            prenomPersonnelTextBox.Name = "prenomPersonnelTextBox";
            prenomPersonnelTextBox.Size = new Size(200, 23);
            prenomPersonnelTextBox.TabIndex = 3;
            // 
            // labelPoste
            // 
            labelPoste.Location = new Point(10, 70);
            labelPoste.Name = "labelPoste";
            labelPoste.Size = new Size(100, 23);
            labelPoste.TabIndex = 4;
            labelPoste.Text = "Poste :";
            // 
            // posteTextBox
            // 
            posteTextBox.Location = new Point(120, 70);
            posteTextBox.Name = "posteTextBox";
            posteTextBox.Size = new Size(200, 23);
            posteTextBox.TabIndex = 5;
            // 
            // enregistrerPersonnelButton
            // 
            enregistrerPersonnelButton.Location = new Point(120, 110);
            enregistrerPersonnelButton.Name = "enregistrerPersonnelButton";
            enregistrerPersonnelButton.Size = new Size(150, 30);
            enregistrerPersonnelButton.TabIndex = 6;
            enregistrerPersonnelButton.Text = "Enregistrer Personnel";
            enregistrerPersonnelButton.Click += enregistrerPersonnelButton_Click;
            // 
            // supprimerPersonnelButton
            // 
            supprimerPersonnelButton.Location = new Point(120, 167);
            supprimerPersonnelButton.Name = "supprimerPersonnelButton";
            supprimerPersonnelButton.Size = new Size(150, 30);
            supprimerPersonnelButton.TabIndex = 6;
            supprimerPersonnelButton.Text = "Supprimer Personnel";
            supprimerPersonnelButton.Click += supprimerPersonnelButton_Click;
            // 
            // FormPersonnel
            // 
            ClientSize = new Size(400, 250);
            Controls.Add(labelNomPersonnel);
            Controls.Add(nomPersonnelTextBox);
            Controls.Add(labelPrenomPersonnel);
            Controls.Add(prenomPersonnelTextBox);
            Controls.Add(labelPoste);
            Controls.Add(posteTextBox);
            Controls.Add(supprimerPersonnelButton);
            Controls.Add(enregistrerPersonnelButton);
            Name = "FormPersonnel";
            Text = "Enregistrement Personnel";
            Load += FormPersonnel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void enregistrerPersonnelButton_Click(object sender, EventArgs e)
        {
            string nomPersonnel = nomPersonnelTextBox.Text;
            string prenomPersonnel = prenomPersonnelTextBox.Text;
            string poste = posteTextBox.Text;

            Personnel nouveauPersonnel = new Personnel(nomPersonnel, prenomPersonnel, poste);

            nouveauPersonnel.AjoutPersonnel();

            MessageBox.Show("Nouveau personnel enregistré avec succès!");
        }

        private void FormPersonnel_Load(object sender, EventArgs e)
        {

        }

        private void supprimerPersonnelButton_Click(object sender, EventArgs e)
        {
            if (formListePersonnel == null)
            {
                formListePersonnel = new FormListePersonnel();
            }

            DialogResult result = formListePersonnel.ShowDialog();

            if (result == DialogResult.OK)
            {
                string firstName = formListePersonnel.FirstNamePersonnelSelectionne;
                string lastName = formListePersonnel.LastNamePersonnelSelectionne;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    DBconnector.SuppPersonnel(firstName, lastName);
                    MessageBox.Show("Personnel supprimé avec succès!");
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un personnel à supprimer.");
                }
            }
        }

    }
}
