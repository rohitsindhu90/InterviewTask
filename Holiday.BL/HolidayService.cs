using Holiday.BL.Interface;
using Holiday.Common;
using Holiday.Entity.Models;
using Holiday.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.BL
{
    public class HolidayService : RepositoryBase<HolidayMaster>, IHolidayService
    {
        public HolidayService(HolidayDBContext context):base(context)
        {

        }

      
        public async Task<List<HolidayModel>> GetHolidayList(int year, string countryCode, string holidayType) {
            string endPoint = KayaposoftEndPoints.GetHolidaysForYear(year,countryCode,holidayType);
            var holidayList = await RestAPICallback.Get<List<HolidayModel>>(endPoint);
            return holidayList;
        }

        public void UpdateHoliday(IEnumerable<HolidayMaster> objModel) {
            AddRange(objModel);
        }

        public async Task<List<MonthWiseHolidayModel>> GetMonthWiseHoliday(string countryCode, int year) {
            List<MonthWiseHolidayModel> model = new List<MonthWiseHolidayModel>();
            var list =_context.HolidayMasters.Include(x=>x.HolidayDetails).Include(x=>x.HolidayType).Include(x=>x.Country).Include(x=>x.HolidayDetails).Where(x => x.Country.Code.ToLower() == countryCode.ToLower() && x.Date.Year==year).AsEnumerable();

            model = list.GroupBy(x => new { month = x.Date.ToString("MMMM"), Year = x.Date.Year }).Select(x => new MonthWiseHolidayModel() {
                Month = x.Key.month + "-" + x.Key.Year,
                HolidayList = x.Select(y => new HolidayMasterModel() {
                    Date = y.Date,
                    CountryName = y.Country.Name,
                   HolidayType=y.HolidayType.Type,
                   HolidayDetail=y.HolidayDetails.Select(h=>new HolidayDetailsModel() { 
                   Lang=h.Lang,
                   Text=h.Text
                   })
                })
            }).ToList();
            return model;
        }
    }
}
