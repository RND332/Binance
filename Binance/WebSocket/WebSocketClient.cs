using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Binance.CurrencyClient
{
    internal class CurrencyClient
    {
        private static readonly HttpClient client = new HttpClient();
        private string URL = "https://marketcap.backend.currency.com/api/v1/token_crypto/";
        public CurrencyClient(string apikey, string apiprivate)
        {
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", apiprivate);
        }
        public async Task<string> GetDepth() 
        {
            var values = new Dictionary<string, string>
            {
                { "symbol", "ETH/USD" },
                { "limit", "2" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(this.URL + "orderbook", content);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
