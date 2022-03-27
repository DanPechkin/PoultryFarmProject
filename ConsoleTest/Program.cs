using System;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm;
using ClassLibraryPoultryFarm.Models;
using ClassLibraryPoultryFarm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // AppDbContext.ReCreate();

            /*
                Eager
                Explicit
                Lazy
            */

            //using (AppDbContext context = new AppDbContext())
            //{
            //    //Diet diet = context.Diets.Single(breed1 => breed1.Id == 2);

            //    // Eager
            //    Diet diet = context.Diets
            //       .Include(diet1 => diet1.Breeds)
            //       .Single(breed1 => breed1.Id == 2);

            //    // Explicit
            //    context
            //        .Entry(diet)
            //        .Collection(diet1 => diet1.Breeds)
            //        .Load();
            //}

            // проверка Запроса 1
            var result = Queries.Query1(2.4, 7, "Русская белая");

            foreach (var item in result)
            {
                Console.WriteLine($" {item.BreedName} {item.ChickenWeight} {item.NumberofEggs} ");
            }

            Console.ReadKey();
        }
    }
}
