namespace zeus_mud_wpf_client.dialog.Item
{
    partial class frmBag
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
            this.bagPanel1 = new zeus_mud_wpf_client.dialog.Item.BagPanel();
            this.SuspendLayout();
            // 
            // bagPanel1
            // 
            this.bagPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bagPanel1.Location = new System.Drawing.Point(0, 0);
            this.bagPanel1.Name = "bagPanel1";
            this.bagPanel1.Size = new System.Drawing.Size(528, 351);
            this.bagPanel1.TabIndex = 0;
            // 
            // frmBag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 351);
            this.Controls.Add(this.bagPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBag";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "我的背包";
            this.Load += new System.EventHandler(this.frmBag_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BagPanel bagPanel1;
    }
}