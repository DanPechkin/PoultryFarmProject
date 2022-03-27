using ClassLibraryPoultryFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibraryPoultryFarm.Persistence.Configs
{
    class BreedConfig : IEntityTypeConfiguration<Breed>
    {
        public const int BreedNameLength = 60;

        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder
                .Property(breed => breed.BreedName)
                .IsRequired()
                .HasMaxLength(BreedNameLength);

            builder
                .HasOne(breed => breed.Diet)
                .WithMany(diet => diet.Breeds)
                .HasForeignKey(breed => breed.DietId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}