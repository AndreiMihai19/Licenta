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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdministratorApp
{
    public partial class Autentificare : Form
    {
        private Size autentificareSize;
        //   private string connectionString = "Server=localhost;Database=licenta;User ID=root;Password=ROOT;";
        string connectionString = "Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919";
        public Autentificare()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Autentificare_Load(object sender, EventArgs e)
        {
            this.MaximizeBox= false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Angajati WHERE email = @email AND parola = @parola";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", txtboxEmail.Text);
                    command.Parameters.AddWithValue("@Parola", txtboxParola.Text);

                  //  int count = Convert.ToInt32(command.ExecuteScalar());

                  //  if (count > 0)
                  //  {

                        autentificareSize = this.Size;

                        Meniu meniu = new Meniu();
                        //  statusAngajat.Location = locatieInitiala;
                        meniu.FormClosed += Meniu_FormClosed;
                        meniu.Size = autentificareSize;
                        meniu.Show();

                        this.Hide();
                  //  }
                   // else
                 //   {
                  //      MessageBox.Show("Email sau parola gresita"); 

                 //   }
                }

                connection.Close();
            }
        }

        private void Meniu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void txtboxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
