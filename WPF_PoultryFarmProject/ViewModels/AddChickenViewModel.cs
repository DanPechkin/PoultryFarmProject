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
    class AddChickenViewModel
    {
        public double ChickenWeight                { get; set; }      // вес курицы
        public int ChickenAgeInMonths              { get; set; }      // возраст курицы в месяцах
        public ObservableCollection<Breed> Breeds { get; set; } = new ObservableCollection<Breed>();    // породы

        public AddChickenViewModel()
        {
            FillBreeds();
        }

        public async void FillBreeds()
        {
            await FillBreedsAsync();
        }

        public async Task FillBreedsAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allBreeds = await context.Breeds.ToListAsync();

                foreach (var breed in allBreeds)
                {
                    Breeds.Add(breed);
                }
            }
        }
    }
}
