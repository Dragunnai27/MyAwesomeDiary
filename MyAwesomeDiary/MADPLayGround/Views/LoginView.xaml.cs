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
using System.Windows.Shapes;

namespace MADPLayGround.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            UcSignIn.btnSignUp.Click += (sender, e) =>
            {
                UcSignIn.Visibility = Visibility.Hidden;
                UcSignUp.Visibility = Visibility.Visible;
            };

            UcSignUp.btnSignIn.Click += (sender, e) =>
            {
                UcSignUp.Visibility = Visibility.Hidden;
                UcSignIn.Visibility = Visibility.Visible;
            };
        }
    }
}
