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
    class ChickenConfig: IEntityTypeConfiguration<Chicken>
    {
        public void Configure(EntityTypeBuilder<Chicken> builder)
        {
            builder
                .HasOne(chicken => chicken.Breed)
                .WithMany(breed => breed.Chickens)
                .HasForeignKey(chicken => chicken.BreedId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
