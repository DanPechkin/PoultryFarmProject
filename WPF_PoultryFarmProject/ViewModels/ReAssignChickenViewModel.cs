using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;
using WPF_PoultryFarmProject.Infrastructure;

namespace WPF_PoultryFarmProject.ViewModels
{
    class ReAssignChickenViewModel
    {
        public ObservableCollection<Cage> Cages { get; }
        public ObservableCollection<Worker> Workers { get; }

        public Cage SelectedCage { get; set; }
        public Worker SelectedWorker { get; set; }

        public RelayCommand AssignChickenCommand { get; }

        public ReAssignChickenViewModel(ICollection<Cage> cagesToAssign, ICollection<Worker> availableWorkers)
        {
            AssignChickenCommand = new RelayCommand(AssignChicken, IsAssignChickenCanExecute);

            Cages = new ObservableCollection<Cage>(cagesToAssign);
            Workers = new ObservableCollection<Worker>(availableWorkers);
        }

        public bool IsAssignChickenCanExecute() =>
            SelectedCage != null &&
            SelectedWorker != null;


        private void AssignChicken()
        {
            SelectedCage.Worker = SelectedWorker;

            Cages.Remove(SelectedCage);
        }
    }
}
