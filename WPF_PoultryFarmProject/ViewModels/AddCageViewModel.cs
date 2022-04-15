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
    class AddCageViewModel
    {
        public int RowNumber { get; set; }

        public int CageNumber { get; set; }
        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>();

        public AddCageViewModel()
        {
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
    }
}
