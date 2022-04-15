using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WPF_PoultryFarmProject.ViewModels
{
    class RemoveChickenViewModel
    {
        public ObservableCollection<Chicken> Chickens { get; set; } = new ObservableCollection<Chicken>();

        public RemoveChickenViewModel()
        {
            FillChickens();
        }

        public async void FillChickens()
        {
            await FillChickensAsync();
        }

        public async Task FillChickensAsync()
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
    }
}
