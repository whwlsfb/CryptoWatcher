using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoWatcher.Models
{
    public class CryptoItem
    {
        
        public string CybermoneyName { get; set; }
        public string CurrencyName { get; set; }
        public int RefreshInterval { get; set; }
        public float Price { get; set; }
        public List<Alert> Alerts { get; set; } = new List<Alert>();
    }
    public class Alert
    {
        public JugerType Type { get; set; }
        public float PricePoint { get; set; }
        public bool Trigged { get; set; } = false;
    }
    public enum JugerType
    {
        Greater = 0,
        Less = 1,
        Equal = 2
    }
}
