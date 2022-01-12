using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Model
{
    public class SupportedCountries
    {
        public string countryCode { get; set; }
        public List<string> regions { get; set; }
        public List<string> holidayTypes { get; set; }
        public string fullName { get; set; }

    }
}
