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

            Console.WriteLine("Проверка Запроса 1");
            var result = Queries.Query1Async(2.4, 7, "Русская белая");

            foreach (var item in result)
            {
                Console.WriteLine($" Порода - {item.BreedName},  Вес курицы - {item.ChickenWeight}  Количество яиц -{item.NumberofEggs} ");
            }

            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запроса 2

            Console.WriteLine("Проверка Запроса 2");
            var result1 = Queries.Query2Async("Русская белая");

            Console.WriteLine($"Наибольше количество кур в  цеху {result1.ShopName} ");

            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запроса 3 В каких клетках находятся куры указанного возраста с заданным номером диеты? 

            Console.WriteLine("Проверка Запроса 3");

            var result2 = Queries.Query3Async(15, 2);

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запрос 4 Сколько яиц в день приносят куры, указанного работника

            var result3 = Queries.Query4Async("Шастина");

            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запроса 5 Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур?

            Console.WriteLine("Проверка Запроса 5");
            var result4 = Queries.Query5Async();

            foreach (var item in result4)
            {
                Console.WriteLine($"| {item.Surname, 15} | {item.AverageEggs, 8:f2} | ");
            }

            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запрос 6 В каком цеху курица, от которой получают больше всего яиц
            Console.WriteLine("Проверка Запроса 6 ");

            var result5 = Queries.Query6Async();

            Console.WriteLine($"В цеху {result5.ShopName}  курица номер {result5.ChickenId} со средникм количеством {result5.NumberOfEggs}");

            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запрос 7 Сколько кур каждой породы в каждом цехе?
            Console.WriteLine("Проверка Запрос 7");

            var result6 = Queries.Query7Async();

            foreach (var item in result6)
            {
                Console.WriteLine($"|{item.BreedName, 25} | {item.NumberOfBreed, 3}  | {item.ShopName} ");
            }
            Console.WriteLine("-------------------------------------------------------------------");

            // проверка Запрос 8 Какое количество кур обслуживает каждый работник
            Console.WriteLine("Проверка Запрос 8");

            var result7 = Queries.Query8Async();

            foreach (var item in result7)
            {
                Console.WriteLine($" {item.Surname}  {item.NumberOfChickens}");
            }

            Console.WriteLine("-------------------------------------------------------------------");


            //проверка Запрос 9 Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике?
            Console.WriteLine("Проверка Запроса 9");

            var result8 = Queries.Query9Async();

            foreach (var item in result8)
            {
                Console.WriteLine($" {item.BreedName, 25} | {item.AverageBreedData, 4:f3} | {item.AverageProduction, 4:f3} {item.Difference, 4:f3} ");
            }

            Console.WriteLine("-------------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
