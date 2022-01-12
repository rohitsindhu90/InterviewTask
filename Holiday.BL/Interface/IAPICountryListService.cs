using Holiday.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL.Interface
{
    public interface IAPICountryListService
    {
        //Task<List<SupportedCountries>> FetchCountryList();
        Task<List<string>> UpdateCountry();
    }
}
