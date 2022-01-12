using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int dayOfWeek { get; set; }
    }

    public class Name
    {
        public string lang { get; set; }
        public string text { get; set; }
    }

    public class HolidayModel
    {
        public Date date { get; set; }
        public List<Name> name { get; set; }
        public string holidayType { get; set; }

        public DateTime _date { get {
                return new DateTime(date.year, date.month, date.day);
            } }
    }


}
