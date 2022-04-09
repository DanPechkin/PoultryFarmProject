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
    /// Interaction logic for AssignChickenToCage.xaml
    /// </summary>
    public partial class AssignChickenToCage : Window
    {
        public AssignChickenToCage()
        {
            InitializeComponent();

            DataContext = new AssignChickenToCageViewModel();
        }
    }
}
