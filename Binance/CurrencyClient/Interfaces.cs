using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance
{
    /// <summary>
    /// Used for Deserialize responce from Currency
    /// </summary>
    public class CurrencyPrice
    {
        public long timestamp { get; set; }
        public List<List<double>> asks { get; set; }
        public List<List<double>> bids { get; set; }
    }

    /// <summary>
    /// Used for answering user request
    /// </summary>
    public class Prices
    {
        public long timestamp { get; set; }
        public double asks { get; set; }
        public double bids { get; set; }

        public Prices(long timestamp, double asks, double bids)
        {
            this.timestamp = timestamp;
            this.asks = asks;
            this.bids = bids;
        }

        public override string ToString() => ($"{timestamp} {asks} {bids}");
    }
}
