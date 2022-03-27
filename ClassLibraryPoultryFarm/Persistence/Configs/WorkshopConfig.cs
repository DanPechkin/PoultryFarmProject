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
    class WorkshopConfig: IEntityTypeConfiguration<Workshop>
    {
        public const int ShopNameMaxLength = 30;
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder
                .Property(worshop => worshop.ShopName)
                .IsRequired()
                .HasMaxLength(ShopNameMaxLength);
        }
    }
}
