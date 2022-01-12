using Holiday.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Entity.Mapping
{
    public class HolidayMasterMap
    {
        public HolidayMasterMap(EntityTypeBuilder<HolidayMaster> entity)
        {
            entity.ToTable("HolidayMaster");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.HolidayMasters)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HolidayDateMaster_CountryList");

            entity.HasOne(d => d.HolidayType)
                .WithMany(p => p.HolidayMasters)
                .HasForeignKey(d => d.HolidayTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HolidayDateMaster_HolidayType");

        }
    }
}
