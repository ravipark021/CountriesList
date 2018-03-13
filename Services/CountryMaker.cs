using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesList.Models;
using Newtonsoft.Json.Linq;

namespace CountriesList.Services
{
    public class CountryMaker
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
                var countryDataResponse = Utils.Utilities.Get(countryDataAPI);
                var JsonResponse = JObject.Parse(countryDataResponse.Result);
                countryCapital = JsonResponse["capital"].ToString();

                var JSONCurrencyResponse = JObject.Parse(JsonResponse["currencies"][0].ToString());
                string currencyCode = JSONCurrencyResponse["code"].ToString();
                string currencyName = JSONCurrencyResponse["name"].ToString();

                string currencyDataAPI = "https://free.currencyconverterapi.com/api/v5/convert?q=" + currencyCode + "_INR&compact=ultra";

                var currencyValueResponse = Utils.Utilities.Get(currencyDataAPI);
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
    }
}