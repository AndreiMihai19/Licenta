using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AdministratorApplication.Forms
{
    /// <summary>
    /// Interaction logic for ModifyForm.xaml
    /// </summary>
    public partial class ModifierForm : Window
    {
        int? id;
        string currentJobPosition;
      //  public event EventHandler InfoModified;

        public delegate void UpdateEmployeeListEventHandler(object sender, EventArgs e);

        public event UpdateEmployeeListEventHandler UpdateEmployeeList;

        public ModifierForm(int? id, string jobPosition)
        {
            InitializeComponent();


            foreach (ComboBoxItem item in cmbFunctie.Items)
            {
                if (item.Content.ToString() == jobPosition)
                {
                    cmbFunctie.SelectedItem = item;
                    break; 
                }
            }

            this.id = id;
            currentJobPosition=jobPosition;

        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            IModifier modifierEmployeeInfo = new ModifierRepository();

            string newJobPosition = (cmbFunctie.SelectedItem as ComboBoxItem)?.Content.ToString();

            int[] radioBtn = { 4, 6, 8 };
            int radioBtnSelected = 0;

            if (radioOre1.IsChecked == true)
            {
                radioBtnSelected = radioBtn[0];
            }
            if (radioOre2.IsChecked == true)
            {
                radioBtnSelected = radioBtn[1];
            }
            if (radioOre3.IsChecked == true)
            {
                radioBtnSelected = radioBtn[2];
            }


            switch (modifierEmployeeInfo.ModifyEmployeeInfo(id, currentJobPosition, txtEmail.Text, txtParola.Password, txtTelefon.Text, newJobPosition, radioBtnSelected))
            {
                case ModifierStatus.Success:
                  //  OnDataModified();
                    UpdateEmployeeList?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Modificare reusita!");
                    break;
                case ModifierStatus.Failure:
                    MessageBox.Show("Completati cel putin un camp!");
                    break;
                case ModifierStatus.DataBaseConnectionProblem:
                    MessageBox.Show("Conexiunea la baza de date nu se poate realiza!");
                    break;
                default:
                    break;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
