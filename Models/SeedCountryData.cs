using System;
using System.Linq;
using CountriesList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Country.Any())
                {
                    return;   // DB has been seeded
                }

                context.Country.AddRange(
                    new Country
                    {
                        Name = "Afghanistan",
                        ShortName = "AF"
                    },
                    new Country
                    {
                        Name = "Åland Islands",
                        ShortName = "AX"
                    },
                    new Country
                    {
                        Name = "Albania",
                        ShortName = "AL"
                    },
                    new Country
                    {
                        Name = "Algeria",
                        ShortName = "DZ"
                    },
                    new Country
                    {
                        Name = "American Samoa",
                        ShortName = "AS"
                    },
                    new Country
                    {
                        Name = "AndorrA",
                        ShortName = "AD"
                    },
                    new Country
                    {
                        Name = "Angola",
                        ShortName = "AO"
                    },
                    new Country
                    {
                        Name = "Anguilla",
                        ShortName = "AI"
                    },
                    new Country
                    {
                        Name = "Antarctica",
                        ShortName = "AQ"
                    },
                    new Country
                    {
                        Name = "Antigua and Barbuda",
                        ShortName = "AG"
                    },
                    new Country
                    {
                        Name = "Argentina",
                        ShortName = "AR"
                    },
                    new Country
                    {
                        Name = "Armenia",
                        ShortName = "AM"
                    },
                    new Country
                    {
                        Name = "Aruba",
                        ShortName = "AW"
                    },
                    new Country
                    {
                        Name = "Australia",
                        ShortName = "AU"
                    },
                    new Country
                    {
                        Name = "Austria",
                        ShortName = "AT"
                    },
                    new Country
                    {
                        Name = "Azerbaijan",
                        ShortName = "AZ"
                    },
                    new Country
                    {
                        Name = "Bahamas",
                        ShortName = "BS"
                    },
                    new Country
                    {
                        Name = "Bahrain",
                        ShortName = "BH"
                    },
                    new Country
                    {
                        Name = "Bangladesh",
                        ShortName = "BD"
                    },
                    new Country
                    {
                        Name = "Barbados",
                        ShortName = "BB"
                    },
                    new Country
                    {
                        Name = "Belarus",
                        ShortName = "BY"
                    },
                    new Country
                    {
                        Name = "Belgium",
                        ShortName = "BE"
                    },
                    new Country
                    {
                        Name = "Belize",
                        ShortName = "BZ"
                    },
                    new Country
                    {
                        Name = "Benin",
                        ShortName = "BJ"
                    },
                    new Country
                    {
                        Name = "Bermuda",
                        ShortName = "BM"
                    },
                    new Country
                    {
                        Name = "Bhutan",
                        ShortName = "BT"
                    },
                    new Country
                    {
                        Name = "Bolivia",
                        ShortName = "BO"
                    },
                    new Country
                    {
                        Name = "Bosnia and Herzegovina",
                        ShortName = "BA"
                    },
                    new Country
                    {
                        Name = "Botswana",
                        ShortName = "BW"
                    },
                    new Country
                    {
                        Name = "Bouvet Island",
                        ShortName = "BV"
                    },
                    new Country
                    {
                        Name = "Brazil",
                        ShortName = "BR"
                    },
                    new Country
                    {
                        Name = "British Indian Ocean Territory",
                        ShortName = "IO"
                    },
                    new Country
                    {
                        Name = "Brunei Darussalam",
                        ShortName = "BN"
                    },
                    new Country
                    {
                        Name = "Bulgaria",
                        ShortName = "BG"
                    },
                    new Country
                    {
                        Name = "Burkina Faso",
                        ShortName = "BF"
                    },
                    new Country
                    {
                        Name = "Burundi",
                        ShortName = "BI"
                    },
                    new Country
                    {
                        Name = "Cambodia",
                        ShortName = "KH"
                    },
                    new Country
                    {
                        Name = "Cameroon",
                        ShortName = "CM"
                    },
                    new Country
                    {
                        Name = "Canada",
                        ShortName = "CA"
                    },
                    new Country
                    {
                        Name = "Cape Verde",
                        ShortName = "CV"
                    },
                    new Country
                    {
                        Name = "Cayman Islands",
                        ShortName = "KY"
                    },
                    new Country
                    {
                        Name = "Central African Republic",
                        ShortName = "CF"
                    },
                    new Country
                    {
                        Name = "Chad",
                        ShortName = "TD"
                    },
                    new Country
                    {
                        Name = "Chile",
                        ShortName = "CL"
                    },
                    new Country
                    {
                        Name = "China",
                        ShortName = "CN"
                    },
                    new Country
                    {
                        Name = "Christmas Island",
                        ShortName = "CX"
                    },
                    new Country
                    {
                        Name = "Cocos (Keeling) Islands",
                        ShortName = "CC"
                    },
                    new Country
                    {
                        Name = "Colombia",
                        ShortName = "CO"
                    },
                    new Country
                    {
                        Name = "Comoros",
                        ShortName = "KM"
                    },
                    new Country
                    {
                        Name = "Congo",
                        ShortName = "CG"
                    },
                    new Country
                    {
                        Name = "Congo, The Democratic Republic of the",
                        ShortName = "CD"
                    },
                    new Country
                    {
                        Name = "Cook Islands",
                        ShortName = "CK"
                    },
                    new Country
                    {
                        Name = "Costa Rica",
                        ShortName = "CR"
                    },
                    new Country
                    {
                        Name = "Cote D\"Ivoire",
                        ShortName = "CI"
                    },
                    new Country
                    {
                        Name = "Croatia",
                        ShortName = "HR"
                    },
                    new Country
                    {
                        Name = "Cuba",
                        ShortName = "CU"
                    },
                    new Country
                    {
                        Name = "Cyprus",
                        ShortName = "CY"
                    },
                    new Country
                    {
                        Name = "Czech Republic",
                        ShortName = "CZ"
                    },
                    new Country
                    {
                        Name = "Denmark",
                        ShortName = "DK"
                    },
                    new Country
                    {
                        Name = "Djibouti",
                        ShortName = "DJ"
                    },
                    new Country
                    {
                        Name = "Dominica",
                        ShortName = "DM"
                    },
                    new Country
                    {
                        Name = "Dominican Republic",
                        ShortName = "DO"
                    },
                    new Country
                    {
                        Name = "Ecuador",
                        ShortName = "EC"
                    },
                    new Country
                    {
                        Name = "Egypt",
                        ShortName = "EG"
                    },
                    new Country
                    {
                        Name = "El Salvador",
                        ShortName = "SV"
                    },
                    new Country
                    {
                        Name = "Equatorial Guinea",
                        ShortName = "GQ"
                    },
                    new Country
                    {
                        Name = "Eritrea",
                        ShortName = "ER"
                    },
                    new Country
                    {
                        Name = "Estonia",
                        ShortName = "EE"
                    },
                    new Country
                    {
                        Name = "Ethiopia",
                        ShortName = "ET"
                    },
                    new Country
                    {
                        Name = "Falkland Islands (Malvinas)",
                        ShortName = "FK"
                    },
                    new Country
                    {
                        Name = "Faroe Islands",
                        ShortName = "FO"
                    },
                    new Country
                    {
                        Name = "Fiji",
                        ShortName = "FJ"
                    },
                    new Country
                    {
                        Name = "Finland",
                        ShortName = "FI"
                    },
                    new Country
                    {
                        Name = "France",
                        ShortName = "FR"
                    },
                    new Country
                    {
                        Name = "French Guiana",
                        ShortName = "GF"
                    },
                    new Country
                    {
                        Name = "French Polynesia",
                        ShortName = "PF"
                    },
                    new Country
                    {
                        Name = "French Southern Territories",
                        ShortName = "TF"
                    },
                    new Country
                    {
                        Name = "Gabon",
                        ShortName = "GA"
                    },
                    new Country
                    {
                        Name = "Gambia",
                        ShortName = "GM"
                    },
                    new Country
                    {
                        Name = "Georgia",
                        ShortName = "GE"
                    },
                    new Country
                    {
                        Name = "Germany",
                        ShortName = "DE"
                    },
                    new Country
                    {
                        Name = "Ghana",
                        ShortName = "GH"
                    },
                    new Country
                    {
                        Name = "Gibraltar",
                        ShortName = "GI"
                    },
                    new Country
                    {
                        Name = "Greece",
                        ShortName = "GR"
                    },
                    new Country
                    {
                        Name = "Greenland",
                        ShortName = "GL"
                    },
                    new Country
                    {
                        Name = "Grenada",
                        ShortName = "GD"
                    },
                    new Country
                    {
                        Name = "Guadeloupe",
                        ShortName = "GP"
                    },
                    new Country
                    {
                        Name = "Guam",
                        ShortName = "GU"
                    },
                    new Country
                    {
                        Name = "Guatemala",
                        ShortName = "GT"
                    },
                    new Country
                    {
                        Name = "Guernsey",
                        ShortName = "GG"
                    },
                    new Country
                    {
                        Name = "Guinea",
                        ShortName = "GN"
                    },
                    new Country
                    {
                        Name = "Guinea-Bissau",
                        ShortName = "GW"
                    },
                    new Country
                    {
                        Name = "Guyana",
                        ShortName = "GY"
                    },
                    new Country
                    {
                        Name = "Haiti",
                        ShortName = "HT"
                    },
                    new Country
                    {
                        Name = "Heard Island and Mcdonald Islands",
                        ShortName = "HM"
                    },
                    new Country
                    {
                        Name = "Holy See (Vatican City State)",
                        ShortName = "VA"
                    },
                    new Country
                    {
                        Name = "Honduras",
                        ShortName = "HN"
                    },
                    new Country
                    {
                        Name = "Hong Kong",
                        ShortName = "HK"
                    },
                    new Country
                    {
                        Name = "Hungary",
                        ShortName = "HU"
                    },
                    new Country
                    {
                        Name = "Iceland",
                        ShortName = "IS"
                    },
                    new Country
                    {
                        Name = "India",
                        ShortName = "IN"
                    },
                    new Country
                    {
                        Name = "Indonesia",
                        ShortName = "ID"
                    },
                    new Country
                    {
                        Name = "Iran, Islamic Republic Of",
                        ShortName = "IR"
                    },
                    new Country
                    {
                        Name = "Iraq",
                        ShortName = "IQ"
                    },
                    new Country
                    {
                        Name = "Ireland",
                        ShortName = "IE"
                    },
                    new Country
                    {
                        Name = "Isle of Man",
                        ShortName = "IM"
                    },
                    new Country
                    {
                        Name = "Israel",
                        ShortName = "IL"
                    },
                    new Country
                    {
                        Name = "Italy",
                        ShortName = "IT"
                    },
                    new Country
                    {
                        Name = "Jamaica",
                        ShortName = "JM"
                    },
                    new Country
                    {
                        Name = "Japan",
                        ShortName = "JP"
                    },
                    new Country
                    {
                        Name = "Jersey",
                        ShortName = "JE"
                    },
                    new Country
                    {
                        Name = "Jordan",
                        ShortName = "JO"
                    },
                    new Country
                    {
                        Name = "Kazakhstan",
                        ShortName = "KZ"
                    },
                    new Country
                    {
                        Name = "Kenya",
                        ShortName = "KE"
                    },
                    new Country
                    {
                        Name = "Kiribati",
                        ShortName = "KI"
                    },
                    new Country
                    {
                        Name = "Korea, Democratic People\"S Republic of",
                        ShortName = "KP"
                    },
                    new Country
                    {
                        Name = "Korea, Republic of",
                        ShortName = "KR"
                    },
                    new Country
                    {
                        Name = "Kuwait",
                        ShortName = "KW"
                    },
                    new Country
                    {
                        Name = "Kyrgyzstan",
                        ShortName = "KG"
                    },
                    new Country
                    {
                        Name = "Lao People\"S Democratic Republic",
                        ShortName = "LA"
                    },
                    new Country
                    {
                        Name = "Latvia",
                        ShortName = "LV"
                    },
                    new Country
                    {
                        Name = "Lebanon",
                        ShortName = "LB"
                    },
                    new Country
                    {
                        Name = "Lesotho",
                        ShortName = "LS"
                    },
                    new Country
                    {
                        Name = "Liberia",
                        ShortName = "LR"
                    },
                    new Country
                    {
                        Name = "Libyan Arab Jamahiriya",
                        ShortName = "LY"
                    },
                    new Country
                    {
                        Name = "Liechtenstein",
                        ShortName = "LI"
                    },
                    new Country
                    {
                        Name = "Lithuania",
                        ShortName = "LT"
                    },
                    new Country
                    {
                        Name = "Luxembourg",
                        ShortName = "LU"
                    },
                    new Country
                    {
                        Name = "Macao",
                        ShortName = "MO"
                    },
                    new Country
                    {
                        Name = "Macedonia, The Former Yugoslav Republic of",
                        ShortName = "MK"
                    },
                    new Country
                    {
                        Name = "Madagascar",
                        ShortName = "MG"
                    },
                    new Country
                    {
                        Name = "Malawi",
                        ShortName = "MW"
                    },
                    new Country
                    {
                        Name = "Malaysia",
                        ShortName = "MY"
                    },
                    new Country
                    {
                        Name = "Maldives",
                        ShortName = "MV"
                    },
                    new Country
                    {
                        Name = "Mali",
                        ShortName = "ML"
                    },
                    new Country
                    {
                        Name = "Malta",
                        ShortName = "MT"
                    },
                    new Country
                    {
                        Name = "Marshall Islands",
                        ShortName = "MH"
                    },
                    new Country
                    {
                        Name = "Martinique",
                        ShortName = "MQ"
                    },
                    new Country
                    {
                        Name = "Mauritania",
                        ShortName = "MR"
                    },
                    new Country
                    {
                        Name = "Mauritius",
                        ShortName = "MU"
                    },
                    new Country
                    {
                        Name = "Mayotte",
                        ShortName = "YT"
                    },
                    new Country
                    {
                        Name = "Mexico",
                        ShortName = "MX"
                    },
                    new Country
                    {
                        Name = "Micronesia, Federated States of",
                        ShortName = "FM"
                    },
                    new Country
                    {
                        Name = "Moldova, Republic of",
                        ShortName = "MD"
                    },
                    new Country
                    {
                        Name = "Monaco",
                        ShortName = "MC"
                    },
                    new Country
                    {
                        Name = "Mongolia",
                        ShortName = "MN"
                    },
                    new Country
                    {
                        Name = "Montserrat",
                        ShortName = "MS"
                    },
                    new Country
                    {
                        Name = "Morocco",
                        ShortName = "MA"
                    },
                    new Country
                    {
                        Name = "Mozambique",
                        ShortName = "MZ"
                    },
                    new Country
                    {
                        Name = "Myanmar",
                        ShortName = "MM"
                    },
                    new Country
                    {
                        Name = "Namibia",
                        ShortName = "NA"
                    },
                    new Country
                    {
                        Name = "Nauru",
                        ShortName = "NR"
                    },
                    new Country
                    {
                        Name = "Nepal",
                        ShortName = "NP"
                    },
                    new Country
                    {
                        Name = "Netherlands",
                        ShortName = "NL"
                    },
                    new Country
                    {
                        Name = "Netherlands Antilles",
                        ShortName = "AN"
                    },
                    new Country
                    {
                        Name = "New Caledonia",
                        ShortName = "NC"
                    },
                    new Country
                    {
                        Name = "New Zealand",
                        ShortName = "NZ"
                    },
                    new Country
                    {
                        Name = "Nicaragua",
                        ShortName = "NI"
                    },
                    new Country
                    {
                        Name = "Niger",
                        ShortName = "NE"
                    },
                    new Country
                    {
                        Name = "Nigeria",
                        ShortName = "NG"
                    },
                    new Country
                    {
                        Name = "Niue",
                        ShortName = "NU"
                    },
                    new Country
                    {
                        Name = "Norfolk Island",
                        ShortName = "NF"
                    },
                    new Country
                    {
                        Name = "Northern Mariana Islands",
                        ShortName = "MP"
                    },
                    new Country
                    {
                        Name = "Norway",
                        ShortName = "NO"
                    },
                    new Country
                    {
                        Name = "Oman",
                        ShortName = "OM"
                    },
                    new Country
                    {
                        Name = "Pakistan",
                        ShortName = "PK"
                    },
                    new Country
                    {
                        Name = "Palau",
                        ShortName = "PW"
                    },
                    new Country
                    {
                        Name = "Palestinian Territory, Occupied",
                        ShortName = "PS"
                    },
                    new Country
                    {
                        Name = "Panama",
                        ShortName = "PA"
                    },
                    new Country
                    {
                        Name = "Papua New Guinea",
                        ShortName = "PG"
                    },
                    new Country
                    {
                        Name = "Paraguay",
                        ShortName = "PY"
                    },
                    new Country
                    {
                        Name = "Peru",
                        ShortName = "PE"
                    },
                    new Country
                    {
                        Name = "Philippines",
                        ShortName = "PH"
                    },
                    new Country
                    {
                        Name = "Pitcairn",
                        ShortName = "PN"
                    },
                    new Country
                    {
                        Name = "Poland",
                        ShortName = "PL"
                    },
                    new Country
                    {
                        Name = "Portugal",
                        ShortName = "PT"
                    },
                    new Country
                    {
                        Name = "Puerto Rico",
                        ShortName = "PR"
                    },
                    new Country
                    {
                        Name = "Qatar",
                        ShortName = "QA"
                    },
                    new Country
                    {
                        Name = "Reunion",
                        ShortName = "RE"
                    },
                    new Country
                    {
                        Name = "Romania",
                        ShortName = "RO"
                    },
                    new Country
                    {
                        Name = "Russian Federation",
                        ShortName = "RU"
                    },
                    new Country
                    {
                        Name = "RWANDA",
                        ShortName = "RW"
                    },
                    new Country
                    {
                        Name = "Saint Helena",
                        ShortName = "SH"
                    },
                    new Country
                    {
                        Name = "Saint Kitts and Nevis",
                        ShortName = "KN"
                    },
                    new Country
                    {
                        Name = "Saint Lucia",
                        ShortName = "LC"
                    },
                    new Country
                    {
                        Name = "Saint Pierre and Miquelon",
                        ShortName = "PM"
                    },
                    new Country
                    {
                        Name = "Saint Vincent and the Grenadines",
                        ShortName = "VC"
                    },
                    new Country
                    {
                        Name = "Samoa",
                        ShortName = "WS"
                    },
                    new Country
                    {
                        Name = "San Marino",
                        ShortName = "SM"
                    },
                    new Country
                    {
                        Name = "Sao Tome and Principe",
                        ShortName = "ST"
                    },
                    new Country
                    {
                        Name = "Saudi Arabia",
                        ShortName = "SA"
                    },
                    new Country
                    {
                        Name = "Senegal",
                        ShortName = "SN"
                    },
                    new Country
                    {
                        Name = "Serbia and Montenegro",
                        ShortName = "CS"
                    },
                    new Country
                    {
                        Name = "Seychelles",
                        ShortName = "SC"
                    },
                    new Country
                    {
                        Name = "Sierra Leone",
                        ShortName = "SL"
                    },
                    new Country
                    {
                        Name = "Singapore",
                        ShortName = "SG"
                    },
                    new Country
                    {
                        Name = "Slovakia",
                        ShortName = "SK"
                    },
                    new Country
                    {
                        Name = "Slovenia",
                        ShortName = "SI"
                    },
                    new Country
                    {
                        Name = "Solomon Islands",
                        ShortName = "SB"
                    },
                    new Country
                    {
                        Name = "Somalia",
                        ShortName = "SO"
                    },
                    new Country
                    {
                        Name = "South Africa",
                        ShortName = "ZA"
                    },
                    new Country
                    {
                        Name = "South Georgia and the South Sandwich Islands",
                        ShortName = "GS"
                    },
                    new Country
                    {
                        Name = "Spain",
                        ShortName = "ES"
                    },
                    new Country
                    {
                        Name = "Sri Lanka",
                        ShortName = "LK"
                    },
                    new Country
                    {
                        Name = "Sudan",
                        ShortName = "SD"
                    },
                    new Country
                    {
                        Name = "Suriname",
                        ShortName = "SR"
                    },
                    new Country
                    {
                        Name = "Svalbard and Jan Mayen",
                        ShortName = "SJ"
                    },
                    new Country
                    {
                        Name = "Swaziland",
                        ShortName = "SZ"
                    },
                    new Country
                    {
                        Name = "Sweden",
                        ShortName = "SE"
                    },
                    new Country
                    {
                        Name = "Switzerland",
                        ShortName = "CH"
                    },
                    new Country
                    {
                        Name = "Syrian Arab Republic",
                        ShortName = "SY"
                    },
                    new Country
                    {
                        Name = "Taiwan, Province of China",
                        ShortName = "TW"
                    },
                    new Country
                    {
                        Name = "Tajikistan",
                        ShortName = "TJ"
                    },
                    new Country
                    {
                        Name = "Tanzania, United Republic of",
                        ShortName = "TZ"
                    },
                    new Country
                    {
                        Name = "Thailand",
                        ShortName = "TH"
                    },
                    new Country
                    {
                        Name = "Timor-Leste",
                        ShortName = "TL"
                    },
                    new Country
                    {
                        Name = "Togo",
                        ShortName = "TG"
                    },
                    new Country
                    {
                        Name = "Tokelau",
                        ShortName = "TK"
                    },
                    new Country
                    {
                        Name = "Tonga",
                        ShortName = "TO"
                    },
                    new Country
                    {
                        Name = "Trinidad and Tobago",
                        ShortName = "TT"
                    },
                    new Country
                    {
                        Name = "Tunisia",
                        ShortName = "TN"
                    },
                    new Country
                    {
                        Name = "Turkey",
                        ShortName = "TR"
                    },
                    new Country
                    {
                        Name = "Turkmenistan",
                        ShortName = "TM"
                    },
                    new Country
                    {
                        Name = "Turks and Caicos Islands",
                        ShortName = "TC"
                    },
                    new Country
                    {
                        Name = "Tuvalu",
                        ShortName = "TV"
                    },
                    new Country
                    {
                        Name = "Uganda",
                        ShortName = "UG"
                    },
                    new Country
                    {
                        Name = "Ukraine",
                        ShortName = "UA"
                    },
                    new Country
                    {
                        Name = "United Arab Emirates",
                        ShortName = "AE"
                    },
                    new Country
                    {
                        Name = "United Kingdom",
                        ShortName = "GB"
                    },
                    new Country
                    {
                        Name = "United States",
                        ShortName = "US"
                    },
                    new Country
                    {
                        Name = "United States Minor Outlying Islands",
                        ShortName = "UM"
                    },
                    new Country
                    {
                        Name = "Uruguay",
                        ShortName = "UY"
                    },
                    new Country
                    {
                        Name = "Uzbekistan",
                        ShortName = "UZ"
                    },
                    new Country
                    {
                        Name = "Vanuatu",
                        ShortName = "VU"
                    },
                    new Country
                    {
                        Name = "Venezuela",
                        ShortName = "VE"
                    },
                    new Country
                    {
                        Name = "Viet Nam",
                        ShortName = "VN"
                    },
                    new Country
                    {
                        Name = "Virgin Islands, British",
                        ShortName = "VG"
                    },
                    new Country
                    {
                        Name = "Virgin Islands, U.S.",
                        ShortName = "VI"
                    },
                    new Country
                    {
                        Name = "Wallis and Futuna",
                        ShortName = "WF"
                    },
                    new Country
                    {
                        Name = "Western Sahara",
                        ShortName = "EH"
                    },
                    new Country
                    {
                        Name = "Yemen",
                        ShortName = "YE"
                    },
                    new Country
                    {
                        Name = "Zambia",
                        ShortName = "ZM"
                    },
                    new Country
                    {
                        Name = "Zimbabwe",
                        ShortName = "ZW"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}