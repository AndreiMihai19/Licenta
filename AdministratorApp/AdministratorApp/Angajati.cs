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
    public partial class Angajati : Form
    {
        private Size statusSize;
        private Point locatieInitiala;
        private TableLayoutPanel tableLayoutPanel;
        public Angajati()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }


        private void btnInapoi_Click(object sender, EventArgs e)
        {
            statusSize = this.Size;

            Meniu meniu = new Meniu();
            meniu.FormClosed += Meniu_FormClosed;
            meniu.Size = statusSize;
            meniu.Show();

            this.Hide();
        }

        private void Meniu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Angajati_Load(object sender, EventArgs e)
        {
            AfiseazaInformatiiAngajat();
            AfiseazaInformatiiAngajat();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AfiseazaInformatiiAngajat()
        {
            // Crează un TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            tableLayoutPanel.AutoSize = true;


            tableLayoutPanel1.Controls.Add(tableLayoutPanel, 1, 3);

            // Creează un nou Panel pentru fiecare informație despre angajat și adaugă-l în TableLayoutPanel
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
            AdaugaPanelInTabel(tableLayoutPanel, "aaa");
        }

        private void AdaugaPanelInTabel(TableLayoutPanel tableLayoutPanel, string titlu)
        {
            // Creează un Panel pentru fiecare pereche titlu-valoare
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Size = new Size(150, 50);

            // Adaugă Label pentru titlu
            Label labelTitlu = new Label();
            labelTitlu.Text = titlu;
            labelTitlu.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            labelTitlu.Dock = DockStyle.Left;
            labelTitlu.ForeColor = Color.Red;
            panel.Controls.Add(labelTitlu);

            // Adaugă panoul în TableLayoutPanel specificând numărul de coloane și rânduri
            tableLayoutPanel.Controls.Add(panel, tableLayoutPanel.ColumnCount - 1, tableLayoutPanel.RowCount - 1);

            // Incrementăm numărul de coloane pentru a adăuga următorul panou pe aceeași linie
            tableLayoutPanel.ColumnCount++;
        }


    }
}
