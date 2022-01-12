using System;
using Holiday.Entity.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Holiday.Entity.Models
{
    public partial class HolidayDBContext : DbContext
    {
        public HolidayDBContext()
        {
        }

        public HolidayDBContext(DbContextOptions<HolidayDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountryList> CountryLists { get; set; }
        public virtual DbSet<HolidayDetail> HolidayDetails { get; set; }
        public virtual DbSet<HolidayMaster> HolidayMasters { get; set; }
        public virtual DbSet<HolidayType> HolidayTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.EnableDetailedErrors(true);
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=ROHIT-HP;Database=HolidayDB;User Id=Puser;Password=Demo@2022");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            new CountryListMap(modelBuilder.Entity<CountryList>());
            new HolidayDetailMap(modelBuilder.Entity<HolidayDetail>());
            new HolidayMasterMap(modelBuilder.Entity<HolidayMaster>());
            new HolidayTypeMap(modelBuilder.Entity<HolidayType>());
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
