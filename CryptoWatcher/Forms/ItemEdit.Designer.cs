
namespace CryptoWatcher.Forms
{
    partial class ItemEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cybermoneyName = new System.Windows.Forms.TextBox();
            this.currencyName = new System.Windows.Forms.TextBox();
            this.refreshInterval = new System.Windows.Forms.NumericUpDown();
            this.saveBtn = new System.Windows.Forms.Button();
            this.alertList = new System.Windows.Forms.ListView();
            this.jugerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pricePoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alert_add = new System.Windows.Forms.ToolStripMenuItem();
            this.alert_del = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).BeginInit();
            this.menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "虚拟币:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "法币:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "监测频率(秒):";
            // 
            // cybermoneyName
            // 
            this.cybermoneyName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cybermoneyName.Location = new System.Drawing.Point(118, 17);
            this.cybermoneyName.Name = "cybermoneyName";
            this.cybermoneyName.Size = new System.Drawing.Size(120, 21);
            this.cybermoneyName.TabIndex = 3;
            // 
            // currencyName
            // 
            this.currencyName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.currencyName.Location = new System.Drawing.Point(118, 49);
            this.currencyName.Name = "currencyName";
            this.currencyName.Size = new System.Drawing.Size(120, 21);
            this.currencyName.TabIndex = 4;
            this.currencyName.Text = "usdt";
            // 
            // refreshInterval
            // 
            this.refreshInterval.Location = new System.Drawing.Point(118, 82);
            this.refreshInterval.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.refreshInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.refreshInterval.Name = "refreshInterval";
            this.refreshInterval.Size = new System.Drawing.Size(120, 21);
            this.refreshInterval.TabIndex = 6;
            this.refreshInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(253, 17);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(98, 86);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // alertList
            // 
            this.alertList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.jugerType,
            this.pricePoint});
            this.alertList.ContextMenuStrip = this.menu1;
            this.alertList.Cursor = System.Windows.Forms.Cursors.Default;
            this.alertList.FullRowSelect = true;
            this.alertList.HideSelection = false;
            this.alertList.Location = new System.Drawing.Point(31, 114);
            this.alertList.Name = "alertList";
            this.alertList.Size = new System.Drawing.Size(320, 296);
            this.alertList.TabIndex = 8;
            this.alertList.UseCompatibleStateImageBehavior = false;
            this.alertList.View = System.Windows.Forms.View.Details;
            // 
            // jugerType
            // 
            this.jugerType.Text = "判断类型";
            this.jugerType.Width = 130;
            // 
            // pricePoint
            // 
            this.pricePoint.Text = "价位";
            this.pricePoint.Width = 140;
            // 
            // menu1
            // 
            this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alert_add,
            this.alert_del});
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(101, 48);
            // 
            // alert_add
            // 
            this.alert_add.Name = "alert_add";
            this.alert_add.Size = new System.Drawing.Size(100, 22);
            this.alert_add.Text = "添加";
            this.alert_add.Click += new System.EventHandler(this.alert_add_Click);
            // 
            // alert_del
            // 
            this.alert_del.Name = "alert_del";
            this.alert_del.Size = new System.Drawing.Size(100, 22);
            this.alert_del.Text = "删除";
            this.alert_del.Click += new System.EventHandler(this.alert_del_Click);
            // 
            // ItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 422);
            this.Controls.Add(this.alertList);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.refreshInterval);
            this.Controls.Add(this.currencyName);
            this.Controls.Add(this.cybermoneyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(395, 461);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 158);
            this.Name = "ItemEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑项";
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).EndInit();
            this.menu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cybermoneyName;
        private System.Windows.Forms.TextBox currencyName;
        private System.Windows.Forms.NumericUpDown refreshInterval;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ListView alertList;
        private System.Windows.Forms.ColumnHeader jugerType;
        private System.Windows.Forms.ColumnHeader pricePoint;
        private System.Windows.Forms.ContextMenuStrip menu1;
        private System.Windows.Forms.ToolStripMenuItem alert_add;
        private System.Windows.Forms.ToolStripMenuItem alert_del;
    }
}