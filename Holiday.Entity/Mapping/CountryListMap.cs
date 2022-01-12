using Holiday.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Entity.Mapping
{
    public class CountryListMap
    {
        public CountryListMap(EntityTypeBuilder<CountryList> entity)
        {
            entity.ToTable("CountryList");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        }
    }
}
