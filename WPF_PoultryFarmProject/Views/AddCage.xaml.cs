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
using WPF_PoultryFarmProject.ViewModels;

namespace WPF_PoultryFarmProject.Views
{
    /// <summary>
    /// Interaction logic for AddCage.xaml
    /// </summary>
    public partial class AddCage : Window
    {
        public AddCage()
        {
            InitializeComponent();

            DataContext = new AddCageViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
