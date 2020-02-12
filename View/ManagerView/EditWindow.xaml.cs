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
using Wsr1.Core;
using Wsr1.Model;

namespace Wsr1.View.ManagerView
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public CoefficientModel CurrentCoeffcientModel { get; set; }
        public EditWindow()
        {
            InitializeComponent();
            DataContext = coeffVM = Singleton<ViewModel.CoefficientViewModel>.Instance();
        }
    }
}
