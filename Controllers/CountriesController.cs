using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesList.Data;
using CountriesList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CountriesList.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        ApplicationDbContext _dbContext = null;
        public CountriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JsonResult> Get(int? page = null, int pageSize = 10, string searchString = "")
        {
            object countries = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                countries = await PaginatedList<Country>
                        .CreateAsync(_dbContext.Country.Where(x => x.Name.ToUpper().StartsWith(searchString.ToUpper())), page ?? 1, pageSize);
            }
            else
            {
                countries = await PaginatedList<Country>.CreateAsync(_dbContext.Country, page ?? 1, pageSize);
            }
            return Json(Services.CountryMaker.GetCountriesData(countries as List<Country>, page ?? 1, pageSize));
        }


        // GET api/values/5
        [HttpGet("{code}")]
        public JsonResult Get(string code)
        {
            var country = _dbContext.Country.Where(x => x.ShortName.Equals(code, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            if (country != null)
                return Json(Services.CountryMaker.GetCountryData(country));

            return Json(new object[] { new object() });
        }
    }
}