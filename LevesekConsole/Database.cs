using MySqlConnector;

namespace LevesekConsole
{
    internal class DB
    {
        static readonly MySqlConnectionStringBuilder connStr = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "leves_feladat"
        };
        public static MySqlConnection Connect { get => new MySqlConnection(connStr.ConnectionString); }
        public static string ReadData(string command)
        {
            string data = string.Empty;
            MySqlConnection conn = Connect;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            conn.Open();
            data = cmd.ExecuteScalar().ToString();
            conn.Close();
            return data;
        }
    }
}
