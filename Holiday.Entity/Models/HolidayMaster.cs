using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday.Entity.Models
{
    public partial class HolidayMaster
    {
        public HolidayMaster()
        {
            HolidayDetails = new HashSet<HolidayDetail>();
        }

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int CountryId { get; set; }
        public int HolidayTypeId { get; set; }

        public virtual CountryList Country { get; set; }
        public virtual HolidayType HolidayType { get; set; }
        public virtual ICollection<HolidayDetail> HolidayDetails { get; set; }
    }
}
