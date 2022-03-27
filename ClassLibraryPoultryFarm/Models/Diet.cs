using System;
using System.Collections.Generic;

namespace ClassLibraryPoultryFarm.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public ICollection<Breed> Breeds { get; set; } // навигационное свойство для обратной стороны Inverse property
    }
}
