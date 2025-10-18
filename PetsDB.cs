namespace Sqlite_Csharp;

using System.Data.SQLite;
class PetsDB
{
    static string connectionDB = "Data Source=pets.db";

    public PetsDB()
    {
        LuoTaulut();
    }
    public void LuoTaulut()
    {
        using (var connection = new SQLiteConnection(connectionDB))
        {
            connection.Open();
            string sqlOmistajat = @"CREATE TABLE IF NOT EXISTS Omistajia (
                id INTEGER PRIMARY KEY,
                nimi TEXT,
                puhelin TEXT
            )";
            string sqlLemmikit = @"CREATE TABLE IF NOT EXISTS Lemmikkeja(
                id INTEGER PRIMARY KEY,
                nimi TEXT,
                laji TEXT,
                omistajan_id INTEGER
            )";
            using var cmd1 = new SQLiteCommand(sqlOmistajat, connection);
            cmd1.ExecuteNonQuery();
            using var cmd2 = new SQLiteCommand(sqlLemmikit, connection);
            cmd2.ExecuteNonQuery();
        }
    }
    public void LisaaOmistaja(int id, string nimi, string puhelin)
    {
        using (var connection = new SQLiteConnection(connectionDB))
        {
            connection.Open();
            string sqlInsert = @"INSERT INTO Omistajia (id, nimi, puhelin) VALUES (@id, @nimi, @puhelin);";
            using var cmdInsert = new SQLiteCommand(sqlInsert, connection);
            cmdInsert.Parameters.AddWithValue("@id", id);
            cmdInsert.Parameters.AddWithValue("@nimi", nimi);
            cmdInsert.Parameters.AddWithValue("@puhelin", puhelin);
            cmdInsert.ExecuteNonQuery();

        }
    }


    public void LisaaLemmikki(int id, string nimi, string laji, int omistajan_id)
    {
        using (var connection = new SQLiteConnection(connectionDB))
        {
            connection.Open();

            string sqlInsert = @"INSERT INTO Lemmikkeja (id, nimi, laji, omistajan_id) VALUES (@id, @nimi, @laji, @omistajan_id);";
            using var cmdInsert = new SQLiteCommand(sqlInsert, connection);
            cmdInsert.Parameters.AddWithValue("@id", id);
            cmdInsert.Parameters.AddWithValue("@nimi", nimi);
            cmdInsert.Parameters.AddWithValue("@laji", laji);
            cmdInsert.Parameters.AddWithValue("@omistajan_id", omistajan_id);
            cmdInsert.ExecuteNonQuery();
        }
    }

    public void PaivitaNumero(int id, string numero)
    {
        using (var connection = new SQLiteConnection(connectionDB))
        {
            connection.Open();
            string sqlUpdate = @"UPDATE Omistajia SET puhelin = @puhelin WHERE id = @id;";
            using var cmdUpdate = new SQLiteCommand(sqlUpdate, connection);
            cmdUpdate.Parameters.AddWithValue("@puhelin", numero);
            cmdUpdate.Parameters.AddWithValue("@id", id);
            cmdUpdate.ExecuteNonQuery();
        }
    }


   public string EtsiNumero(string lemmikkiNimi)
{
    using (var connection = new SQLiteConnection(connectionDB))
    {
        connection.Open();
        string sql = @"SELECT Omistajia.puhelin 
                       FROM Omistajia
                       JOIN Lemmikkeja ON Omistajia.id = Lemmikkeja.omistajan_id
                       WHERE Lemmikkeja.nimi = @lemmikkiNimi;";
        using var cmd = new SQLiteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@lemmikkiNimi", lemmikkiNimi);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return reader.GetString(0);
        }
        else
        {
            return "Lemmikkiä ei löydy";
        }
        }
    }   
} 