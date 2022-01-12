using Holiday.BL.Interface;
using Holiday.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL
{
    public class CountryService : RepositoryBase<CountryList>, ICountryService
    {
        public CountryService(HolidayDBContext context) : base(context)
        {

        }


        public async Task<List<CountryList>> GetCountryList() {
            var model=await GetListAsync(x=>x.Active==true);
            return model.ToList();
        }


    }
}
