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
using ClassLibraryPoultryFarm.Models;
using WPF_PoultryFarmProject.ViewModels;

namespace WPF_PoultryFarmProject.Views
{
    /// <summary>
    /// Interaction logic for ReAssignChicken.xaml
    /// </summary>
    public partial class ReAssignChicken : Window
    {
        public ReAssignChicken(ICollection<Cage> cagesToAssign, ICollection<Worker> availableWorkers)
        {
            InitializeComponent();

            DataContext = new ReAssignChickenViewModel(cagesToAssign, availableWorkers);
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
