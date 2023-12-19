namespace G4bDev_Hôtellerie
{
    public partial class FormListeChambres : Form
    {
        private ListBox listeRoomListBox;
        private List<Room> listeRoom;
        private List<Client> listeClients;
        private object roomSelectionnee;

        public FormListeChambres()
        {
            InitializeComponent();
            ChargerListeChambres();
        }

        private void InitializeComponent()
        {
            listeRoomListBox = new ListBox();
            SuspendLayout();
            // 
            // listeRoomListBox
            // 
            listeRoomListBox.FormattingEnabled = true;
            listeRoomListBox.ItemHeight = 15;
            listeRoomListBox.Location = new Point(8, 29);
            listeRoomListBox.Name = "listeRoomListBox";
            listeRoomListBox.Size = new Size(300, 199);
            listeRoomListBox.TabIndex = 0;
            listeRoomListBox.DoubleClick += ListeRoomListBox_DoubleClick;
            // 
            // FormListeChambres
            // 
            ClientSize = new Size(320, 260);
            Controls.Add(listeRoomListBox);
            Name = "FormListeChambres";
            Text = "Liste des Chambres";
            Load += FormListeChambres_Load;
            ResumeLayout(false);
        }

        private void ChargerListeChambres()
        {
            listeRoomListBox.Items.Clear();

            listeRoom = DBconnector.GetListeRoom();

            foreach (var Room in listeRoom)
            {
                listeRoomListBox.Items.Add($"{Room.NbRoom} - {Room.Type} - Disponible : {Room.Disponibility} - Tarif : {Room.Tarif} €");
            }
        }



        private void ListeRoomListBox_DoubleClick(object sender, EventArgs e)
        {
            if (listeRoomListBox.SelectedItem != null)
            {
                int selectedIndex = listeRoomListBox.SelectedIndex;

                Room roomSelectionnee = listeRoom[selectedIndex];

                // Ouvrir la fenêtre pour attribuer la chambre à un client
                FormAttribuerChambre formAttribuerChambre = new FormAttribuerChambre(roomSelectionnee, listeClients);
                DialogResult result = formAttribuerChambre.ShowDialog();
            }
        }

        private void FormListeChambres_Load(object sender, EventArgs e)
        {

        }
    }
}
