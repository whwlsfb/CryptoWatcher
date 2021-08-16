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
    public partial class AlertEdit : Form
    {
        public AlertEdit()
        {
            InitializeComponent();
            jugerType.SelectedIndex = 0;
        }
        public static Alert Create()
        {
            var item = new Alert();
            var form = new AlertEdit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                item.Type = (JugerType)form.jugerType.SelectedIndex;
                item.PricePoint = float.Parse(form.pricePoint.Text);
                return item;
            }
            else return null;
        }
        public bool CheckValid()
        {
            return !string.IsNullOrEmpty(pricePoint.Text) && float.TryParse(pricePoint.Text, out float _);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("请正确填写全部信息!");
        }
    }
}
