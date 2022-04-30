using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;

namespace WPF_PoultryFarmProject.ViewModels
{
    class RemoveChickenViewModel
    {
        public ObservableCollection<Chicken> Chickens { get; set; } = new ObservableCollection<Chicken>();

        public Chicken SelectedChicken { get; set; }

        public RelayCommand OkButton { get; set; }

        public RemoveChickenViewModel()
        {
            OkButton = new RelayCommand(DeleteChicken, IsRemoveChickenCanExecute);
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

        public bool IsRemoveChickenCanExecute() =>
            SelectedChicken != null;

        public async void DeleteChicken()
        {
            await DeleteChickenAsync();
        }

        public async Task DeleteChickenAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                context.Chickens.Remove(SelectedChicken);
                Chickens.Remove(SelectedChicken);

                await context.SaveChangesAsync();
            }

            MessageBox.Show("Курица удалена", "Успех!");
        }
    }
}
