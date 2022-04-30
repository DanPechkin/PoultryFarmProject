using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;

namespace WPF_PoultryFarmProject.ViewModels
{
    class AssignWorkerToCageViewModel
    {
        
        public ObservableCollection<Cage> Cages { get; set; } = new ObservableCollection<Cage>();

        public ObservableCollection<Worker> Workers { get; set; } = new ObservableCollection<Worker>();

        

        public Cage SelectedItemсCage { get; set; }

        public Worker SelectedWorker { get; set; }

        public RelayCommand OKButton { get; set; }



        public AssignWorkerToCageViewModel()
        {
            OKButton = new RelayCommand(AddAssignedWorker, IsAssignWorkerCanExecute);
            
            FillCages();
            FillWorkers();
        }

        public async void AddAssignedWorker()
        {
            await AddAssignedWorkerAsync();
        }

        public async Task AddAssignedWorkerAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                
                SelectedItemсCage.Worker = SelectedWorker;
                
                context.Update(SelectedItemсCage);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Клетка назначена сотруднику", "Успех!");
        }

        public bool IsAssignWorkerCanExecute() =>
            SelectedItemсCage != null &&
            SelectedWorker != null;

       

        private async void FillCages()
        {
            await FillCagesAsync();
        }

        private async Task FillCagesAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allCages = await context.Cages.ToListAsync();
                foreach (var cage in allCages)
                {
                    Cages.Add(cage);
                }
            }
        }

        public async void FillWorkers()
        {
            await FillWorkersAsync();
        }

        private async Task FillWorkersAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allWorkers = await context.Workers.ToListAsync();

                foreach (var item in allWorkers)
                {
                    Workers.Add(item);
                }
            }
        }
    }
}
