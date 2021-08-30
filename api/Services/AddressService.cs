using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Services
{
    public class AddressService : IAddressService
    {

        /// <summary>
        /// Returns address based on account
        /// </summary>
        /// <param name="model">Instance of <see cref="AccountModel"/></param>
        /// <returns>Address as string</returns>

        public async Task<string> GetAddress(AccountModel model)
        {
            var response = await HttpClientFactory.Client.GetAsync("https://randomuser.me/api/?nat=gb");
            var content = response.Content;
            var address = content.ReadAsStringAsync().Result;

            return GetCityAndPostCode(address);
        }

        private string GetCityAndPostCode(string json)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic cityName = jsonObject.results[0].location.city;
            dynamic postcode = jsonObject.results[0].location.postcode;

            var address = $"{cityName.ToString()} {postcode.ToString()}";

            return address;
        }
    }
}
