using G4bDev_Hôtellerie;

public partial class FormListeClients : Form
{
    private ListBox listeClientsListBox;
    private List<Client> listeClients;

    public FormListeClients()
    {
        InitializeComponent();
        ChargerListeClients();
    }

    private void InitializeComponent()
    {
        listeClientsListBox = new ListBox();
        SuspendLayout();
        // 
        // listeClientsListBox
        // 
        listeClientsListBox.ItemHeight = 15;
        listeClientsListBox.Location = new Point(0, 0);
        listeClientsListBox.Name = "listeClientsListBox";
        listeClientsListBox.Size = new Size(120, 94);
        listeClientsListBox.TabIndex = 0;
        listeClientsListBox.DoubleClick += ListeClientsListBox_DoubleClick;
        // 
        // FormListeClients
        // 
        ClientSize = new Size(320, 260);
        Controls.Add(listeClientsListBox);
        Name = "FormListeClients";
        Text = "Liste des Clients";
        Load += FormListeClients_Load;
        ResumeLayout(false);
    }

    private void ChargerListeClients()
    {
        // Charger la liste des clients depuis la base de données
        List<Client> listeClients = DBconnector.GetListeClients();

        // Afficher les clients dans la ListBox
        foreach (Client client in listeClients)
        {
            listeClientsListBox.Items.Add($"{client.FirstName} {client.LastName}");
        }
    }

    private void ListeClientsListBox_DoubleClick(object sender, EventArgs e)
    {
        if (listeClientsListBox.SelectedItem != null)
        {
            int selectedIndex = listeClientsListBox.SelectedIndex;

            Client clientSelectionne = listeClients[selectedIndex];

            MessageBox.Show($"Détails du client {clientSelectionne.FirstName} {clientSelectionne.LastName}");
        }
    }

    private void FormListeClients_Load(object sender, EventArgs e)
    {

    }
}
