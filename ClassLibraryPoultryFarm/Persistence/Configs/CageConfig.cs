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
    class CageConfig:IEntityTypeConfiguration<Cage>
    {
        public void Configure(EntityTypeBuilder<Cage> builder)
        {
            builder
                .HasOne(cage => cage.Workshop)
                .WithMany(workshop => workshop.Cages)
                .HasForeignKey(cage => cage.WorkshopId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(cage => cage.Chicken)
                .WithOne(chicken => chicken.Cage)
                .HasForeignKey<Cage>(cage => cage.ChickenId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(cage => cage.Worker)
                .WithMany(worker => worker.Cages)
                .HasForeignKey(cage => cage.WorkerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
