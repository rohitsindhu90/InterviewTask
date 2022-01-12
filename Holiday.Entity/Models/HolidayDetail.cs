using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday.Entity.Models
{
    public partial class HolidayDetail
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Lang { get; set; }
        public long HolidayMasterId { get; set; }

        public virtual HolidayMaster HolidayMaster { get; set; }
    }
}
