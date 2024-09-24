
namespace CodeChallange.Core.Models
{
    public class CountryDataModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public List<UnemploymentData> UnemploymentStats { get; set; }
    }
}
