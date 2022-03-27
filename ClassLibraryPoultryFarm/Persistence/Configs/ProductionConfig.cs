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
    class ProductionConfig :IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder
                .HasOne(production => production.Chicken)
                .WithOne(chicken => chicken.Production)
                .HasForeignKey<Production>(production => production.ChickenId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
