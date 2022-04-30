using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;
using WPF_PoultryFarmProject.Views;

namespace WPF_PoultryFarmProject.ViewModels
{
    class RemoveWorkerViewModel
    {
        public ObservableCollection<Worker> Workers { get; set; } = new();
        public Worker SelectedWorker { get; set; }
        public RelayCommand OkButtonCommand { get; }

        public RemoveWorkerViewModel()
        {
            // Обьекты команд должны создаваться самыми первыми в конструкторе
            OkButtonCommand = new RelayCommand(OkButtonClicked);

            FillWorkers();
        }

        public async void FillWorkers()
        {
            await FillWorkersAsync();
        }

        public async Task FillWorkersAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allWorkers = await context.Workers.ToListAsync();

                foreach (var worker in allWorkers)
                {
                    Workers.Add(worker);
                }
            }
        }

        public async void OkButtonClicked()
        {
            await OkButtonClickedAsync();
        }
        public async Task OkButtonClickedAsync()
        {
            await using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Workers.Remove(SelectedWorker);

                // Возьмем все клетки выбранного работника,
                // обязательно включаем информацию о курице в клетке
                var cagesToAssign = await dbContext.Workers
                    .Include(w => w.Cages)
                    .ThenInclude(c => c.Chicken)
                    .Where(w => w.Id == SelectedWorker.Id)
                    .SelectMany(w => w.Cages)
                    .ToListAsync();

                // Возьмем всех работников за исключением выбранного
                var availableWorkers = Workers
                    .Where(w => w.Id != SelectedWorker.Id)
                    .ToList();

                // Создадим форму переназначения клеток оставшимся сотрудникам
                var reAssignChickenForm = new ReAssignChicken(cagesToAssign, availableWorkers);

                // Выведем форму
                var isAccepted = reAssignChickenForm.ShowDialog();
                // Если пользователь нажал "Отмена" - выйдем из метода, не сохраняя изменения в бд
                if (isAccepted == false)
                    return;
                
                // Если пользователь нажал "Ок" сохраним изменения в бд
                await dbContext.SaveChangesAsync();
                // Удалим выбранного работника
                Workers.Remove(SelectedWorker);

            }
        }
    }
}



