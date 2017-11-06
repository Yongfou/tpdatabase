namespace HugoLandEditeur
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lblNomUtilisateur = new System.Windows.Forms.Label();
            this.txtNomUtilisateur = new System.Windows.Forms.TextBox();
            this.lblMotPasse = new System.Windows.Forms.Label();
            this.txtMotPasse = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomUtilisateur
            // 
            this.lblNomUtilisateur.AutoSize = true;
            this.lblNomUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUtilisateur.Location = new System.Drawing.Point(12, 9);
            this.lblNomUtilisateur.Name = "lblNomUtilisateur";
            this.lblNomUtilisateur.Size = new System.Drawing.Size(207, 18);
            this.lblNomUtilisateur.TabIndex = 0;
            this.lblNomUtilisateur.Text = "Entrez votre nom d\'utilisateur :";
            // 
            // txtNomUtilisateur
            // 
            this.txtNomUtilisateur.Location = new System.Drawing.Point(15, 29);
            this.txtNomUtilisateur.Name = "txtNomUtilisateur";
            this.txtNomUtilisateur.Size = new System.Drawing.Size(197, 22);
            this.txtNomUtilisateur.TabIndex = 1;
            // 
            // lblMotPasse
            // 
            this.lblMotPasse.AutoSize = true;
            this.lblMotPasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotPasse.Location = new System.Drawing.Point(12, 54);
            this.lblMotPasse.Name = "lblMotPasse";
            this.lblMotPasse.Size = new System.Drawing.Size(190, 18);
            this.lblMotPasse.TabIndex = 2;
            this.lblMotPasse.Text = "Entrez votre mot de passe :";
            // 
            // txtMotPasse
            // 
            this.txtMotPasse.Location = new System.Drawing.Point(15, 74);
            this.txtMotPasse.Name = "txtMotPasse";
            this.txtMotPasse.PasswordChar = '*';
            this.txtMotPasse.Size = new System.Drawing.Size(197, 22);
            this.txtMotPasse.TabIndex = 3;
            this.txtMotPasse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMotPasse_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(137, 102);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(75, 23);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 139);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMotPasse);
            this.Controls.Add(this.lblMotPasse);
            this.Controls.Add(this.txtNomUtilisateur);
            this.Controls.Add(this.lblNomUtilisateur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identification ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomUtilisateur;
        private System.Windows.Forms.TextBox txtNomUtilisateur;
        private System.Windows.Forms.Label lblMotPasse;
        private System.Windows.Forms.TextBox txtMotPasse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnQuitter;
    }
}