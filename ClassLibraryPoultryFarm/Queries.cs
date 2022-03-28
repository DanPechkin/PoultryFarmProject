using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibraryPoultryFarm.Persistence;
using ClassLibraryPoultryFarm.QueriesModels;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryPoultryFarm
{
    public static class Queries
    {
        public static ICollection<Query1> Query1(double weight, int age, string breed)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Production
                    .Include(p => p.Chicken)
                    .ThenInclude(c => c.Breed)
                    .Where(p => Math.Abs(p.Chicken.ChickenWeight - weight) < 0.1 &&
                                p.Chicken.ChickenAge == age &&
                                p.Chicken.Breed.BreedName == breed)
                    .Select(a => new Query1()
                    {
                        BreedName = a.Chicken.Breed.BreedName,
                        ChickenWeight = a.Chicken.ChickenWeight,
                        NumberofEggs = a.NumberOfEggs
                    });

                return result.ToList();
            }
        }

        //Запрос 2. В каком цеху наибольшее количество кур определенной породы? 
        public static Query2 Query2(string breedname)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Cages
                    .Include(c=>c.Chicken)
                    .ThenInclude(b=>b.Breed)
                    .Include(c=>c.Workshop)
                    .Where(cage => cage.Chicken.Breed.BreedName == breedname)
                    .GroupBy(cage => new { cage.Workshop.ShopName, cage.Chicken.Breed.BreedName })
                    .Select(g => new Query2
                    {
                        BreedName = g.Key.BreedName,
                        ShopName = g.Key.ShopName,
                        CountMax = g.Count()
                    })
                    .OrderByDescending(q => q.CountMax)
                    .First();
                return result;
            }
        }
        //Запрос 3. В каких клетках находятся куры указанного возраста с заданным номером диеты?
        public static ICollection<Query3> Query3(int age, int diet)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Cages
                    .Include(c=>c.Chicken)
                    .ThenInclude(c=>c.Breed)
                    .ThenInclude(b=>b.Diet)
                    .Where(c => c.Chicken.ChickenAge == age && c.Chicken.Breed.Diet.Number == diet)
                    .Select(g => new Query3
                    {
                        NumberOfCages = g.Id,
                        ChickenAge = g.Chicken.ChickenAge,
                        DietNumber = g.Chicken.Breed.Diet.Number
                    });

                return result.ToList();
            }
        }

        //Запрос 4. Сколько яиц в день приносят куры, указанного работника
        public static ICollection<Query4> Query4(string surname)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Cages
                    .Include(c=>c.Worker)
                    .Where(p => p.Worker.Surname == surname)
                    .Select(c => new Query4
                    {
                        Surname = c.Worker.Surname,
                        NumberOfEggs = c.Chicken.Production.NumberOfEggs,
                        ChickenId = c.Id
                    });
                return result.ToList();
            }
        }

        //Запрос 5. Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур
        public static ICollection<Query5> Query5()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Cages
                    .Include(c=>c.Worker)
                    .Include(c=>c.Chicken)
                    .ThenInclude(c=>c.Production)
                    .GroupBy(c => c.Worker.Surname, c => c.Chicken.Production)
                    .Select(c => new Query5
                    {
                        AverageEggs = c.Average(a => a.NumberOfEggs),
                        Surname = c.Key
                    });

                return result.ToList();
            }
        }

        //Запрос 6 В каком цеху курица, от которой получают больше всего яиц

        public static Query6 Query6()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Chickens
                    .Include(c => c.Production)
                    .Include(c => c.Cage)
                    .ThenInclude(c => c.Workshop)
                    .Select(c => new Query6
                    {
                        ChickenId = c.Id,
                        ShopName = c.Cage.Workshop.ShopName,
                        NumberOfEggs = c.Production.NumberOfEggs
                    })
                    .OrderByDescending(q => q.NumberOfEggs)
                    .First();
                return result;
            }
        }

        //Запрос 7 Сколько кур каждой породы в каждом цехе? 
        
        public static ICollection<Query7> Query7()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Chickens
                    .Include(c => c.Breed)
                    .Include(c => c.Cage)
                    .ThenInclude(c => c.Workshop)
                    .GroupBy(c => new {c.Breed.BreedName, c.Cage.Workshop.ShopName})
                    .Select(c => new Query7
                    {
                        BreedName = c.Key.BreedName,
                        NumberOfBreed = c.Count(),
                        ShopName = c.Key.ShopName
                    });
                return result.ToList();
            }
        }

        //Запрос 8. Какое количество кур обслуживает каждый работник
        

        public static ICollection<Query8> Query8s()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Chickens
                    .Include(c => c.Cage)
                    .ThenInclude(c => c.Worker)
                    .GroupBy(c => c.Cage.Worker.Surname)
                    .Select(c => new Query8
                    {
                        Surname = c.Key,
                        NumberOfChickens = c.Count()
                    });
                return result.ToList();
            }
        }

        //Запрос 9.Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике?

        public static ICollection<Query9> Query9()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Breeds
                    .Include(b => b.Chickens)
                    .ThenInclude(c => c.Production)
                    .Select(b => new
                    {
                        BreedName = b.BreedName,
                        AverageEggsBreed = b.AverageEggsNumber,
                        AverageProduction = b.Chickens.Average(c => c.Production.NumberOfEggs)
                    })
                    .Select(arg => new Query9
                    {
                        BreedName = arg.BreedName,
                        AverageBreedData = arg.AverageEggsBreed,
                        AverageProduction = arg.AverageProduction,
                        Difference = Math.Abs(arg.AverageEggsBreed - arg.AverageProduction)
                    });

                return result.ToList();
            }
        }
    }
}