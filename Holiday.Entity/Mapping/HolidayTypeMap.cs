using Holiday.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Entity.Mapping
{
     public class HolidayTypeMap
    {
        public HolidayTypeMap(EntityTypeBuilder<HolidayType> entity)
        {
            entity.ToTable("HolidayType");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            entity.HasData(
                new HolidayType() { Id = 1, Type = "public_holiday", Description = "public holidays" },
new HolidayType() { Id = 2, Type = "observance", Description = "observances not a public holidays" },
new HolidayType() { Id = 3, Type = "school_holiday", Description = "school holidays" },
new HolidayType() { Id = 4, Type = "other_day", Description = "other important days e.g.Mother's day, Father's day etc" },
new HolidayType() { Id = 5, Type = "extra_working_day", Description = "extra working days.This day takes place mostly on Saturday or Sunday and is substituted for extra public holiday" },
new HolidayType() { Id = 6, Type = "postal_holiday", Description = "postal_holiday" });

        }
    }
}
