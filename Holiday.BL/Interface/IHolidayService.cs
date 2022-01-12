using Holiday.Entity.Models;
using Holiday.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL.Interface
{
    public interface IHolidayService
    {
        Task<List<HolidayModel>> GetHolidayList(int year, string countryCode, string holidayType);
        void UpdateHoliday(IEnumerable<HolidayMaster> objModel);

        Task<List<MonthWiseHolidayModel>> GetMonthWiseHoliday(string countryCode, int year);
    }
}
