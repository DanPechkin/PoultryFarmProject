using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryPoultryFarm.Persistence
{
    public class SeedData
    {
        private AppDbContext _context;


        public SeedData(AppDbContext context)
        {
            _context = context;
        }


        public void Fill()
        {
            AddDiets();
            AddBreeds();
            AddChicken();
            AddWorkshop();
            AddWorkers();
            AddCages();
            AddProduction();
        }


        private void AddDiets()
        {
            _context.Database.ExecuteSqlRaw(@"
insert into Diets 
               (Number)
values 
      (1), -- 1
      (2), -- 2
      (3); -- 3
");
        }


        private void AddBreeds()
        {
            _context.Database.ExecuteSqlRaw(@"
insert into Breeds
         (BreedName, AverageEggsNumber, AverageWeight, DietId)
values 
      (N'Русская белая',           16, 1.8,1),  -- 1
      (N'Адлеровская серебристая', 14, 3.5,2),  -- 2
      (N'Загорская лососевая',     13, 2.7,3),  -- 3
      (N'Ереванская красная ',     15, 2.1,2),  -- 4
      (N'Кучинская юбилейная ',    13, 2.7,3),  -- 5
      (N'Пушкинская',              12, 2.5,1),  -- 6
      (N'Первомайская',            11, 2.3,3),  -- 7
      (N'Бресс Гальская',          12, 3.5,2);  -- 8
");
        }

        private void AddChicken()
        {
            _context.Database.ExecuteSqlRaw(@"
insert into Chickens 
         (BreedId,  ChickenWeight, ChickenAgeInMonths)
values 
   (7,3,4),  --1
  (2,2.2,8), --2
  (1,2.4,7), --3
  (4,1.7,15),--4
  (5,2.5,3), --5
  (6,3.3,8), --6
  (8,1.2,1), --7
  (5,1.4,6), --8
  (8,4.7,12),--9
  (2,1.3,21),--10
  (4,3.5,5), --11
  (8,2.6,6), --12
  (5,1.3,12),--13 
  (8,2.4,4), --14
  (2,2.7,22),--15
  (5,4.3,21),--16
  (5,1.5,6), --17
  (7,3.8,21),--18
  (2,1.4,20),--19
  (3,2.4,17),--20
  (3,3.6,9), --21
  (7,2.4,10),--22
  (7,3.7,4), --23
  (7,1.4,11),--24
  (3,2.5,24),--25
  (5,4.7,10),--26
  (2,2.5,9), --27
  (2,4.3,12),--28
  (5,3.8,18),--29
  (6,4.4,15),--30
  (4,2.3,15),--31
  (1,3.1,7), --32
  (7,1.3,20),--33
  (1,4.4,12),--34
  (7,2.3,23),--35
  (7,4.4,11),--36
  (3,4.5,22),--37
  (1,3.3,20),--38
  (5,3.3,9), --39
  (6,2.5,2), --40
  (1,2.3,21),--41
  (2,1.6,5), --42
  (6,2.4,20),--43
  (5,2.7,11),--44 
  (3,2.4,2), --45
  (4,3.8,4), --46
  (6,2.5,6), --47
  (8,4.7,14),--48
  (7,3.4,10),--49
  (5,2.7,17);--50

");
        }

        private void AddWorkshop()
        {
            _context.Database.ExecuteSqlRaw(@"
insert into Workshops
            (ShopName, NumberOfRows, NumberOfCages)
values 
      (N'Мясной', 100, 100 ),    --1
      (N'Мясо-яичные', 100, 100), --2
      (N'Несушки', 100, 100);     --3
");

        }

        private void AddWorkers()
        {
            _context.Database.ExecuteSqlRaw(@"insert into Workers 
          (WorkshopId, Surname, [Name], Patronymic, Passport, Salary)
values 
       (1, N'Елагина',	    N'Ирина',	   N'Всеволодовна',  N'4573 489871',35570), --1
       (2, N'Дубина',	    N'Кира',	   N'Никифоровна',   N'4177 361686',29387), --2
       (3, N'Шастина',	    N'Ася',	       N'Ипполитовна',   N'4194 560450',50670), --3
       (2, N'Борисюка',     N'Елизавета',  N'Сергеевна',     N'4734 139551',22210), --4
       (1, N'Тарасов',	    N'Яков',	   N'Макарович',     N'4214 867745',31645), --5
       (3, N'Сиянова',	    N'Катерина',   N'Вениаминовна',  N'4766 351832',27625), --6
       (2, N'Сиянович',     N'Афанасий',   N'Кузьмич',       N'4640 634826',87521), --7
       (1, N'Янцева',	    N'Анфиса',	   N'Валериановна',  N'4725 525722',44645), --8
       (2, N'Ульянов',	    N'Никита',	   N'Макарович',     N'4223 737618',25089), --9
       (1, N'Луковников',	N'Аркадий',	   N'Тимофеевич',    N'4879 753079',54225), --10
       (3, N'Жаркин',	    N'Кузьма',	   N'Никифорович',   N'4430 508446',21344), --11
       (2, N'Сарайкина',	N'Сюзанна',	   N'Алексеевна',    N'4674 506095',61744), --12
       (1, N'Явчуновский',	N'Трофим',	   N'Ильич',         N'4067 344934',38705), --13
       (2, N'Карасевич',	N'Николай',	   N'Вениаминович',  N'4185 887085',56009), --14
       (3, N'Платущихина',  N'Полина',	   N'Ефимовна',      N'4948 975506',38776), --15
       (2, N'Чернышёв',	    N'Виктор',	   N'Леонтьевич',    N'4786 565324',62024), --16
       (1, N'Кузаева',	    N'Алина',	   N'Вениаминовна',  N'4274 854629',81083), --17
       (3, N'Зворыгин',	    N'Игнат',	   N'Георгиевич',    N'4580 373848',16494), --18
       (1, N'Цур',	        N'Леонтий',    N'Петрович',      N'4930 816218',55522), --19
       (2, N'Сагадиев',	    N'Леонтий',	   N'Петрович',      N'4040 295525',29635), --20
       (3, N'Белоконь',     N'Сюзанна',    N'Севастьяновна', N'4496 105327',59132), --21
       (2, N'Хоботилов',    N'Антон',	   N'Вячеславович',  N'4971 242294',23729), --22
       (1, N'Янкилович',	N'Гавриил',	   N'Евгеньевич',    N'4417 830884',60543), --23
       (3, N'Густокашина',  N'Нонна',      N'Максимовна',    N'4490 825167',30515), --24
       (2, N'Шмагин',	    N'Григорий',   N'Трофимович',    N'4394 124504',71880), --25
       (1, N'Дмитровская',	N'Мила',	   N'Ефимовна',      N'4726 849543',17861), --26
       (3, N'Карандашов',   N'Савва',	   N'Юринович',      N'4575 503159',65344), --27
       (2, N'Кахманова',	N'Иван',	   N'Трофимович',    N'4962 267461',51444), --28
       (1, N'Кондюрина',	N'Марианна',   N'Игнатьевна',    N'4476 172918',50847), --29
       (3, N'Нутрихин',     N'Василий',    N'Алексеевич',    N'4489 913687',61690), --30
       (2, N'Анюкова',	    N'Алена',	   N'Севастьяновна', N'4876 599516',46493), --31
       (1, N'Ясинский',	    N'Емельян',	   N'Сергеевич',     N'4736 741895',31505), --32
       (1, N'Березин',	    N'Тимофей',	   N'Игнатьевич',    N'4520 666849',26518), --33
       (1, N'Живенкова',	N'Антонина',   N'Семеновна',     N'4098 258458',51652), --34
       (2, N'Борцов',	    N'Тимофей',	   N'Петрович',      N'4498 104777',75359), --35
       (3, N'Эрдели',	    N'Валентина',  N'Ефимовна',      N'4514 317146',55084), --36
       (2, N'Яснова',	    N'Галина',	   N'Романовна',     N'4485 479595',31339), --37
       (1, N'Бобра',	    N'Ульяна',	   N'Петровна',      N'4876 270434',65689), --38
       (3, N'Седельников',	N'Роман',	   N'Павлович',      N'4367 424951',38324), --39
       (2, N'Вотяков',	    N'Евгений',	   N'Артемович',     N'4874 135839',72448), --40
       (3, N'Ходяева',	    N'Ульяна',	   N'Герасимовна',   N'4677 248331',80774), --41
       (1, N'Басова',	    N'Зоя',	       N'Прокопьевна',   N'4561 949459',52008), --42
       (2, N'Емельяненко',	N'Лариса',	   N'Севастьяновна', N'4332 226877',76769), --43
       (3, N'Ёлшин',	    N'Федор',	   N'Николаевич',    N'4913 110856',37352), --44
       (1, N'Терентьева',	N'Альбина',	   N'Ильишна',       N'4397 369061',25945), --45
       (2, N'Бубнов',	    N'Дмитрий',	   N'Леонтьевич',    N'4363 182483',21239), --46
       (3, N'Бархотов',	    N'Михаил',	   N'Романович',     N'4348 465884',37507), --47
       (2, N'Яковенцева',	N'Юлиана',	   N'Кузьминовна',   N'4476 962119',67732), --48
       (1, N'Плахтюрин',	N'Кирилл',	   N'Саввеевич',     N'4017 675427',37135); --50      
");
        }

        private void AddCages()
        {
            _context.Database.ExecuteSqlRaw(@"
insert into Cages
         (WorkshopId, ChickenId, WorkerId, RowNumber, CageNumber)
values
  (3,1,30,1,1),
  (2,2,30,1,2),
  (2,3,27,1,3),
  (2,4,34,1,4),
  (2,5,34,1,5),
  (3,6,11,1,6),
  (3,7,2,1,7),
  (2,8,12,1,8),
  (3,9,48,1,9),
  (1,10,43,1,10),
  (3,11,34,2,1),
  (2,12,6,2,2),
  (1,13,21,2,3),
  (2,14,16,2,4),
  (2,15,13,2,5),
  (2,16,47,2,6),
  (2,17,21,2,7),
  (3,18,22,2,8),
  (2,19,7,2,9),
  (2,20,4,2,10),
  (2,21,16,3,1),
  (2,22,33,3,2),
  (2,23,12,3,3),
  (2,24,7,3,4),
  (3,25,42,3,5),
  (1,26,34,3,6),
  (2,27,11,3,7),
  (3,28,10,3,8),
  (2,29,23,3,9),
  (3,30,43,3,10),
  (2,31,12,4,1),
  (3,32,39,4,2),
  (2,33,11,4,3),
  (3,34,47,4,4),
  (2,35,29,4,5),
  (1,36,35,4,6),
  (2,37,16,4,7),
  (3,38,43,4,8),
  (1,39,27,4,9),
  (3,40,13,4,10),
  (1,41,42,5,1),
  (2,42,32,5,2),
  (3,43,43,5,3),
  (2,44,26,5,4),
  (3,45,3,5,5),
  (2,46,3,5,6),
  (2,47,24,5,7),
  (2,48,9,5,8),
  (2,49,45,5,9),
  (3,50,47,5,10);
");
        }

        private void AddProduction()
        {
            _context.Database.ExecuteSqlRaw(@"
SET DATEFORMAT MDY;

insert into Production 
               (ChickenId, Date, NumberOfEggs)
values
       (1,'04/11/2021',8),
       (2,'04/04/2021',6),
       (3,'02/01/2022',8),
       (4,'11/26/2021',9),
       (5,'07/27/2021',2),
       (6,'05/03/2021',1),
       (7,'06/03/2021',7),
       (8,'04/01/2022',4),
       (9,'04/01/2021',5),
       (10,'08/22/2021',4),
       (11,'10/11/2021',2),
       (12,'03/12/2022',4),
       (13,'10/14/2021',8),
       (14,'11/05/2021',5),
       (15,'05/24/2021',4),
       (16,'05/20/2021',3),
       (17,'05/29/2021',5),
       (18,'05/22/2021',10),
       (19,'05/24/2021',5),
       (20,'05/04/2021',3),
       (21,'05/21/2021',8),
       (22,'05/22/2021',10),
       (23,'05/15/2021',3),
       (24,'05/15/2021',6),
       (25,'05/17/2022',7),
       (26,'05/07/2021',9),
       (27,'05/02/2021',3),
       (28,'05/15/2021',10),
       (29,'05/07/2021',10),
       (30,'05/17/2021',5),
       (31,'05/03/2021',2),
       (32,'05/20/2021',8),
       (33,'05/18/2021',6),
       (34,'05/11/2022',7),
       (35,'05/01/2021',6),
       (36,'01/29/2022',10),
       (37,'04/05/2022',1),
       (38,'04/12/2021',3),
       (39,'05/15/2021',3),
       (40,'09/03/2021',1),
       (41,'01/01/2022',6),
       (42,'08/07/2021',8),
       (43,'11/24/2021',5),
       (44,'03/22/2021',8),
       (45,'02/23/2022',3),
       (46,'05/16/2021',8),
       (47,'02/09/2022',8),
       (48,'07/01/2021',7),
       (49,'07/12/2021',3),
       (50,'04/02/2022',8);
  
");
        }  

    }
}
