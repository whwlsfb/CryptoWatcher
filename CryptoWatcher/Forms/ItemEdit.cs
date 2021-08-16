using CryptoWatcher.Common;
using CryptoWatcher.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoWatcher.Forms
{
    public partial class ItemEdit : Form
    {
        public CryptoItem Result;
        public ItemEdit()
        {
            InitializeComponent();
        }

        public static CryptoItem Edit(CryptoItem old_item = null)
        {
            var form = new ItemEdit();
            if (old_item != null)
                form.InitFromItem(old_item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.Result;
            }
            else return null;
        }
        public void InitFromItem(CryptoItem item)
        {
            currencyName.Text = item.CurrencyName;
            cybermoneyName.Text = item.CybermoneyName;
            refreshInterval.Value = item.RefreshInterval / 1000;
            foreach (var alert in item.Alerts)
            {
                appendAlertItem(alert);
            }
        }
        public bool CheckValid()
        {
            return !string.IsNullOrEmpty(cybermoneyName.Text) && !string.IsNullOrEmpty(currencyName.Text);
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    Result = new CryptoItem();
                    Result.CybermoneyName = cybermoneyName.Text;
                    Result.CurrencyName = currencyName.Text;
                    Result.RefreshInterval = Convert.ToInt32(refreshInterval.Value * 1000);
                    Result.Price = float.Parse(await WebAPIs.GetCurrentPrice(Result.CybermoneyName, Result.CurrencyName));
                    foreach (ListViewItem alert in alertList.Items)
                        Result.Alerts.Add(alert.Tag as Alert);
                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("添加失败,请确认币种是否填写正确!");
                }
            }
            else
            {
                MessageBox.Show("请填写全部信息!");
            }
        }
        private void appendAlertItem(Alert item)
        {
            if (item != null)
            {
                var listItem = new ListViewItem();
                listItem.Text = item.Type == JugerType.Greater ? "大于" : item.Type == JugerType.Less ? "小于" : "等于";
                listItem.SubItems.Add(item.PricePoint.ToString());
                listItem.Tag = item;
                alertList.Items.Add(listItem);
            }
        }
        private void alert_add_Click(object sender, EventArgs e)
        {
            appendAlertItem(AlertEdit.Create());
        }

        private void alert_del_Click(object sender, EventArgs e)
        {
            if (alertList.SelectedItems.Count > 0)
                alertList.Items.Remove(alertList.SelectedItems[0]);
        }
    }
}
