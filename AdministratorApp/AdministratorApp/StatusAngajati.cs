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
    public partial class StatusAngajat : Form
    {
        public StatusAngajat()
        {
            InitializeComponent();
        }

  

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            Meniu meniu = new Meniu();

            meniu.FormClosed += Meniu_FormClosed;

            meniu.Show();

            this.Hide();
        }

        private void Meniu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
