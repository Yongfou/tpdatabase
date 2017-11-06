namespace HugoLandEditeur
{
    partial class ValidSave
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Si vous étes sur de sauvegarder entrer un nom au monde :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(41, 97);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Sauvegarder";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(165, 97);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(102, 23);
            this.btnAnnuler.TabIndex = 2;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(41, 66);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(226, 22);
            this.txtNom.TabIndex = 3;
            // 
            // ValidSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 150);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidSave";
            this.Text = "Sauvegarder";
            this.Load += new System.EventHandler(this.ValidSave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtNom;
    }
}