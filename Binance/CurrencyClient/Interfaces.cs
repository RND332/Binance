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
    public interface ICurrencyPrice
    {
        public long timestamp { get; set; }
        public List<List<double>> asks { get; set; }
        public List<List<double>> bids { get; set; }
    }
    /// <summary>
    /// Used for answering user request
    /// </summary>
    public interface IPrices
    {
        public long timestamp { get; set; }
        public double asks { get; set; }
        public double bids { get; set; }
    }
}
