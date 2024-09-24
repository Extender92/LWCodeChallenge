using CodeChallange.ApiClient;
using CodeChallange.Core.Configuration;
using CodeChallange.Core.Services;

namespace CodeChallenge.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
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
