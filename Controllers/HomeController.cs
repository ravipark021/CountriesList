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
using CountriesList.Helpers;

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
        public IActionResult Search()
        {
            var countries = _dbContext.Country.Select(x => x).ToList();
            return View(countries);
        }

        [HttpPost]
        public JsonResult GetAllCountries()
        {
            var countries = _dbContext.Country.Select(x => new {x.Name, x.ShortName}).ToList();
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

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isFavorite = _dbContext.Favorites.Any(x => x.UserId.Equals(userId) && x.CountryId.Equals(country.CountryId));

            CountryViewModel countryData = CountryMaker.PopulateFullCountryData(country, isFavorite);
            return Json(countryData);
        }
        [HttpPost]
        public JsonResult ToggleLike(bool isLiked, string countryName)
        {
            string error = string.Empty;
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
                }
                catch (System.Exception)
                {
                    error = "Some error encountered";
                    isLiked = !isLiked;
                }

            }
            return Json(new { error = error, isLiked = isLiked });
        }

        [HttpGet]
        public IActionResult Favorites(string sortOrder, string currentFilter,
            string searchString,
            int? page)
        {
            int pageSize = 10;
            var favoriteCountries = GetAllFavorites();
            List<CountryViewModel> paginatedCountryDataList = new List<CountryViewModel>();
            var paginatedCountryList = PaginatedList<Country>.CreateNonAsync(favoriteCountries, page ?? 1, pageSize);
            Parallel.ForEach((List<Country>)paginatedCountryList, (country) =>
            {
                paginatedCountryDataList.Add(CountryMaker.PopulateFullCountryData(country, true));
            });
            return View(new PaginatedList<CountryViewModel>(paginatedCountryDataList, favoriteCountries.Count(), page ?? 1, pageSize));
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
        public IEnumerable<Country> GetAllFavorites()
        {
            List<Country> userFavorites = new List<Country>();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favorites = _dbContext.Favorites.Where(x => x.UserId.Equals(userId)).ToList();

            foreach (var favorite in favorites)
            {
                var countryData = _dbContext.Country.Where(x => x.CountryId.Equals(favorite.CountryId)).FirstOrDefault();
                if (countryData != null)
                    userFavorites.Add(countryData);
            }
            return userFavorites;
        }
    }
}
