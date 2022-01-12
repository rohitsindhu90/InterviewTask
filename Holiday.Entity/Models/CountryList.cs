using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Holiday.Entity.Models
{
    public partial class CountryList
    {
        public CountryList()
        {
            HolidayMasters = new HashSet<HolidayMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [JsonIgnore]
        public bool? Active { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<HolidayMaster> HolidayMasters { get; set; }
    }
}
