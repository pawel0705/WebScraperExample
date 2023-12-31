﻿using Newtonsoft.Json;
using WebScraper;

var countryScraper = new CountryScraper();

var countries = countryScraper.GetCountries();

var cityScraper = new CityScraper();

var result = new List<CountryDetails>();

foreach (var country in countries)
{
    Console.WriteLine($"Getting cities for: {country.Name}");
    var cities = cityScraper.GetCities(country).ToList();

    result.Add(new CountryDetails()
    {
        Code = country.Code,
        Name = country.Name,
        Cities = cities
    });
}

Console.WriteLine("Finished");

var json = JsonConvert.SerializeObject(result);

File.WriteAllText(@"D:\Data\result.json", json);
