using Holiday.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Model
{
    public class MonthWiseHolidayModel
    {
        public string Month { get; set; }
        public IEnumerable<HolidayMasterModel> HolidayList { get; set; }
    }

    public class HolidayMasterModel
    {
        

        public DateTime Date { get; set; }
        public string CountryName { get; set; }
        public string HolidayType { get; set; }

        public IEnumerable<HolidayDetailsModel> HolidayDetail { get; set; }
    }

    public class HolidayDetailsModel {
        public string Text { get; set; }
        public string Lang { get; set; }

    }
}
