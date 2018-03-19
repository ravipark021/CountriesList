using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesList.Models;
using Newtonsoft.Json.Linq;

namespace CountriesList.Helpers
{
    public static class CountryMaker
    {
        public static object GetCountriesData(List<Country> source, int page, int pageSize)
        {
            List<object> results = new List<object>();
            // var results = Task.WhenAll(source.Select(PopulateCountryData));
            foreach (var item in source)
            {
                results.Add(PopulateCountryData(item));
            }
            return new
            {
                countries = results.ToList(),
                page = page,
                maxDataSize = pageSize
            };
        }
        public static object GetCountryData(Country source)
        {
            return PopulateCountryData(source);
        }

        private static object PopulateCountryData(Country country)
        {
            string countryDataAPI = "https://restcountries.eu/rest/v2/alpha/" + country.ShortName + "?fields=capital;currencies";
            string countryFlag = "http://www.countryflags.io/" + country.ShortName + "/flat/64.png";
            string countryCapital = string.Empty;

            string currencyValue = string.Empty;
            try
            {
                var countryDataResponse = Utilities.Get(countryDataAPI);
                var JsonResponse = JObject.Parse(countryDataResponse.Result);
                countryCapital = JsonResponse["capital"].ToString();

                var JSONCurrencyResponse = JObject.Parse(JsonResponse["currencies"][0].ToString());
                string currencyCode = JSONCurrencyResponse["code"].ToString();
                string currencyName = JSONCurrencyResponse["name"].ToString();

                string currencyDataAPI = "https://free.currencyconverterapi.com/api/v5/convert?q=" + currencyCode + "_INR&compact=ultra";

                var currencyValueResponse = Utilities.Get(currencyDataAPI);
                var currencyValueJsonResponse = JObject.Parse(currencyValueResponse.Result);
                currencyValue = currencyValueJsonResponse.First.First.ToString();

            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception);
            }

            return new
            {
                countryName = country.Name,
                countryCode = country.ShortName,
                countryCapital = countryCapital,
                currencyValueInINR = currencyValue,
                countryFlagURI = countryFlag
            };
        }

        
        public static CountryViewModel PopulateFullCountryData(Country country, bool isFavorite)
        {
            
            string countryMapURI = "https://maps.google.com/maps?q=" + country.Name + "&t=&z=3&ie=UTF8&iwloc=&output=embed";
            string countryDataAPI = "https://restcountries.eu/rest/v2/alpha/" + country.ShortName + "?fields=capital;currencies";
            string countryFlag = "http://www.countryflags.io/" + country.ShortName + "/flat/64.png";

            var countryDataResponse = Utilities.Get(countryDataAPI);
            var JsonResponse = JObject.Parse(countryDataResponse.Result);
            string countryCapital = JsonResponse["capital"].ToString();

            var JSONCurrencyResponse = JObject.Parse(JsonResponse["currencies"][0].ToString());
            string currencyCode = JSONCurrencyResponse["code"].ToString();
            string currencyName = JSONCurrencyResponse["name"].ToString();

            string currencyDataAPI = "https://free.currencyconverterapi.com/api/v5/convert?q=" + currencyCode + "_INR&compact=ultra";

            string currencyValue = string.Empty;
            try
            {
                var currencyValueResponse = Utilities.Get(currencyDataAPI);
                var currencyValueJsonResponse = JObject.Parse(currencyValueResponse.Result);
                currencyValue = currencyValueJsonResponse.First.First.ToString();
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception);
            }

            CountryViewModel countryData = new CountryViewModel(){
                IsFavorite = isFavorite,
                CountryName = country.Name,
                CountryCode = country.ShortName,
                CurrencyCode = currencyCode,
                currencyName = currencyName,
                CurrencyValue = currencyValue,
                CountryCapital = countryCapital,
                CountryMapURI = countryMapURI,
                CountryFlag = countryFlag 
            };

            return countryData;
        }
    }
}