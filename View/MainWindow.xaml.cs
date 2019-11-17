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
using Wsr1.ViewModel;

namespace Wsr1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserViewModel context;
        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = context = new UserViewModel();
            LoginButton.Click += (s, e) =>
            {
                var user = context.CheckUserByLoginAndPassword(Login.Text, PassWord.Password);
                if (user != null) MessageBox.Show("Yay");
            };
        }
    }
}
