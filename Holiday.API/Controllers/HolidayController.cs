using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday.BL.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Holiday.API.Controllers
{
    [Route("api/[controller]")]
    public class HolidayController : Controller
    {
        private IAPICountryListService _countryListService;
        private IHolidayService _holidayService;
        public HolidayController(IAPICountryListService countryListService, IHolidayService holidayService)
        {
            _countryListService = countryListService;
            _holidayService = holidayService;
        }
       
            // POST api/<controller>
        //[Route("UpdateAPIData")]
       [Route("RefreshDBFromAPI")]
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var result = await _countryListService.UpdateCountry();
            return Ok(result);

        }

        [HttpGet("{countryCode}/{year}")]
        public async Task<IActionResult> GetMonthWiseList(string countryCode,int year) {

            return Ok(await _holidayService.GetMonthWiseHoliday(countryCode,year));

        }
    }
}
