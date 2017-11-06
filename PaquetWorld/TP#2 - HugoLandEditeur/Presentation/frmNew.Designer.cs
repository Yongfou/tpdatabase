namespace HugoLandEditeur
{
    partial class frmNew
    {
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbdata = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(10, 18);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(96, 27);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width (tiles):";
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(10, 46);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(86, 27);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height (tiles):";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(124, 18);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(120, 22);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "32";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(124, 46);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(120, 22);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "32";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(58, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Tile";
            // 
            // cmbdata
            // 
            this.cmbdata.FormattingEnabled = true;
            this.cmbdata.Location = new System.Drawing.Point(124, 77);
            this.cmbdata.Name = "cmbdata";
            this.cmbdata.Size = new System.Drawing.Size(121, 24);
            this.cmbdata.TabIndex = 7;
            // 
            // frmNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(266, 155);
            this.Controls.Add(this.cmbdata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbdata;
    }
}