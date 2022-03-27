using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPoultryFarm.Models
{
    public class Cage
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int CageNumber { get; set; }

        public int WorkshopId { get; set; } // внешний ключ к цеху
        public Workshop Workshop { get; set; } // навигационное свойство к цеху

        public int? ChickenId { get; set; } // внешний ключ к курице
        public Chicken Chicken { get; set; } // навигационное свойство к курице

        public int? WorkerId { get; set; } // внешний ключ к работнику
        public Worker Worker { get; set; } // навигационное свойство к работнику
    }
}
