using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AdministratorApplication.Cards
{
    /// <summary>
    /// Interaction logic for ClockControl.xaml
    /// </summary>
    public partial class ClockControl : UserControl
    {
        private Timer timer;
        public ClockControl()
        {
            InitializeComponent();
            InitializeClock();
        }
        private void InitializeClock()
        {
            timer = new Timer(UpdateClock, null, 0, 1000); 
        }

        private void UpdateClock(object state)
        {
            // Actualizează TextBlock-ul cu ora curentă
            Dispatcher.Invoke(() =>
            {
                clock.Text = DateTime.Now.ToString("HH:mm");
            });
        }

    }
}
