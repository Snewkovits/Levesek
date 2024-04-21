using System;
using System.Collections.Generic;
using MySqlConnector;

namespace LevesekConsole
{
    internal class Program
    {
        static void Main()
        {
            List<string> levesek = new List<string>();
            MySqlConnection conn = DB.Connect;
            MySqlCommand cmd;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Levesek");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" feladat\n\n");
            Console.Write($"Az adattáblában {DB.ReadData("SELECT COUNT(*) FROM levesek;")} darab leves szerepel.\n" +
                          $"A(z) {DB.ReadData("SELECT megnevezes FROM levesek ORDER BY kaloria DESC;")}-ben van a legtöbb kalória.\n");

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT megnevezes FROM levesek;";
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                levesek.Add(reader["megnevezes"].ToString());
            }
            reader.Close();
            conn.Close();

            Console.Write("Ezekben a levesekben nincs benne a \"leves\" szó:");
            foreach (string leves in levesek)
            {
                if (!leves.Contains("leves"))
                {
                    Console.WriteLine($" {leves}");
                }
            }
            Console.ReadKey(true);
        }
    }
}
