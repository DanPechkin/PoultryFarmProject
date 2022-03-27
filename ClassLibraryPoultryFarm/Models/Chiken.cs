using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Chicken
    {
        public int Id { get; set; }
        public double ChickenWeight { get; set; }
        public int ChickenAge { get; set; }

        public int BreedId { get; set; } // внешний ключ
        public Breed Breed { get; set; } // навигационное свойство

        public Production Production { get; set; } // Inverse свойство

        public Cage Cage { get; set; } // Inverse свойство
    }
}
