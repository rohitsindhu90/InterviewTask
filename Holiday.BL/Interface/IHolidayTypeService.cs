using Holiday.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL.Interface
{
    public interface IHolidayTypeService
    {
        Task<List<HolidayType>> GetHolidayType();
    }
}
