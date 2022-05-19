using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Persistence;
using ClassLibraryPoultryFarm.QueriesModels;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryPoultryFarm
{
    public static class Queries
    {
        public static async Task<ICollection<Query1>> Query1Async(double weight, int age, string breed)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var result = context.Production
                    .Include(p => p.Chicken)
                    .ThenInclude(c => c.Breed)
                    .Where(p => Math.Abs(p.Chicken.ChickenWeight - weight) < 0.1 &&
                                p.Chicken.ChickenAgeInMonths == age &&
                                p.Chicken.Breed.BreedName == breed)
                    .Select(a => new Query1()
                    {
                        BreedName = a.Chicken.Breed.BreedName,
                        ChickenWeight = a.Chicken.ChickenWeight,
                        NumberofEggs = a.NumberOfEggs
                    });

                return await result.ToListAsync();
            }
        }

        //Запрос 2. В каком цеху наибольшее количество кур определенной породы? 
        public static async Task <Query2> Query2Async(string breedname)
        {
            await using (AppDbContext context = new AppDbContext())
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
        public static async Task<ICollection<Query3>> Query3Async(int age, int diet)
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var result = context.Cages
                    .Include(c=>c.Chicken)
                    .ThenInclude(c=>c.Breed)
                    .ThenInclude(b=>b.Diet)
                    .Where(c => c.Chicken.ChickenAgeInMonths == age && c.Chicken.Breed.Diet.Number == diet)
                    .Select(g => new Query3
                    {
                        NumberOfCages = g.Id,
                        ChickenAge = g.Chicken.ChickenAgeInMonths,
                        DietNumber = g.Chicken.Breed.Diet.Number
                    });

                return await result.ToListAsync();
            }
        }

        //Запрос 4. Сколько яиц в день приносят куры, указанного работника
        public static async Task<ICollection<Query4>> Query4Async(string surname)
        {
            await using (AppDbContext context = new AppDbContext())
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
                return await result.ToListAsync();
            }
        }

        //Запрос 5. Среднее количество яиц, которое получает в день каждый работник от обслуживаемых им кур
        public  static async Task<ICollection<Query5>> Query5Async()
        {
            await using (AppDbContext context = new AppDbContext())
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

                return await result.ToListAsync();
            }
        }

        //Запрос 6 В каком цеху курица, от которой получают больше всего яиц

        public static async Task<Query6> Query6Async()
        {
            await using (AppDbContext context = new AppDbContext())
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
        
        public static async Task<ICollection<Query7>> Query7Async()
        {
            await using (AppDbContext context = new AppDbContext())
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
                return await result.ToListAsync();
            }
        }

        //Запрос 8. Какое количество кур обслуживает каждый работник
        

        public static async Task<ICollection<Query8>> Query8Async()
        {
            await using (AppDbContext context = new AppDbContext())
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
                return await result.ToListAsync();
            }
        }

        //Запрос 9.Какова для каждой породы разница между показателями породы и средними показателями по птицефабрике?

        public static async Task<ICollection<Query9>> Query9Async()
        {
            await using (AppDbContext context = new AppDbContext())
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

                return await result.ToListAsync();
            }
        }

        //Справка о породе и информации о курах этой породы, имеющихся на фабрике. 

        // Отчет должен включать следующую информацию: количество кур и средняя производительность по каждой породе,
        // общее количество кур на фабрике, общее количество яиц, полученное птицефабрикой за отчетный месяц,
        // общее количество работников и их распределение по цехам.

        public static async Task<Report> MonthlyReport()
        {
            await using (AppDbContext context = new AppDbContext())
            {
                var averageProduction = await context.Breeds
                    .Include(b => b.Chickens)
                    .ThenInclude(c => c.Production)
                    .ToDictionaryAsync(b => b,
                        b => new Tuple<int, double>(b.Chickens.Count, b.Chickens.Average(c => c.Production.NumberOfEggs)));

                var totalchickens = await context.Chickens.CountAsync();

                var now = DateTime.Now;
                var monthAgo = now.AddMonths(-1);

                var numberofeggs = await context.Production
                    .Where(p => p.Date >= monthAgo && p.Date <= now)
                    .SumAsync(a => a.NumberOfEggs);

                var totalworkers = await context.Workshops
                    .Include(w => w.Workers)
                    .ToDictionaryAsync(w => w, wr => wr.Workers.Count);
                return new Report
                {
                    AverageProduction = averageProduction,
                    TotalNumberOfChickens = totalchickens,
                    TotalNumberOfEggs = numberofeggs,
                    TotalNumberOfWorkers = totalworkers
                };
            }
        }
    }
}