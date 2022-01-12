using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday.Entity.Models
{
    public partial class HolidayType
    {
        public HolidayType()
        {
            HolidayMasters = new HashSet<HolidayMaster>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public virtual ICollection<HolidayMaster> HolidayMasters { get; set; }
    }
}
