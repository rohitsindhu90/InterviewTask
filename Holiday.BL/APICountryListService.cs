using Holiday.BL.Interface;
using Holiday.Common;
using Holiday.Entity.Models;
using Holiday.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Holiday.BL
{
    public class APICountryListService : RepositoryBase<CountryList>,IAPICountryListService
    {
        private IHolidayService _holidayService;
        private IHolidayTypeService _holidayTypeService;
        public APICountryListService(HolidayDBContext context,IHolidayService holidayService,IHolidayTypeService holidayTypeService):base(context)
        {
            _holidayService = holidayService;
            _holidayTypeService = holidayTypeService;
        }
        public async Task<List<SupportedCountries>> FetchCountryList() {
            string endPoint = KayaposoftEndPoints.GetSupportedCountries;
            var countryList = await RestAPICallback.Get<List<SupportedCountries>>(endPoint);
            return countryList;
        }

        public async Task<List<string>> UpdateCountry() {
            List<SupportedCountries> countryList = await FetchCountryList();
            List<CountryList> finalList = countryList.Select(x => 
                new CountryList()
                {
                    Name = x.fullName,
                    Code = x.countryCode
                }
            ).ToList();

            //Fetching Exiting Data from DB
            var listQuery= await GetSupportedCountryList();
            var list = listQuery.Select(x => x.Code).ToList();
            if (list.Count() > 0) {
                finalList= finalList.Where(x=>!list.Contains(x.Code)).ToList();
            }
            if (countryList.Count() > 0) {
                await _context.AddRangeAsync(finalList);
                await _context.SaveChangesAsync();
            }
            bool isUpdateRequired = false;
            List<string> exception = new List<string>();
            var dbCountry = await GetSupportedCountryList();
            var holidayTypeList = await _holidayTypeService.GetHolidayType();
            dbCountry.ForEach(async x =>
            {
                int currentYear = DateTime.Now.Year;
                bool isCurrentYearDataExist=x.HolidayMasters.Any(x => x.Date.Year == currentYear);
                if (!isCurrentYearDataExist)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        var holidayList = await _holidayService.GetHolidayList(currentYear, x.Code, string.Empty);
                        holidayList.ForEach(h =>
                        {
                            var obj = new HolidayMaster()
                            {
                                CountryId=x.Id,
                                Date = h._date,
                                HolidayTypeId = holidayTypeList.FirstOrDefault(t => t.Type == h.holidayType).Id
                            };
                            if (h.name.Count > 0)
                            {
                                obj.HolidayDetails = h.name.Select(n => new HolidayDetail()
                                {
                                    Lang = n.lang,
                                    Text = n.text
                                }).ToList();
                            }
                            x.HolidayMasters.Add(obj);
                            isUpdateRequired = true;
                        });
                    }
                    catch (Exception ex) {
                        exception.Add($"Code {x.Code} exception {ex?.InnerException?.Message}");
                    }
                    //x.HolidayMasters=holidayList.Select(h=> {
                    //new HolidayMaster() { 
                    //Date=h._date,
                    //HolidayTypeId=holidayList.FirstOrDefault(x=>x.name==h.holidayType),
                    //HolidayDetails=holidayList.SelectMany(x=>x.name)

                    //}
                    //})                        
                }
            });

            if (isUpdateRequired)
            {
                //_context.AttachRange(dbCountry);
                _holidayService.UpdateHoliday(dbCountry.SelectMany(x=>x.HolidayMasters));
                //try
                //{
                    await _context.SaveChangesAsync();
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    foreach (var item in ex.EntityValidationErrors)
                //    {
                //        exception.AddRange(item.ValidationErrors.Select(x=>x.ErrorMessage +"-" +x.PropertyName));
                //    }
                //}
            }

            return exception;
        }

        private async Task<List<CountryList>> GetSupportedCountryList() {
            var listQuery = await this.GetAllAsync();
            return listQuery
                .ToList();
        }

    }
}
