using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Workshop
    {
        public int Id { get; set; }

        public string ShopName { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfCages { get; set; }

        public ICollection<Cage> Cages { get; set; } // Inverse Property к клеткам 

        public ICollection<Worker> Workers { get; set; } //Inverse Property к работнику 
    }
}
