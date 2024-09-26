using CodeChallange.ApiClient;
using CodeChallange.Core.Configuration;
using CodeChallange.Core.Models;
using CodeChallange.Core.Services;
using CodeChallenge.ConsoleApp.InputHandling;
using CodeChallenge.ConsoleApp.UI;

namespace CodeChallenge.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var api = new EuDataClient();
            var countryDataService = new CountryDataService();

            var responseData = await api.FetchUnemployedDataAsync();

            DataSettings settings = new DataSettings
            {
                PolicyIndex = 5,
                RegistrationIndex = 1,
                AgeIndex = 1,
            };

            var countries = new List<CountryDataModel>();

            foreach (int countryIndex in responseData.Dimension.Geo.Category.Index.Values)
            {
                if (countryIndex == 0 || countryIndex == 1)
                {
                    continue;
                }
                settings.CountryIndex = countryIndex;
                countries.Add(countryDataService.ConvertDataToCountryData(responseData, settings));
            }

            UIManager uiManager = new UIManager();
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                uiManager.DrawMenu(countries, selectedIndex);
                uiManager.DrawBarChart(countries[selectedIndex]);

                key = Console.ReadKey(true).Key;
                selectedIndex = ArrowKeyMenuController.HandleArrowKeyInput(true, selectedIndex, 1, countries.Count, key);

            } while (selectedIndex != -1);
        }

        static async Task Testing()
        {
            var api = new EuDataClient();
            var countryDataService = new CountryDataService();

            try
            {
                // Fetch the raw response from the API
                var responseData = await api.FetchUnemployedDataAsync();

                // Convert the raw data to country-specific data for Sweden
                DataSettings settings = new DataSettings
                {
                    CountryIndex = 28,
                    PolicyIndex = 5,
                    RegistrationIndex = 1,
                    AgeIndex = 1,
                };
                var swedenData = countryDataService.ConvertDataToCountryData(responseData, settings);

                Console.WriteLine($"Country: {swedenData.CountryName}");
                foreach (var stat in swedenData.UnemploymentStats)
                {
                    Console.WriteLine($"Year: {stat.Year}, Male Rate: {stat.MaleRate}, Female Rate: {stat.FemaleRate}, Total Rate: {stat.TotalRate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
