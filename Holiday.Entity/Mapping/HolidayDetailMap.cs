using Holiday.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Entity.Mapping
{
    public class HolidayDetailMap
    {
        public HolidayDetailMap(EntityTypeBuilder<HolidayDetail> entity)
        {
            entity.Property(e => e.Lang)
                   .IsRequired();
            //.HasMaxLength(100);

            entity.Property(e => e.Text)
                .IsRequired();
                //.HasMaxLength(100);

            entity.HasOne(d => d.HolidayMaster)
                .WithMany(p => p.HolidayDetails)
                .HasForeignKey(d => d.HolidayMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Holiday_Details_HolidayMaster");
        }
    }
}
