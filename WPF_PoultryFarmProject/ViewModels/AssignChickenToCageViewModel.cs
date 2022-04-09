using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WPF_PoultryFarmProject.ViewModels
{
    class AssignChickenToCageViewModel
    {
        public ObservableCollection<Chicken> Chickens { get; set; } = new ObservableCollection<Chicken>();
        public ObservableCollection<Cage> Cages { get; set; } = new ObservableCollection<Cage>();


        public AssignChickenToCageViewModel()
        {
            FillChickens();
            FillCages();
        }


        private async void FillChickens()
        {
            await FillChickensAsync();
        }


        private async Task FillChickensAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allChickens = await context.Chickens.ToListAsync();

                foreach (var chicken in allChickens)
                {
                    Chickens.Add(chicken);
                }
            }
        }

        private async void FillCages()
        {
            await FillCagesAsync();
        }

        private async Task FillCagesAsync()
        {
            await using(AppDbContext context = new AppDbContext())
            {
                var allCages = await context.Cages.ToListAsync();
                foreach (var cage in allCages)
                {
                    Cages.Add(cage);
                }
            }
        }
    }
}
