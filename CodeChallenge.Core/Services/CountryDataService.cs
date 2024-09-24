using CodeChallange.Core.Configuration;
using CodeChallange.Core.Models;
using CodeChallange.Core.Models.ResponseModels;

namespace CodeChallange.Core.Services
{
    public class CountryDataService
    {
        public CountryDataModel ConvertDataToCountryData(UnemployedDataResponse data, DataSettings settings)
        {
            var countryData = new CountryDataModel
            {
                CountryCode = GetCountryCodeFromIndex(data, settings.CountryIndex),
                CountryName = GetCountryNameFromIndex(data, settings.CountryIndex),
                UnemploymentStats = new List<UnemploymentData>()
            };

            if (data?.Dimension?.Geo?.Category?.Index != null && data.Dimension.Geo.Category.Index.ContainsValue(settings.CountryIndex))
            {
                data.Dimension.Sex.Category.Index.TryGetValue("T", out int totalIndex);
                data.Dimension.Sex.Category.Index.TryGetValue("M", out int malesIndex);
                data.Dimension.Sex.Category.Index.TryGetValue("F", out int femalesIndex);

                foreach (var timePeriod in data.Dimension.TimePeriod.Category.Index)
                {
                    var yearIndex = timePeriod.Value;

                    var unemploymentData = new UnemploymentData
                    {
                        Year = int.Parse(timePeriod.Key),
                        TotalRate = GetValueForSettings(data, settings, yearIndex, totalIndex) ?? 0,
                        MaleRate = GetValueForSettings(data, settings, yearIndex, malesIndex) ?? 0,
                        FemaleRate = GetValueForSettings(data, settings, yearIndex, femalesIndex) ?? 0
                    };

                    countryData.UnemploymentStats.Add(unemploymentData);
                }
            }
            return countryData;
        }

        private double? GetValueForSettings(UnemployedDataResponse data, DataSettings settings, int yearIndex, int sexIndex)
        {
            int? key = CalculateKey(settings, yearIndex, sexIndex);
            return key.HasValue && data.Value.ContainsKey(key.Value) ? data.Value[key.Value] : (double?)null;
        }

        private int CalculateKey(DataSettings settings, int yearIndex, int sexIndex)
        {
            int years = UnemploymentDataConfig.Years;
            int countries = UnemploymentDataConfig.Countries;
            int policies = UnemploymentDataConfig.Policies;
            int registrations = UnemploymentDataConfig.Registrations;
            int sexes = UnemploymentDataConfig.Sexes;
            int ages = UnemploymentDataConfig.Ages;

            int key = (settings.AgeIndex * sexes * registrations * policies * countries * years) +
                      (sexIndex * registrations * policies * countries * years) +
                      (settings.RegistrationIndex * policies * countries * years) +
                      (settings.PolicyIndex * countries * years) +
                      (settings.CountryIndex * years) +
                      yearIndex;

            return key;
        }

        public string GetCountryCodeFromIndex(UnemployedDataResponse data, int countryIndex)
        {
            var countryCode = data.Dimension.Geo.Category.Index.FirstOrDefault(x => x.Value == countryIndex).Key;
            return countryCode ?? "Unknown";
        }

        public string GetCountryNameFromIndex(UnemployedDataResponse data, int countryIndex)
        {
            var countryCode = GetCountryCodeFromIndex(data, countryIndex);
            return data.Dimension.Geo.Category.Label.ContainsKey(countryCode) ? data.Dimension.Geo.Category.Label[countryCode] : "Unknown";
        }
    }
}
