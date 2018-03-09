using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CountriesList.Models;
using Microsoft.AspNetCore.Authorization;
using CountriesList.Data;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CountriesList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext _dbContext = null;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var countries = _dbContext.Country.Select(x => x).ToList();
            System.Console.WriteLine(countries.Count());
            return View(countries);
        }

        [HttpPost]
        public JsonResult GetAllCountries()
        {
            var countries = _dbContext.Country.Select(x => x.Name).ToList();
            return Json(countries);
        }

        [HttpPost]
        public JsonResult GetCountryData(string countryName, int pageNumber)
        {
            if (string.IsNullOrEmpty(countryName))
                return Json(null);
            var country = _dbContext.Country.Where(x => x.Name.Equals(countryName)).SingleOrDefault();
            if (country == null)
                return Json(null);
            Dictionary<string, string> countryData = PopulateCountryData(country);
            return Json(countryData);
        }

        public Dictionary<string, string> PopulateCountryData(Country country)
        {
            Dictionary<string, string> countryData = new Dictionary<string, string>();
            string countryMapURI = "https://maps.google.com/maps?q=" + country.Name + "&t=&z=3&ie=UTF8&iwloc=&output=embed";
            string countryDataAPI = "https://restcountries.eu/rest/v2/alpha/" + country.ShortName + "?fields=capital;currencies";
            string countryFlag = "http://www.countryflags.io/" + country.ShortName + "/flat/64.png";

            var countryDataResponse = Utils.Utilities.Get(countryDataAPI);
            var JsonResponse = JObject.Parse(countryDataResponse.Result);
            string countryCapital = JsonResponse["capital"].ToString();

            var JSONCurrencyResponse = JObject.Parse(JsonResponse["currencies"][0].ToString());
            string currencyCode = JSONCurrencyResponse["code"].ToString();
            string currencyName = JSONCurrencyResponse["name"].ToString();

            string currencyDataAPI = "https://free.currencyconverterapi.com/api/v5/convert?q=" + currencyCode + "_INR&compact=ultra";

            string currencyValue = string.Empty;
            try
            {
                var currencyValueResponse = Utils.Utilities.Get(currencyDataAPI);
                var currencyValueJsonResponse = JObject.Parse(currencyValueResponse.Result);
                currencyValue = currencyValueJsonResponse.First.First.ToString();
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isFavorite = _dbContext.Favorites.Any(x => x.UserId.Equals(userId) && x.CountryId.Equals(country.CountryId));

            countryData["isFavorite"] = isFavorite ? "1" : "0";
            countryData["countryName"] = country.Name;
            countryData["countryCode"] = country.ShortName;
            countryData["currencyCode"] = currencyCode;
            countryData["currencyName"] = currencyName;
            countryData["currencyValue"] = currencyValue;
            countryData["countryCapital"] = countryCapital;
            countryData["countryMapURI"] = countryMapURI;
            countryData["countryFlag"] = countryFlag;

            return countryData;
        }


        [HttpPost]
        public JsonResult ToggleLike(bool isLiked, string countryName)
        {
            Dictionary<string, string> returnData = new Dictionary<string, string>();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var country = _dbContext.Country.Where(x => x.Name.Equals(countryName)).FirstOrDefault();
            if (country != null)
            {
                try
                {
                    string countryId = country.CountryId;
                    var isFavorite = _dbContext.Favorites.Select(x => x.UserId == userId && x.CountryId == countryId).FirstOrDefault();
                    if (isLiked && !isFavorite)
                    {
                        _dbContext.Favorites.Add(new Favorites { CountryId = countryId, UserId = userId });
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var favorite = _dbContext.Favorites.Where(x => x.UserId == userId && x.CountryId == countryId).FirstOrDefault();
                        if (favorite != null)
                        {
                            _dbContext.Favorites.Remove(favorite);
                            _dbContext.SaveChanges();
                        }
                    }
                    returnData["Error"] = "";
                    returnData["isLiked"] = isLiked.ToString();
                }
                catch (System.Exception)
                {
                    returnData["Error"] = "Some error encountered";
                    returnData["isLiked"] = (!isLiked).ToString();
                }

            }
            return Json(returnData);
        }

        [HttpGet]
        public IActionResult Favorites()
        {
            ViewData["favorites"] = GetAllFavorites();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Some details about me => ";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Ravi Parkash";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult GetAllFavorites(int pageNumber = 0)
        {
            List<Dictionary<string, string>> userFavorites = new List<Dictionary<string, string>>();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favorites = _dbContext.Favorites.Where(x => x.UserId.Equals(userId)).ToList();

            foreach (var favorite in GetPage(favorites, pageNumber, 10))
            {
                var countryData = _dbContext.Country.Where(x => x.CountryId.Equals(favorite.CountryId)).FirstOrDefault();
                if (countryData != null)
                    userFavorites.Add(PopulateCountryData(countryData));
            }
            return Json(userFavorites);
        }

        IList<Models.Favorites> GetPage(IList<Models.Favorites> list, int page, int pageSize) {
            return list.Skip(page*pageSize).Take(pageSize).ToList();
        }
    }
}
