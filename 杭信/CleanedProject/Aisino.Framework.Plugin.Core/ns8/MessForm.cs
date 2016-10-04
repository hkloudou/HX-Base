﻿namespace ns8
{
    using Aisino.Framework.Plugin.Core.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class MessForm : Form
    {
        private IDisposable idisposable_0;
        private AisinoTXT MESS_TXT;
        private AisinoBTN OK_BT;
        private AisinoPIC pictureBox1;

        internal MessForm()
        {
            
            this.InitializeComponent();
        }

        internal MessForm(string string_0)
        {
            
            this.InitializeComponent();
            if (string_0.Length > 20)
            {
                this.MESS_TXT.ScrollBars = ScrollBars.Vertical;
            }
            this.MESS_TXT.Text = string_0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.idisposable_0 != null))
            {
                this.idisposable_0.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.OK_BT = new AisinoBTN();
            this.pictureBox1 = new AisinoPIC();
            this.MESS_TXT = new AisinoTXT();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.OK_BT.Anchor = AnchorStyles.Bottom;
            this.OK_BT.DialogResult = DialogResult.Cancel;
            this.OK_BT.Location = new Point(0xa8, 0x8b);
            this.OK_BT.Name = "OK_BT";
            this.OK_BT.Size = new Size(0x4b, 0x17);
            this.OK_BT.TabIndex = 0;
            this.OK_BT.Text = "确定";
            this.OK_BT.UseVisualStyleBackColor = true;
            this.OK_BT.Click += new EventHandler(this.OK_BT_Click);
            this.pictureBox1.Location = new Point(2, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x70, 0x71);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.MESS_TXT.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.MESS_TXT.BackColor = SystemColors.MenuBar;
            this.MESS_TXT.BorderStyle = BorderStyle.None;
            this.MESS_TXT.Location = new Point(120, 12);
            this.MESS_TXT.Multiline = true;
            this.MESS_TXT.Name = "MESS_TXT";
            this.MESS_TXT.ReadOnly = true;
            this.MESS_TXT.Size = new Size(0x128, 0x71);
            this.MESS_TXT.TabIndex = 3;
            base.AcceptButton = this.OK_BT;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.OK_BT;
            base.CausesValidation = false;
            base.ClientSize = new Size(0x1ac, 0xab);
            base.ControlBox = false;
            base.Controls.Add(this.MESS_TXT);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.OK_BT);
            this.ForeColor = SystemColors.ControlText;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MessForm";
            base.SizeGripStyle = SizeGripStyle.Hide;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "提示信息";
            base.TopMost = true;
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void OK_BT_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }
    }
}

