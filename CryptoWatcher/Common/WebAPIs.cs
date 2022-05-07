using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace CryptoWatcher.Common
{
    static class WebAPIs
    {
        public static async Task<string> GetCurrentPrice(string fsym, string tsyms = "usdt")
        {
            var resp = await $"https://api.huobi.com/market/trade?symbol={fsym}{tsyms}".GetStringAsync();
            JObject _jObject = JObject.Parse(resp);
            return _jObject["tick"]["data"][0]["price"].ToString();
        }
    }
}
