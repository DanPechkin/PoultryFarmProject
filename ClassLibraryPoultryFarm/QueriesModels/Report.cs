using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;

namespace ClassLibraryPoultryFarm.QueriesModels
{
    public class Report
    {
        public Dictionary<Breed, (int NumberOfChickens, double AverageProduction)> AverageProduction { get; set; } // средняя производительность по каждой породе 

        public int TotalNumberOfChickens { get; set; } // общее количество кур на фабрике

        public int TotalNumberOfEggs { get; set; }    // общее количество яиц за отчетный месяц 

        public Dictionary<Workshop, int> TotalNumberOfWorkers { get; set; }
            
        
    }
}
