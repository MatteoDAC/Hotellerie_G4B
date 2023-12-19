using G4bDev_Hôtellerie;
using MySql.Data.MySqlClient;

public class DBconnector
{
    private static string connString = "server=localhost;user=root;database=g4b;port=3306;password=Pa$$w0rd;";

    public static void EnregistrerClient(string firstName, string lastName, string nbTel, string adress)
    {
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "INSERT INTO client (firstName, lastName, nbTel, adress) VALUES (@firstName, @lastName, @nbTel, @adress)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@nbTel", nbTel);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void AjoutPersonnel(string firstName, string lastName, string poste)
    {
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "INSERT INTO personnel (firstName, lastName, poste) VALUES (@firstName, @lastName, @poste)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static List<Personnel> GetListePersonnel()
    {
        List<Personnel> listePersonnel = new List<Personnel>();

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "SELECT * FROM personnel";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Personnel personnel = new Personnel(
                            reader.GetString("firstName"),
                            reader.GetString("lastName"),
                            reader.GetString("poste")
                        );
                        listePersonnel.Add(personnel);
                    }
                }
            }
        }

        return listePersonnel;
    }

    public static void SuppPersonnel(string firstName, string lastName)
    {
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();

            string query = "DELETE FROM personnel WHERE firstName = @firstName AND lastName = @lastName";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static List<Room> GetListeRoom()
    {
        List<Room> listeRoom = new List<Room>();

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "SELECT * FROM room";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room chambre = new Room(
                            reader.GetString("nbRoom"),
                            reader.GetString("type"),
                            reader.GetString("disponibility"),
                            reader.GetString("tarif")
                        );
                        listeRoom.Add(chambre);
                    }
                }
            }
        }

        return listeRoom;
    }

    public static List<Client> GetListeClients()
    {
        List<Client> listeClients = new List<Client>();

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "SELECT * FROM client";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client(
                            reader.GetString("firstName"),
                            reader.GetString("lastName"),
                            reader.GetString("nbTel"),
                            reader.GetString("adress")
                        );
                        listeClients.Add(client);
                    }
                }
            }
        }

        return listeClients;
    }

    public static void EnregistrerReservation(string firstNameClient, string lastNameClient, string nbRoom, string dateDebutFin)
    {
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();

            // Vérifier si la chambre est disponible
            if (IsChambreDisponible(nbRoom))
            {
                // Insérer la réservation
                string query = "INSERT INTO reservation (firstName, lastName, nbRoom, dateDebutFin) VALUES (@firstName, @lastName, @nbRoom, @dateDebutFin)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstNameClient);
                    cmd.Parameters.AddWithValue("@lastName", lastNameClient);
                    cmd.Parameters.AddWithValue("@nbRoom", nbRoom);
                    cmd.Parameters.AddWithValue("@dateDebutFin", dateDebutFin);
                    cmd.ExecuteNonQuery();
                }

                // Mettre à jour la disponibilité de la chambre
                MettreAJourDisponibiliteChambre(nbRoom, "non");
            }
            else
            {
                MessageBox.Show("La chambre sélectionnée n'est pas disponible.");
            }
        }
    }

    private static bool IsChambreDisponible(string nbRoom)
    {
        // Vérifier la disponibilité de la chambre dans la base de données
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "SELECT disponibility FROM room WHERE nbRoom = @nbRoom";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@nbRoom", nbRoom);
                object result = cmd.ExecuteScalar();

                if (result != null && result.ToString() == "oui")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public static void MettreAJourDisponibiliteChambre(string nbRoom, string disponibility)
    {
        // Mettre à jour la disponibilité de la chambre dans la base de données
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();
            string query = "UPDATE room SET disponibility = @disponibility WHERE nbRoom = @nbRoom";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@disponibility", disponibility);
                cmd.Parameters.AddWithValue("@nbRoom", nbRoom);
                cmd.ExecuteNonQuery();
            }
        }
    }
}