using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday.BL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holiday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _countryService.GetCountryList());
        }
    }
}