using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;

namespace WPF_PoultryFarmProject.ViewModels
{
    class AddChickenViewModel
    {
        
        public string ChickenWeight                { get; set; }      // вес курицы
        public string ChickenAgeInMonths              { get; set; }      // возраст курицы в месяцах
        public ObservableCollection<Breed> Breeds { get; set; } = new ObservableCollection<Breed>();    // породы

        public ObservableCollection<Cage> Cages { get; set; } = new ObservableCollection<Cage>(); // клетки

        public Cage SelectedCage { get; set; }

        public Breed SelectedItem { get; set; }
        public RelayCommand OKButton { get; set; }

        

        public AddChickenViewModel()
        {
            OKButton = new RelayCommand(AddChicken, IsChickenCanExecute);
            FillBreeds();
            FillCages();
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

        public async void FillCages()
        {
            await FillCagesAsync();
        }

        public async Task FillCagesAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allcages = await context.Cages
                    .Where(cage => cage.ChickenId == null)
                    .ToListAsync();
                foreach (var item in allcages)
                {
                    Cages.Add(item);
                }
            }
        }

        public bool IsChickenCanExecute() =>
            double.TryParse(ChickenWeight, out _) &&
            int.TryParse(ChickenAgeInMonths, out _) &&
            SelectedItem != null &&
            SelectedCage != null;
        

        
        public async void AddChicken()
        {
            await AddChickenAsync();
        }

        public async Task AddChickenAsync()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var NewChicken = new Chicken()
                {
                    ChickenWeight = double.Parse(ChickenWeight),
                    ChickenAgeInMonths = int.Parse(ChickenAgeInMonths),
                    Breed = SelectedItem,
                    Cage = SelectedCage
                };

                context.Chickens.Update(NewChicken);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Курица успешно добавлена", "Успех!");
        }



        
    }
}
