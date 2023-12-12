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
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            StatusAngajat statusAngajat=new StatusAngajat();

            statusAngajat.FormClosed += StatusAngajat_FormClosed;

            statusAngajat.Show();

            this.Hide();
        }

        private void StatusAngajat_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();   
        }

        private void Meniu_Load(object sender, EventArgs e)
        {

        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
