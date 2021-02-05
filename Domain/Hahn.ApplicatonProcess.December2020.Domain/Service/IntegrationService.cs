using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Service
{
    public class IntegrationService : IIntegrationService
    {
        public async Task<bool> IsCountryExist(string countryName)
        {
            try
            {

                string Url = string.Format(GlobalConstants.URL, countryName.ToLower());
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                var client = new HttpClient();

                HttpResponseMessage httpResponseMessage = await client.SendAsync(request).ConfigureAwait(false);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message, ex.InnerException); ;
            }
        }
    }
}
