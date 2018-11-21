using GolbEngine.Data.Entities;
using GolbEngine.Data.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolbEngine.Data.EntityFramework.Configurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50)
                .IsRequired().HasMaxLength(50).IsUnicode(false);
        }
    }
}
