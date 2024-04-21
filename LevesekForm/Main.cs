using System;
using MySqlConnector;
using System.Windows.Forms;

namespace LevesekForm
{
    public partial class Main : Form
    {
        MySqlConnectionStringBuilder connStr = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "leves_feladat"
        };
        public Main()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr.ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            decimal kaloria = 0, feherje = 0, zsir = 0, szenhidrat = 0, hamu = 0, rost = 0;
            try
            {
                kaloria = decimal.Parse(this.kaloria.Text);
                feherje = decimal.Parse(this.feherje.Text);
                zsir = decimal.Parse(this.zsir.Text);
                szenhidrat = decimal.Parse(this.szenhidrat.Text);
                hamu = decimal.Parse(this.hamu.Text);
                rost = decimal.Parse(this.rost.Text);
            }
            catch
            {
                new MessageBox("Hibás adatbevitel!").ShowDialog();
                return;
            }
            cmd.CommandText = @"INSERT INTO levesek (megnevezes, kaloria, feherje, zsir, szenhidrat, hamu, rost) VALUES (@megnevezes, @kaloria, @feherje, @zsir, @szenhidrat, @hamu, @rost);";
            cmd.Parameters.Add("@megnevezes", MySqlDbType.VarChar).Value = this.megnevezes.Text;
            cmd.Parameters.Add("@kaloria", MySqlDbType.Int32).Value = kaloria;
            cmd.Parameters.Add("@feherje", MySqlDbType.Decimal).Value = feherje;
            cmd.Parameters.Add("@zsir", MySqlDbType.Decimal).Value = zsir;
            cmd.Parameters.Add("@szenhidrat", MySqlDbType.Decimal).Value = szenhidrat;
            cmd.Parameters.Add("@hamu", MySqlDbType.Decimal).Value = hamu;
            cmd.Parameters.Add("@rost", MySqlDbType.Decimal).Value = rost;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                new MessageBox("Hibás adatbevitel!").ShowDialog();
                conn.Close();
                return;
            }
            conn.Close();
            new MessageBox("Sikeres rögzítés").ShowDialog();
            this.kaloria.Text = null;
            this.feherje.Text = null;
            this.zsir.Text = null;
            this.szenhidrat.Text = null;
            this.hamu.Text = null;
            this.rost.Text = null;
        }
    }
}
