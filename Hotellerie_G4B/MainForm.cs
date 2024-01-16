using System;
using System.Windows.Forms;

namespace G4bDev_Hôtellerie
{
    public partial class MainForm : Form
    {
        private Label labelNom;
        private TextBox nomTextBox;
        private Label labelPrenom;
        private TextBox prenomTextBox;
        private Label labelNumeroTel;
        private TextBox numeroTelTextBox;
        private Label labelAdresse;
        private TextBox adresseTextBox;
        private Button enregistrerClientButton;
        private Button ouvrirFormPersonnelButton;
        private Button listeChambresButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            labelNom = new Label();
            nomTextBox = new TextBox();
            labelPrenom = new Label();
            prenomTextBox = new TextBox();
            labelNumeroTel = new Label();
            numeroTelTextBox = new TextBox();
            labelAdresse = new Label();
            adresseTextBox = new TextBox();
            enregistrerClientButton = new Button();
            ouvrirFormPersonnelButton = new Button();
            listeChambresButton = new Button();
            SuspendLayout();
            // 
            // labelNom
            // 
            labelNom.Location = new Point(30, 30);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(80, 20);
            labelNom.TabIndex = 0;
            labelNom.Text = "Nom :";
            // 
            // nomTextBox
            // 
            nomTextBox.Location = new Point(120, 30);
            nomTextBox.Name = "nomTextBox";
            nomTextBox.Size = new Size(200, 23);
            nomTextBox.TabIndex = 1;
            // 
            // labelPrenom
            // 
            labelPrenom.Location = new Point(30, 60);
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Size = new Size(80, 20);
            labelPrenom.TabIndex = 2;
            labelPrenom.Text = "Prénom :";
            // 
            // prenomTextBox
            // 
            prenomTextBox.Location = new Point(120, 60);
            prenomTextBox.Name = "prenomTextBox";
            prenomTextBox.Size = new Size(200, 23);
            prenomTextBox.TabIndex = 3;
            // 
            // labelNumeroTel
            // 
            labelNumeroTel.Location = new Point(30, 90);
            labelNumeroTel.Name = "labelNumeroTel";
            labelNumeroTel.Size = new Size(80, 30);
            labelNumeroTel.TabIndex = 4;
            labelNumeroTel.Text = "Numéro de Téléphone :";
            // 
            // numeroTelTextBox
            // 
            numeroTelTextBox.Location = new Point(120, 90);
            numeroTelTextBox.Name = "numeroTelTextBox";
            numeroTelTextBox.Size = new Size(200, 23);
            numeroTelTextBox.TabIndex = 5;
            // 
            // labelAdresse
            // 
            labelAdresse.Location = new Point(30, 123);
            labelAdresse.Name = "labelAdresse";
            labelAdresse.Size = new Size(80, 20);
            labelAdresse.TabIndex = 6;
            labelAdresse.Text = "Adresse :";
            // 
            // adresseTextBox
            // 
            adresseTextBox.Location = new Point(120, 120);
            adresseTextBox.Name = "adresseTextBox";
            adresseTextBox.Size = new Size(200, 23);
            adresseTextBox.TabIndex = 7;
            // 
            // enregistrerClientButton
            // 
            enregistrerClientButton.Location = new Point(120, 150);
            enregistrerClientButton.Name = "enregistrerClientButton";
            enregistrerClientButton.Size = new Size(150, 30);
            enregistrerClientButton.TabIndex = 8;
            enregistrerClientButton.Text = "Enregistrer Client";
            enregistrerClientButton.Click += enregistrerClientButton_Click;
            // 
            // ouvrirFormPersonnelButton
            // 
            ouvrirFormPersonnelButton.Location = new Point(120, 196);
            ouvrirFormPersonnelButton.Name = "ouvrirFormPersonnelButton";
            ouvrirFormPersonnelButton.Size = new Size(150, 30);
            ouvrirFormPersonnelButton.TabIndex = 9;
            ouvrirFormPersonnelButton.Text = "Ouvrir Personnel";
            ouvrirFormPersonnelButton.Click += OuvrirFormPersonnelButton_Click;
            // 
            // listeChambresButton
            // 
            listeChambresButton.Location = new Point(120, 246);
            listeChambresButton.Name = "listeChambresButton";
            listeChambresButton.Size = new Size(150, 30);
            listeChambresButton.TabIndex = 10;
            listeChambresButton.Text = "Liste des Chambres";
            listeChambresButton.Click += ListeChambresButton_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(379, 300);
            Controls.Add(labelNom);
            Controls.Add(nomTextBox);
            Controls.Add(labelPrenom);
            Controls.Add(prenomTextBox);
            Controls.Add(labelNumeroTel);
            Controls.Add(numeroTelTextBox);
            Controls.Add(labelAdresse);
            Controls.Add(adresseTextBox);
            Controls.Add(enregistrerClientButton);
            Controls.Add(ouvrirFormPersonnelButton);
            Controls.Add(listeChambresButton);
            Name = "MainForm";
            Text = "Enregistrement Client";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void enregistrerClientButton_Click(object sender, EventArgs e)
        {
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;
            string numeroTelephone = numeroTelTextBox.Text;
            string adresse = adresseTextBox.Text;

            Client nouveauClient = new Client(nom, prenom, numeroTelephone, adresse);

            nouveauClient.Enregistrer();

            MessageBox.Show("Nouveau client enregistré avec succès!");
        }


        private void OuvrirFormPersonnelButton_Click(object sender, EventArgs e)
        {
            FormPersonnel formPersonnel = new FormPersonnel();
            formPersonnel.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ListeChambresButton_Click(object sender, EventArgs e)
        {
            FormListeChambres formListeChambres = new FormListeChambres();
            formListeChambres.Show();
        }
    }
}