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
}
