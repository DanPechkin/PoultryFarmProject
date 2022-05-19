using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ClassLibraryPoultryFarm;
using ClassLibraryPoultryFarm.QueriesModels;
using WPF_PoultryFarmProject.Annotations;

namespace WPF_PoultryFarmProject.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Report _monthlyReport;
        public ObservableCollection<Query1> Query1 { get; set; } = new(); // Запрос 1 
        public ObservableCollection<Query2> Query2 { get; set; } = new(); // Запрос 2
        public ObservableCollection<Query3> Query3 { get; set; } = new(); // Запрос 3
        public ObservableCollection<Query4> Query4 { get; set; } = new(); // Запрос 4 
        public ObservableCollection<Query5> Query5 { get; set; } = new(); // Запрос 5 
        public ObservableCollection<Query6> Query6 { get; set; } = new(); // Запрос 6
        public ObservableCollection<Query7> Query7 { get; set; } = new(); // Запрос 7
        public ObservableCollection<Query8> Query8 { get; set; } = new(); // Запрос 8 
        public ObservableCollection<Query9> Query9 { get; set; } = new(); // Запрос 9 

        public Report MonthlyReport
        {
            get => _monthlyReport;
            set
            {
                _monthlyReport = value;
                OnPropertyChanged();
            }
        } // Отчет

        public MainWindow()
        {
            InitializeComponent();

        }

        // Запрос 1
        private async void Query1_OnClick(object sender, RoutedEventArgs e)
        {
            await Query1Async();
        }

        private async Task Query1Async()
        {
            Query1Tab.IsSelected = true;

            var result = await Queries.Query1Async(2.4, 7, "Русская белая");
            Query1.Clear();
            foreach (var item in result)
            {
                Query1.Add(item);
            }
        }

        // Запрос 2
        private async void Query2_ClickOn(object sender, RoutedEventArgs e)
        {
            await Query2Async();
        }

        private async Task Query2Async()
        {
            Query2Tab.IsSelected = true;

            var result = await Queries.Query2Async("Русская белая");
            Query2.Clear();
            Query2.Add(result);

        }

        // Запрос 3
        private async void Query3_OnClick(object sender, RoutedEventArgs e)
        {
            await Query3Async();
        }

        private async Task Query3Async()
        {
            Query3Tab.IsSelected = true;

            var result = await Queries.Query3Async(15, 2);
            Query3.Clear();
            foreach (var item in result)
            {
                Query3.Add(item);
            }
        }

        // Запрос 4 

        private async void Query4_OnClick(object sender, RoutedEventArgs e)
        {
            await Query4Async();
        }

        private async Task Query4Async()
        {
            Query4Tab.IsSelected = true;

            var result = await Queries.Query4Async("Шастина");
            Query4.Clear();
            foreach (var item in result)
            {
                Query4.Add(item);
            }
        }

        //Запрос 5

        private async void Query5_OnClick(object sender, RoutedEventArgs e)
        {
            await Query5Async();
        }

        private async Task Query5Async()
        {
            Query5Tab.IsSelected = true;
            var result = await Queries.Query5Async();
            Query5.Clear();
            foreach (var item in result)
            {
                Query5.Add(item);
            }
        }

        //Запрос 6 

        private async void Query6_OnClick(object sender, RoutedEventArgs e)
        {
            await Query6Async();
        }

        private async Task Query6Async()
        {
            Query6Tab.IsSelected = true;
            var result = await Queries.Query6Async();
            Query6.Clear();
            Query6.Add(result);

        }

        //Запрос 7 
        private async void Query7_OnClick(object sender, RoutedEventArgs e)
        {
            await Query7Async();
        }

        private async Task Query7Async()
        {
            Query7Tab.IsSelected = true;

            var result = await Queries.Query7Async();
            Query7.Clear();
            foreach (var item in result)
            {
                Query7.Add(item);
            }
        }

        // Запрос 8 
        private async void Query8_OnClick(object sender, RoutedEventArgs e)
        {
            await Query8Async();
        }

        private async Task Query8Async()
        {
            Query8Tab.IsSelected = true;
            var result = await Queries.Query8Async();
            Query8.Clear();
            foreach (var item in result)
            {
                Query8.Add(item);
            }
        }

        //Запрос 9 
        private async void Query9_OnClick(object sender, RoutedEventArgs e)
        {
            await Query9Async();
        }

        private async Task Query9Async()
        {
            Query9Tab.IsSelected = true;
            var result = await Queries.Query9Async();
            Query9.Clear();
            foreach (var item in result)
            {
                Query9.Add(item);
            }
        }

        // Отчет 

        private async void Report_OnClick(object sender, RoutedEventArgs e)
        {
            await ReportAsync();
        }

        private async Task ReportAsync()
        {
            ReportTab.IsSelected = true;
            var result = await Queries.MonthlyReport();
            MonthlyReport = result;
        }


        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            AddCage addcage = new AddCage();
            addcage.Show();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            AddChicken addchiken = new AddChicken();
            addchiken.Show();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            AddWorker addworker = new AddWorker();
            addworker.Show();
        }


        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            AssignWorkerToCage assignchicken = new AssignWorkerToCage();
            assignchicken.Show();
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            RemoveChicken removechicken = new RemoveChicken();
            removechicken.Show();
        }

        private void Button6_OnClick(object sender, RoutedEventArgs e)
        {
            RemoveWorker removeworker = new RemoveWorker();
            removeworker.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void On_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
