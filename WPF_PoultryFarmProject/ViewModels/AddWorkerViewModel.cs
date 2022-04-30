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
    class AddWorkerViewModel
    {
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string WorkerPatronymic { get; set; }
        public string Passport { get; set; }
        public string Salary { get; set; }

        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>();

        public Workshop SelectedWorkshop { get; set; }

        public RelayCommand OKButton { get; set; }

        public AddWorkerViewModel()
        {
            OKButton = new RelayCommand(AddWorker, IsWorkerCanExecute);
            FillWorshops();
        }

        public bool IsWorkerCanExecute() =>
            int.TryParse(Salary, out _) &&
            SelectedWorkshop != null;

        public async void AddWorker()
        {
            await AddWorkerAsync();
        }

        public async Task AddWorkerAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var NewWorker = new Worker()
                {
                    Name = WorkerName,
                    Surname = WorkerSurname,
                    Patronymic = WorkerPatronymic,
                    Passport = Passport, 
                    Salary = int.Parse(Salary),
                    Workshop = SelectedWorkshop
                };

                context.Workers.Update(NewWorker);
                await context.SaveChangesAsync();

            }

            MessageBox.Show("Работник успешно добавлен", "Успех!");

        }

        public async void FillWorshops()
        {
            await FillWorshopAsync();
        }

        public async Task FillWorshopAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allworkshops = await context.Workshops.ToListAsync();
                foreach (var item in allworkshops)
                {
                    Workshops.Add(item);   
                }
            }


        }

    }
}
