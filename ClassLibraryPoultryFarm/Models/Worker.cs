using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Passport { get; set; }
        public int Salary { get; set; }

        public ICollection<Cage> Cages { get; set; } //Inverse Property

        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

    }
}
