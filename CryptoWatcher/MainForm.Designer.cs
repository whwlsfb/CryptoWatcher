
namespace CryptoWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topMode = new System.Windows.Forms.ToolStripMenuItem();
            this.minMode = new System.Windows.Forms.ToolStripMenuItem();
            this.winlock = new System.Windows.Forms.ToolStripMenuItem();
            this.mousetransparent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainList = new System.Windows.Forms.ListView();
            this.cacName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshInterval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.list_add = new System.Windows.Forms.ToolStripMenuItem();
            this.list_modify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.list_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.iconMenu.SuspendLayout();
            this.listMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.iconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "CryptoWatcher";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // iconMenu
            // 
            this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMode,
            this.minMode,
            this.toolStripSeparator2,
            this.exit_btn});
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(149, 76);
            // 
            // topMode
            // 
            this.topMode.CheckOnClick = true;
            this.topMode.Name = "topMode";
            this.topMode.Size = new System.Drawing.Size(148, 22);
            this.topMode.Text = "窗口总在最前";
            this.topMode.Click += new System.EventHandler(this.topMode_Click);
            // 
            // minMode
            // 
            this.minMode.CheckOnClick = true;
            this.minMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.winlock,
            this.mousetransparent});
            this.minMode.Name = "minMode";
            this.minMode.Size = new System.Drawing.Size(148, 22);
            this.minMode.Text = "迷你模式";
            this.minMode.Click += new System.EventHandler(this.minMode_Click);
            // 
            // winlock
            // 
            this.winlock.CheckOnClick = true;
            this.winlock.Enabled = false;
            this.winlock.Name = "winlock";
            this.winlock.Size = new System.Drawing.Size(124, 22);
            this.winlock.Text = "锁定位置";
            // 
            // mousetransparent
            // 
            this.mousetransparent.CheckOnClick = true;
            this.mousetransparent.Enabled = false;
            this.mousetransparent.Name = "mousetransparent";
            this.mousetransparent.Size = new System.Drawing.Size(124, 22);
            this.mousetransparent.Text = "鼠标穿透";
            this.mousetransparent.CheckedChanged += new System.EventHandler(this.mousetransparent_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // exit_btn
            // 
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(148, 22);
            this.exit_btn.Text = "退出";
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // mainList
            // 
            this.mainList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cacName,
            this.currentPrice,
            this.refreshInterval,
            this.workerStatus});
            this.mainList.ContextMenuStrip = this.listMenu;
            this.mainList.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainList.FullRowSelect = true;
            this.mainList.HideSelection = false;
            this.mainList.Location = new System.Drawing.Point(13, 13);
            this.mainList.Name = "mainList";
            this.mainList.Size = new System.Drawing.Size(669, 349);
            this.mainList.TabIndex = 0;
            this.mainList.TileSize = new System.Drawing.Size(100, 28);
            this.mainList.UseCompatibleStateImageBehavior = false;
            this.mainList.View = System.Windows.Forms.View.Details;
            this.mainList.SizeChanged += new System.EventHandler(this.mainList_SizeChanged);
            // 
            // cacName
            // 
            this.cacName.Text = "币币类型";
            this.cacName.Width = 120;
            // 
            // currentPrice
            // 
            this.currentPrice.Text = "现价";
            this.currentPrice.Width = 200;
            // 
            // refreshInterval
            // 
            this.refreshInterval.Text = "刷新频率";
            this.refreshInterval.Width = 100;
            // 
            // workerStatus
            // 
            this.workerStatus.Text = "状态";
            this.workerStatus.Width = 200;
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.list_add,
            this.list_modify,
            this.toolStripSeparator1,
            this.list_delete});
            this.listMenu.Name = "listMenu";
            this.listMenu.Size = new System.Drawing.Size(101, 76);
            // 
            // list_add
            // 
            this.list_add.Name = "list_add";
            this.list_add.Size = new System.Drawing.Size(100, 22);
            this.list_add.Text = "添加";
            this.list_add.Click += new System.EventHandler(this.list_add_Click);
            // 
            // list_modify
            // 
            this.list_modify.Name = "list_modify";
            this.list_modify.Size = new System.Drawing.Size(100, 22);
            this.list_modify.Text = "修改";
            this.list_modify.Click += new System.EventHandler(this.list_modify_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // list_delete
            // 
            this.list_delete.Name = "list_delete";
            this.list_delete.Size = new System.Drawing.Size(100, 22);
            this.list_delete.Text = "删除";
            this.list_delete.Click += new System.EventHandler(this.list_delete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 374);
            this.Controls.Add(this.mainList);
            this.Name = "MainForm";
            this.Text = "虚拟货币价格监视器";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
            this.iconMenu.ResumeLayout(false);
            this.listMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListView mainList;
        private System.Windows.Forms.ColumnHeader cacName;
        private System.Windows.Forms.ColumnHeader currentPrice;
        private System.Windows.Forms.ColumnHeader refreshInterval;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem list_add;
        private System.Windows.Forms.ToolStripMenuItem list_modify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem list_delete;
        private System.Windows.Forms.ColumnHeader workerStatus;
        private System.Windows.Forms.ContextMenuStrip iconMenu;
        private System.Windows.Forms.ToolStripMenuItem topMode;
        private System.Windows.Forms.ToolStripMenuItem minMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exit_btn;
        private System.Windows.Forms.ToolStripMenuItem winlock;
        private System.Windows.Forms.ToolStripMenuItem mousetransparent;
    }
}

