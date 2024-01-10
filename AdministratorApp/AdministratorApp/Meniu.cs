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
        private Size meniuSize;
        //private Point locatieInitiala;

        public Meniu()
        {
            InitializeComponent();



            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            meniuSize = this.Size;

            Angajati angajati = new Angajati();
            //   statusAngajat.Location = locatieInitiala;
            angajati.FormClosed += Meniu_FormClosed;
            angajati.Size = meniuSize;
            angajati.Show();

            this.Hide();
        }

        private void Meniu_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnAdaugaAngajat_Click(object sender, EventArgs e)
        {
            meniuSize = this.Size;

            AdaugareAngajat adaugaAngajat = new AdaugareAngajat();
            //  adaugaAngajat.Location = locatieInitiala;
            adaugaAngajat.FormClosed += Meniu_FormClosed;
            adaugaAngajat.Show();

            this.Hide();
        }
    }
}
