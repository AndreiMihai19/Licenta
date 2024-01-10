using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministratorApp
{
    public partial class AdaugareAngajat : Form
    {
        private MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");

        public AdaugareAngajat()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

      

        private void AdaugareAngajat_Load(object sender, EventArgs e)
        {

        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {


            Meniu meniu = new Meniu();
            meniu.FormClosed += AdaugareAngajat_FormClosed;
            meniu.Show();

            this.Hide();
        }

        private void AdaugareAngajat_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); 
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {

            try
            {

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "INSERT INTO Angajati(id,email,parola,nume,prenume,data_nasterii,cnp,functie,ore) VALUES (@id,@email,@parola,@nume,@prenume,@data_nasterii,@cnp,@functie,@ore)";


                    MySqlCommand command = new MySqlCommand(query, connection);
           

                    Random random = new Random();

                    string stridAngajat = new string(Enumerable.Repeat("0123456789", 4).Select(s => s[random.Next(s.Length)]).ToArray());
                    int idAngajat = int.Parse(stridAngajat);

                    DateTime dataNastere = dtpkDataNasterii.Value;
                        string strdataNastere = dataNastere.ToString("yyyy-MM-dd");

                        int[] radioBtn = { 4, 6, 8 };
                        int radioBtnSelected = 0;

                        if (radioBtn4.Checked)
                        {
                            radioBtnSelected = radioBtn[0];
                        }

                        if (radioBtn6.Checked)
                        {
                            radioBtnSelected = radioBtn[1];
                        }

                        if (radioBtn8.Checked)
                        {
                            radioBtnSelected = radioBtn[2];
                        }

                        command.Parameters.AddWithValue("id", idAngajat);
                        command.Parameters.AddWithValue("@email", txtboxEmail.Text);
                        command.Parameters.AddWithValue("@parola", txtboxParola.Text);
                        command.Parameters.AddWithValue("@nume", txtboxNume.Text);
                        command.Parameters.AddWithValue("@prenume", txtboxPrenume.Text);
                        command.Parameters.AddWithValue("@data_nasterii", strdataNastere);
                        command.Parameters.AddWithValue("@cnp", txtboxCNP.Text);
                        command.Parameters.AddWithValue("@functie", cmbFunctie.SelectedItem);
                        command.Parameters.AddWithValue("@ore", radioBtnSelected);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Angajatul {txtboxNume.Text} {txtboxPrenume.Text} a fost adaugat!");

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
