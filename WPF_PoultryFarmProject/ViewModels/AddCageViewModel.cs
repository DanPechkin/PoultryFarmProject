using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;

namespace WPF_PoultryFarmProject.ViewModels
{
    class AddCageViewModel : INotifyPropertyChanged
    {
        private string _validationErrors;
        public string RowNumber { get; set; }
        public string CageNumber { get; set; }
        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>();
        public Workshop SelectedItem { get; set; }
        public RelayCommand OKButton { get; set; }

        public string ValidationErrors
        {
            get => _validationErrors;
            set
            {
                _validationErrors = value;
                OnPropertyChanged();
            }
        }

        public AddCageViewModel()
        {
            OKButton = new RelayCommand(AddCage, AddCageCanExecute);
            FillWorkshops();
        }

        private async void FillWorkshops()
        {
            await FillWorhops();
        }

        private async Task FillWorhops()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var allWorkshops = await context.Workshops.ToListAsync();

                foreach (var workshop in allWorkshops)
                {
                    Workshops.Add(workshop);
                }
            }
        }

        public bool AddCageCanExecute() => 
            int.TryParse(RowNumber, out _) && 
            int.TryParse(CageNumber, out _) &&
            SelectedItem != null;

        public async void AddCage()
        {
            await AddCageAsync();
        }

        public async Task AddCageAsync()
        {
            var isValid = await Validate();
            if (isValid == false)
                return;

            await using (AppDbContext context = new AppDbContext())
            {
                var newCage = new Cage
                {
                    RowNumber = int.Parse(RowNumber),
                    CageNumber = int.Parse(CageNumber),
                    Workshop = SelectedItem
                };
                context.Cages.Update(newCage);
                await context.SaveChangesAsync();
            }
        }

        private async Task<bool> Validate()
        {
            StringBuilder errors = new StringBuilder();
            bool isValid = true;

            bool isCageInRowExists;
            var rowNumber = int.Parse(RowNumber);
            var cageNumber = int.Parse(CageNumber);
            await using (AppDbContext context = new AppDbContext())
            {
                isCageInRowExists = await context.Cages
                    .AnyAsync(c => c.RowNumber == rowNumber &&
                                   c.CageNumber == cageNumber);
            }

            if (isCageInRowExists)
            {
                errors.AppendLine($"Клетка в ряду {RowNumber} с номером {CageNumber} уже существует");
                isValid = false;
            }

            ValidationErrors = errors.ToString();
            return isValid;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
