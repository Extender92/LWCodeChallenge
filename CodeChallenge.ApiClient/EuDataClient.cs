using System.Text.Json;
using CodeChallange.Core.Models.ResponseModels;

namespace CodeChallange.ApiClient
{
    public class EuDataClient
    {
        private readonly HttpClient _httpClient;
        private UnemployedDataResponse _cachedData;

        public EuDataClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<UnemployedDataResponse> FetchUnemployedDataAsync()
        {
            if (_cachedData is null)
            {
                _cachedData = await GetUnemployedDataAsync();
                Core.Configuration.UnemploymentDataConfig.Initialize(_cachedData);
            }

            return _cachedData;
        }

        private async Task<UnemployedDataResponse> GetUnemployedDataAsync()
        {
            var url = "https://webgate.ec.europa.eu/empl/redisstat/api/dissemination/sdmx/2.1/data/lmp_ind_actru?format=json&compressed=false";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var jsonDeserialize = JsonSerializer.Deserialize<UnemployedDataResponse>(jsonResponse);

            return jsonDeserialize;
        }
    }
}
