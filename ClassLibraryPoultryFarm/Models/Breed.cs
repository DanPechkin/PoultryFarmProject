using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Breed
    {
        public int Id { get; set; }

        public string BreedName { get; set; }
        public int AverageEggsNumber { get; set; }
        public double AverageWeight { get; set; }

        
        public int DietId { get; set; }  // внешний ключ
        public Diet Diet { get; set; }  // навигационное свойство для внешнего ключа

        public ICollection<Chicken> Chickens { get; set; } // Inverse property навигационное свойство обратной стороны
    }
}
