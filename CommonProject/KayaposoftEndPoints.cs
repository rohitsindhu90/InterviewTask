using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Common
{
    public static class KayaposoftEndPoints
    {
        private  const string Endpoint = "https://kayaposoft.com/enrico/json/v2.0/?action=";
        public const string GetSupportedCountries = Endpoint+"getSupportedCountries";
        public static string GetHolidaysForYear(int year, string countryCode, string holidayType) => Endpoint + "getHolidaysForYear&year=" + year + "&country=" + countryCode;//+ "&holidayType="+holidayType;

        ////https://kayaposoft.com/enrico/json/v2.0/?action=getHolidaysForYear&year=2022&country=est&holidayType=public_holiday
    }
}
