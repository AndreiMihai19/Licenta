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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministratorApplication.Employee_Status
{
    /// <summary>
    /// Interaction logic for TotalHoursCard.xaml
    /// </summary>
    public partial class TotalHoursCard : UserControl
    {
        public TotalHoursCard()
        {
            InitializeComponent();
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TotalHoursCard));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(TotalHoursCard));

        public Color EllipseBackground1
        {
            get { return (Color)GetValue(EllBg1Property); }
            set { SetValue(EllBg1Property, value); }
        }

        public static readonly DependencyProperty EllBg1Property = DependencyProperty.Register("EllipseBackground1", typeof(Color), typeof(TotalHoursCard));

        public Color EllipseBackground2
        {
            get { return (Color)GetValue(EllBg2Property); }
            set { SetValue(EllBg2Property, value); }
        }

        public static readonly DependencyProperty EllBg2Property = DependencyProperty.Register("EllipseBackground2", typeof(Color), typeof(TotalHoursCard));

        public Color Background1
        {
            get { return (Color)GetValue(Bg1Property); }
            set { SetValue(Bg1Property, value); }
        }

        public static readonly DependencyProperty Bg1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(TotalHoursCard));

        public Color Background2
        {
            get { return (Color)GetValue(Bg2Property); }
            set { SetValue(Bg2Property, value); }
        }

        public static readonly DependencyProperty Bg2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(TotalHoursCard));
    }
}
