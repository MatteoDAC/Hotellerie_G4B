using G4bDev_Hôtellerie;

public partial class FormDetailsChambre : Form
{
    private Label labelNbChambre;
    private Label labelType;
    private Label labelDisponibilite;
    private Label labelTarif;
    private Button reserverButton;
    private ComboBox listeClientsComboBox;
    private Button boutonAttribuer;
    private ListBox listeChambresListBox;


    private Chambre room;
    private string nbRoom;
    private string disponibility;
    private string firstName;
    private string lastName;


    public FormDetailsChambre(Chambre chambre)
    {
        InitializeComponent();
        this.room = chambre;
        this.nbRoom = chambre.NbRoom;  // Exemple d'attribution de valeur
        this.disponibility = chambre.Disponibility;  // Exemple d'attribution de valeur
                                                     // ... (continuez pour les autres champs)
        AfficherDetailsChambre();
        ChargerListeClients();
    }

    private void InitializeComponent()
    {
        labelNbChambre = new Label();
        labelType = new Label();
        labelDisponibilite = new Label();
        labelTarif = new Label();
        reserverButton = new Button();
        listeClientsComboBox = new ComboBox();
        SuspendLayout();
        // 
        // labelNbChambre
        // 
        labelNbChambre.Location = new Point(0, 0);
        labelNbChambre.Name = "labelNbChambre";
        labelNbChambre.Size = new Size(100, 23);
        labelNbChambre.TabIndex = 0;
        // 
        // labelType
        // 
        labelType.Location = new Point(0, 0);
        labelType.Name = "labelType";
        labelType.Size = new Size(100, 23);
        labelType.TabIndex = 1;
        // 
        // labelDisponibilite
        // 
        labelDisponibilite.Location = new Point(0, 0);
        labelDisponibilite.Name = "labelDisponibilite";
        labelDisponibilite.Size = new Size(100, 23);
        labelDisponibilite.TabIndex = 2;
        // 
        // labelTarif
        // 
        labelTarif.Location = new Point(0, 0);
        labelTarif.Name = "labelTarif";
        labelTarif.Size = new Size(100, 23);
        labelTarif.TabIndex = 0;
        // 
        // reserverButton
        // 
        reserverButton.Location = new Point(0, 0);
        reserverButton.Name = "reserverButton";
        reserverButton.Size = new Size(75, 23);
        reserverButton.TabIndex = 4;
        reserverButton.Click += ReserverButton_Click;
        // 
        // listeClientsComboBox
        // 
        listeClientsComboBox.Location = new Point(187, 1);
        listeClientsComboBox.Name = "listeClientsComboBox";
        listeClientsComboBox.Size = new Size(121, 23);
        listeClientsComboBox.TabIndex = 3;
        // 
        // boutonAttribuer
        // 
        boutonAttribuer = new Button();
        boutonAttribuer.Location = new Point(10, 150); 
        boutonAttribuer.Size = new Size(120, 30); 
        boutonAttribuer.Text = "Attribuer";
        boutonAttribuer.Click += BoutonAttribuer_Click;
        this.Controls.Add(boutonAttribuer);

        // 
        // FormDetailsChambre
        // 
        ClientSize = new Size(320, 260);
        Controls.Add(labelNbChambre);
        Controls.Add(labelType);
        Controls.Add(labelDisponibilite);
        Controls.Add(listeClientsComboBox);
        Controls.Add(reserverButton);
        Name = "FormDetailsChambre";
        Text = "Détails de la Chambre";
        Load += FormDetailsChambre_Load;
        ResumeLayout(false);
    }

    private void AfficherDetailsChambre()
    {

        labelNbChambre.Text = $"Chambre {room.NbRoom}";
        labelType.Text = $"Type: {room.Type}";
        labelDisponibilite.Text = $"Disponibility: {room.Disponibility}";
    }

    private void ChargerListeClients()
    {

        List<Chambre> listeChambres = DBconnector.GetListeChambres();

        // Ajoutez les chambres à la liste de votre ListBox ou autre contrôle
        foreach (Chambre chambre in listeChambres)
        {
            listeChambresListBox.Items.Add($"{room.NbRoom} - {room.Type} - {room.Disponibility} - {room.Tarif}");
        }
    }

    private void ReserverButton_Click(object sender, EventArgs e)
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
            DBconnector.MettreAJourDisponibiliteChambre(room.NbRoom, "non");

            MessageBox.Show($"Chambre {room.NbRoom} attribuée à {clientSelectionne.FirstName} {clientSelectionne.LastName}!");
        }
        else
        {
            MessageBox.Show("Veuillez sélectionner un client pour réserver la chambre.");
        }
    }

    private void FormDetailsChambre_Load(object sender, EventArgs e)
    {

    }

    private void BoutonAttribuer_Click(object sender, EventArgs e)
    {

        DBconnector.AttribuerChambreAUnClient(nbRoom, disponibility, firstName, lastName);

        this.Close();
    }


}
