using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Binance.CurrencyClient
{
    internal class CurrencyClient
    {
        private static HttpClient Client = new HttpClient();

        /// Receives bid and ask for the specified coin 
        public static async Task<string> GetPrices(string token) 
        {
            return await Client.GetStringAsync($"https://marketcap.backend.currency.com/api/v1/token_crypto/orderbook?symbol={token + "/USD"}");
        }

        /// Receives bid and ask for the specified pair 
        public static async Task<string> GetPrices(string token1, string token2)
        {
            return await Client.GetStringAsync($"https://marketcap.backend.currency.com/api/v1/token_crypto/orderbook?symbol={token1 + "/" + token2}");
        }
    }
}
