using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfEggs { get; set; }

        public int ChickenId { get; set; }
        public Chicken Chicken { get; set; } 
    }
}
