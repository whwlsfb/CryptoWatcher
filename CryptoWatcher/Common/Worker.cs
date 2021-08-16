using CryptoWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoWatcher.Common
{
    public class Worker : IDisposable
    {
        public bool Closed { get; set; } = false;
        public ListViewItem Binding { get; set; }
        public CryptoItem CryptoItem { get; set; }
        public NotifyIcon NotifyIcon { get; set; }

        public void Dispose()
        {
            Closed = true;
        }

        public async void StartWork()
        {
            while (!Closed)
            {
                UpdateStatus("等待...");
                await Task.Delay(CryptoItem.RefreshInterval);
                try
                {
                    UpdateStatus("正在获取...");
                    CryptoItem.Price = float.Parse(await WebAPIs.GetCurrentPrice(CryptoItem.CybermoneyName, CryptoItem.CurrencyName));
                    var greaters = CryptoItem.Alerts.Where(e => e.Type == JugerType.Greater).OrderByDescending(e => e.PricePoint);
                    foreach (var juger in greaters)
                    {
                        if (CryptoItem.Price > juger.PricePoint)
                        {
                            if (!juger.Trigged)
                            {
                                Notify("上涨提醒", $"{CryptoItem.CybermoneyName}/{CryptoItem.CurrencyName} 目前价格为: {CryptoItem.Price}");
                                juger.Trigged = true;
                            }
                            break;
                        }
                        else
                        {
                            juger.Trigged = false;
                        }
                    }

                    var less_s = CryptoItem.Alerts.Where(e => e.Type == JugerType.Less).OrderBy(e => e.PricePoint);
                    foreach (var juger in less_s)
                    {
                        if (CryptoItem.Price < juger.PricePoint)
                        {
                            if (!juger.Trigged)
                            {
                                Notify("下跌提醒", $"{CryptoItem.CybermoneyName}/{CryptoItem.CurrencyName} 目前价格为: {CryptoItem.Price}");
                                juger.Trigged = true;
                            }
                            break;
                        }
                        else
                        {
                            juger.Trigged = false;
                        }
                    }
                    foreach (var juger in CryptoItem.Alerts.Where(e => e.Type == JugerType.Equal))
                    {
                        if (CryptoItem.Price == juger.PricePoint)
                        {
                            if (!juger.Trigged)
                            {
                                Notify("到达设定值", $"{CryptoItem.CybermoneyName}/{CryptoItem.CurrencyName} 目前价格为: {CryptoItem.Price}");
                                juger.Trigged = true;
                            }
                        }
                        else
                        {
                            juger.Trigged = false;
                        }
                    }
                    UpdateStatus("...");
                    UpdateUI();
                }
                catch { }
            }
        }
        private void Notify(string title, string text)
        {
            NotifyIcon.BalloonTipTitle = title;
            NotifyIcon.BalloonTipText = text;
            NotifyIcon.ShowBalloonTip(3000);
        }
        private void UpdateUI()
        {
            Binding.SubItems[1].Text = CryptoItem.Price.ToString();
        }
        private void UpdateStatus(string msg)
        {
            Binding.SubItems[3].Text = msg;
        }
    }
}
