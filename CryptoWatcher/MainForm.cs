using CryptoWatcher.Common;
using CryptoWatcher.Forms;
using CryptoWatcher.Models;
using CryptoWatcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CryptoWatcher
{
    public partial class MainForm : Form
    {
        private Dictionary<string, Worker> Workers = new Dictionary<string, Worker>();
        private string ConfigPath = Path.Combine(Application.StartupPath, "config.json");
        public MainForm()
        {
            InitializeComponent();
            Icon = Resources.mainIcon;
            notifyIcon.Icon = Resources.mainIcon;
        }

        #region 最小化到托盘事件托管
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon.Visible = false;
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        #endregion
        #region 窗口拖动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!winlock.Checked && minMode.Checked)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x0112, 0xF012, 0);
            }
        }
        #endregion
        #region 鼠标穿透
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );
        private uint oldStyle;
        /// <summary>
        　　/// 设置窗体具有鼠标穿透效果
        　　/// </summary>
        　　/// <param name="flag">true穿透，false不穿透</param>
        public void SetPenetrate(bool flag = true)
        {
            uint style = GetWindowLong(this.Handle, GWL_EXSTYLE);
            if (flag)
            {
                oldStyle = style;
                SetWindowLong(Handle, GWL_EXSTYLE, style | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            }
            else
                SetWindowLong(Handle, GWL_EXSTYLE, oldStyle);
        }
        #endregion
        #region 迷你模式下修改窗体大小
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (minMode.Checked)
                switch (m.Msg)
                {
                    case 0x0084:
                        base.WndProc(ref m);
                        Point vPoint = new Point((int)m.LParam & 0xFFFF,
                            (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (vPoint.X <= 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else m.Result = (IntPtr)HTLEFT;
                        else if (vPoint.X >= ClientSize.Width - 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPRIGHT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                            else m.Result = (IntPtr)HTRIGHT;
                        else if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOP;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOM;
                        break;
                    case 0x0201:
                        Point point = Control.MousePosition;
                        point = PointToClient(point);
                        if (point.X < this.Width - 100 && point.Y < 30)
                        {
                            m.Msg = 0x00A1;
                            m.LParam = IntPtr.Zero;
                            m.WParam = new IntPtr(2);
                        }

                        base.WndProc(ref m);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            else base.WndProc(ref m);
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }
        private void LoadConfig()
        {
            if (File.Exists(ConfigPath))
            {
                var items = JsonConvert.DeserializeObject<List<CryptoItem>>(File.ReadAllText(ConfigPath));
                foreach (var item in items)
                {
                    appendItem(item, true);
                }
            }
        }
        private void SaveConfig()
        {
            var itemList = Workers.Select(c => c.Value.CryptoItem).ToList();
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(itemList));
        }

        private void appendItem(CryptoItem item, bool fromConfig = false)
        {
            if (item != null)
            {
                var listItem = new ListViewItem();
                var key = item.Key;
                listItem.UseItemStyleForSubItems = false;
                listItem.Text = key;
                listItem.SubItems.Add(item.Price.ToString(), Color.Red, Color.Transparent, null);
                listItem.SubItems.Add((item.RefreshInterval / 1000).ToString() + "秒");
                listItem.SubItems.Add("...");
                listItem.Tag = item;
                mainList.Items.Add(listItem);
                StartWorker(key, listItem, item);
                if (!fromConfig)
                {
                    SaveConfig();
                }
            }
        }
        private void list_add_Click(object sender, EventArgs e)
        {
            appendItem(ItemEdit.Edit());
        }

        private void list_modify_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count > 0)
            {
                var listItem = mainList.SelectedItems[0];
                var newItem = ItemEdit.Edit(listItem.Tag as CryptoItem);
                if (newItem != null)
                {
                    var key = newItem.Key;
                    listItem.Text = key;
                    listItem.SubItems[1].Text = newItem.Price.ToString();
                    listItem.SubItems[2].Text = (newItem.RefreshInterval / 1000).ToString() + "秒";
                    listItem.Tag = newItem;
                    StartWorker(key, listItem, newItem);
                    SaveConfig();
                }
            }
        }

        private void StartWorker(string key, ListViewItem binding, CryptoItem item)
        {
            RemoveWorker(key);
            var worker = new Worker() { Binding = binding, CryptoItem = item, NotifyIcon = notifyIcon };
            Workers.Add(key, worker);
            worker.StartWork();
        }

        private void RemoveWorker(string key)
        {
            if (Workers.ContainsKey(key))
            {
                Workers[key].Dispose();
                Workers.Remove(key);
            }
        }

        private void list_delete_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count > 0)
            {
                var listItem = mainList.SelectedItems[0];
                var item = listItem.Tag as CryptoItem;
                RemoveWorker($"{item.CybermoneyName.ToUpper()}/{item.CurrencyName.ToUpper()}");
                mainList.Items.Remove(listItem);
                SaveConfig();
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void topMode_Click(object sender, EventArgs e)
        {
            TopMost = topMode.Checked;
        }
        private void minMode_Click(object sender, EventArgs e)
        {
            if (mainList.Items.Count == 0)
            {
                minMode.Checked = false;
                var dialogResult = MessageBox.Show("请至少添加一个币种后再启动迷你模式。\r\n是否立即添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    list_add_Click(sender, e);
                }
                return;
            }
            if (minMode.Checked)
            {
                FormBorderStyle = FormBorderStyle.None;
                AllowTransparency = true;
                ShowInTaskbar = false;
                refreshInterval.Width = 0;
                workerStatus.Width = 0;
                mainList.HeaderStyle = ColumnHeaderStyle.None;
                mainList.View = View.Tile;
                Opacity = 0.7;
            }
            else
            {
                winlock.Checked = mousetransparent.Checked = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                AllowTransparency = false;
                ShowInTaskbar = true;
                mainList.HeaderStyle = ColumnHeaderStyle.Clickable;
                mainList.View = View.Details;
                refreshInterval.Width = 100;
                workerStatus.Width = 200;
                Opacity = 1;
            }
            winlock.Enabled = mousetransparent.Enabled = minMode.Checked;
        }

        private void mousetransparent_CheckedChanged(object sender, EventArgs e)
        {
            if (mousetransparent.Enabled)
                SetPenetrate(mousetransparent.Checked);
        }

        private void mainList_SizeChanged(object sender, EventArgs e)
        {
            if (mainList.Width < 94)
                mainList.TileSize = new Size(mainList.Width - 6, mainList.TileSize.Height);
            else
                mainList.TileSize = new Size(100, mainList.TileSize.Height);
        }
    }
}
