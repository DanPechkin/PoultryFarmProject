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
    /// Interaction logic for RemoveChicken.xaml
    /// </summary>
    public partial class RemoveChicken : Window
    {
        public RemoveChicken()
        {
            InitializeComponent();

            DataContext = new RemoveChickenViewModel();
        }

        private void RemoveChicken_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
