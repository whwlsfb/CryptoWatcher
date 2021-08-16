
namespace CryptoWatcher.Forms
{
    partial class AlertEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.jugerType = new System.Windows.Forms.ComboBox();
            this.pricePoint = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当价格                         时通知我.";
            // 
            // jugerType
            // 
            this.jugerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jugerType.FormattingEnabled = true;
            this.jugerType.Items.AddRange(new object[] {
            "大于",
            "小于",
            "等于"});
            this.jugerType.Location = new System.Drawing.Point(69, 23);
            this.jugerType.Name = "jugerType";
            this.jugerType.Size = new System.Drawing.Size(56, 20);
            this.jugerType.TabIndex = 1;
            // 
            // pricePoint
            // 
            this.pricePoint.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pricePoint.Location = new System.Drawing.Point(131, 22);
            this.pricePoint.Name = "pricePoint";
            this.pricePoint.Size = new System.Drawing.Size(79, 21);
            this.pricePoint.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(278, 21);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AlertEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 61);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.pricePoint);
            this.Controls.Add(this.jugerType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(402, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(402, 100);
            this.Name = "AlertEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑提醒项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox jugerType;
        private System.Windows.Forms.TextBox pricePoint;
        private System.Windows.Forms.Button saveBtn;
    }
}