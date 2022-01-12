using Holiday.BL.Interface;
using Holiday.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL
{
    public class HolidayTypeService: RepositoryBase<HolidayType>, IHolidayTypeService
    {
        public HolidayTypeService(HolidayDBContext context):base(context)
        {

        }

        public async Task<List<HolidayType>> GetHolidayType() {
            var holidayTypeList= await GetAllAsync();
            return holidayTypeList.ToList();
        } 
    }
}
