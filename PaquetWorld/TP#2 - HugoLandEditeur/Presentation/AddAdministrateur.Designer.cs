namespace HugoLandEditeur
{
    partial class AddAdministrateur
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
            this.compteJoueurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compteJoueurComboBox = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.compteJoueurBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // compteJoueurComboBox
            // 
            this.compteJoueurComboBox.DataSource = this.compteJoueurBindingSource;
            this.compteJoueurComboBox.DisplayMember = "NomJoueur";
            this.compteJoueurComboBox.FormattingEnabled = true;
            this.compteJoueurComboBox.Location = new System.Drawing.Point(26, 56);
            this.compteJoueurComboBox.Name = "compteJoueurComboBox";
            this.compteJoueurComboBox.Size = new System.Drawing.Size(300, 24);
            this.compteJoueurComboBox.TabIndex = 1;
            this.compteJoueurComboBox.ValueMember = "NomJoueur";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(39, 96);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(235, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choisissez le compte que vous voulez changer en administrateur :";
            // 
            // AddAdministrateur
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(350, 136);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.compteJoueurComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAdministrateur";
            this.Text = "Changer le type d\'un  compte joueur";
            ((System.ComponentModel.ISupportInitialize)(this.compteJoueurBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource compteJoueurBindingSource;
        private System.Windows.Forms.ComboBox compteJoueurComboBox;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}