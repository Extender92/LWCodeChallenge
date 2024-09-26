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
            Console.CursorVisible = false;
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
    }
}
