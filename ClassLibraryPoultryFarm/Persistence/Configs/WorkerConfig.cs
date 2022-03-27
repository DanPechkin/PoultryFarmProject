using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPoultryFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibraryPoultryFarm.Persistence.Configs
{
    class WorkerConfig: IEntityTypeConfiguration<Worker>
    {
        public const int NameLength = 60;
        public const int SurnameLength = 60;
        public const int PatronymicLength = 60;
        public const int PassportLength = 15;
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder
                .Property(worker => worker.Name)
                .IsRequired()
                .HasMaxLength(NameLength);

            builder
                .Property(worker => worker.Surname)
                .IsRequired()
                .HasMaxLength(SurnameLength);

            builder
                .Property(worker => worker.Patronymic)
                .IsRequired()
                .HasMaxLength(PassportLength);

            builder
                .Property(worker => worker.Passport)
                .IsRequired()
                .HasMaxLength(PassportLength);

            builder
                .HasOne(worker => worker.Workshop)
                .WithMany(workshop => workshop.Workers)
                .HasForeignKey(worker => worker.WorkshopId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
