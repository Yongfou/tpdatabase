namespace HugoLandEditeur
{
    partial class CreateurCSV
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
            this.cmbcouleur = new System.Windows.Forms.ComboBox();
            this.lblcouleur = new System.Windows.Forms.Label();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.btnsaudliste = new System.Windows.Forms.Button();
            this.lblnote = new System.Windows.Forms.Label();
            this.lbljson = new System.Windows.Forms.Label();
            this.btnPathJason = new System.Windows.Forms.Button();
            this.txtPathJson = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtVie = new System.Windows.Forms.TextBox();
            this.lblvie = new System.Windows.Forms.Label();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.lblfermer = new System.Windows.Forms.Label();
            this.txtFrame = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTransparent = new System.Windows.Forms.CheckBox();
            this.txtColone = new System.Windows.Forms.TextBox();
            this.lblColone = new System.Windows.Forms.Label();
            this.txtLigne = new System.Windows.Forms.TextBox();
            this.lblLigneImage = new System.Windows.Forms.Label();
            this.txtPathview = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblCatégorie = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picboxTile = new System.Windows.Forms.PictureBox();
            this.btnAddTile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTaileTile = new System.Windows.Forms.ComboBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxTile)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbcouleur
            // 
            this.cmbcouleur.Enabled = false;
            this.cmbcouleur.FormattingEnabled = true;
            this.cmbcouleur.Items.AddRange(new object[] {
            "Rouge",
            "Rose",
            "Gris",
            "Bleu",
            "Brun",
            "Vert"});
            this.cmbcouleur.Location = new System.Drawing.Point(225, 328);
            this.cmbcouleur.Name = "cmbcouleur";
            this.cmbcouleur.Size = new System.Drawing.Size(180, 24);
            this.cmbcouleur.TabIndex = 73;
            // 
            // lblcouleur
            // 
            this.lblcouleur.AutoSize = true;
            this.lblcouleur.Enabled = false;
            this.lblcouleur.Location = new System.Drawing.Point(128, 331);
            this.lblcouleur.Name = "lblcouleur";
            this.lblcouleur.Size = new System.Drawing.Size(57, 17);
            this.lblcouleur.TabIndex = 72;
            this.lblcouleur.Text = "Couleur";
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Items.AddRange(new object[] {
            "Normal",
            "Treasure",
            "Key",
            "Food",
            "Door",
            "Potion",
            "Character"});
            this.cmbCategorie.Location = new System.Drawing.Point(225, 128);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(180, 24);
            this.cmbCategorie.TabIndex = 71;
            this.cmbCategorie.SelectedIndexChanged += new System.EventHandler(this.cmbCategorie_SelectedIndexChanged);
            // 
            // btnsaudliste
            // 
            this.btnsaudliste.Location = new System.Drawing.Point(84, 458);
            this.btnsaudliste.Name = "btnsaudliste";
            this.btnsaudliste.Size = new System.Drawing.Size(321, 23);
            this.btnsaudliste.TabIndex = 70;
            this.btnsaudliste.Text = "Creation *.CSV et *.JSON";
            this.btnsaudliste.UseVisualStyleBackColor = true;
            this.btnsaudliste.Click += new System.EventHandler(this.btnsaudliste_Click);
            // 
            // lblnote
            // 
            this.lblnote.Location = new System.Drawing.Point(12, 92);
            this.lblnote.Name = "lblnote";
            this.lblnote.Size = new System.Drawing.Size(100, 55);
            this.lblnote.TabIndex = 69;
            this.lblnote.Text = "* SI nouveau fichier, ecrire New";
            this.lblnote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbljson
            // 
            this.lbljson.Location = new System.Drawing.Point(12, 40);
            this.lbljson.Name = "lbljson";
            this.lbljson.Size = new System.Drawing.Size(106, 36);
            this.lbljson.TabIndex = 68;
            this.lbljson.Text = "Choisir fichier : (*.json)";
            this.lbljson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPathJason
            // 
            this.btnPathJason.Enabled = false;
            this.btnPathJason.Location = new System.Drawing.Point(330, 35);
            this.btnPathJason.Name = "btnPathJason";
            this.btnPathJason.Size = new System.Drawing.Size(75, 23);
            this.btnPathJason.TabIndex = 67;
            this.btnPathJason.Text = "Parcourir";
            this.btnPathJason.UseVisualStyleBackColor = true;
            this.btnPathJason.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPathJson
            // 
            this.txtPathJson.Enabled = false;
            this.txtPathJson.Location = new System.Drawing.Point(131, 36);
            this.txtPathJson.Name = "txtPathJson";
            this.txtPathJson.Size = new System.Drawing.Size(181, 22);
            this.txtPathJson.TabIndex = 66;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(84, 426);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(103, 23);
            this.btnPreview.TabIndex = 64;
            this.btnPreview.Text = "Précèdent";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(302, 426);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(103, 23);
            this.btnNext.TabIndex = 63;
            this.btnNext.Text = "Suivant";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Objet",
            "Monstre",
            "Item"});
            this.cmbType.Location = new System.Drawing.Point(225, 269);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 61;
            // 
            // txtVie
            // 
            this.txtVie.Enabled = false;
            this.txtVie.Location = new System.Drawing.Point(225, 300);
            this.txtVie.Name = "txtVie";
            this.txtVie.Size = new System.Drawing.Size(180, 22);
            this.txtVie.TabIndex = 60;
            // 
            // lblvie
            // 
            this.lblvie.AutoSize = true;
            this.lblvie.Enabled = false;
            this.lblvie.Location = new System.Drawing.Point(128, 303);
            this.lblvie.Name = "lblvie";
            this.lblvie.Size = new System.Drawing.Size(32, 17);
            this.lblvie.TabIndex = 59;
            this.lblvie.Text = "Vie ";
            // 
            // chkClose
            // 
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Location = new System.Drawing.Point(265, 363);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(18, 17);
            this.chkClose.TabIndex = 58;
            this.chkClose.UseVisualStyleBackColor = true;
            // 
            // lblfermer
            // 
            this.lblfermer.AutoSize = true;
            this.lblfermer.Location = new System.Drawing.Point(128, 363);
            this.lblfermer.Name = "lblfermer";
            this.lblfermer.Size = new System.Drawing.Size(53, 17);
            this.lblfermer.TabIndex = 57;
            this.lblfermer.Text = "Fermer";
            // 
            // txtFrame
            // 
            this.txtFrame.Location = new System.Drawing.Point(225, 241);
            this.txtFrame.Name = "txtFrame";
            this.txtFrame.Size = new System.Drawing.Size(55, 22);
            this.txtFrame.TabIndex = 56;
            this.txtFrame.Text = "1";
            this.txtFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "Frame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Transparent :";
            // 
            // chkTransparent
            // 
            this.chkTransparent.AutoSize = true;
            this.chkTransparent.Location = new System.Drawing.Point(265, 392);
            this.chkTransparent.Name = "chkTransparent";
            this.chkTransparent.Size = new System.Drawing.Size(18, 17);
            this.chkTransparent.TabIndex = 53;
            this.chkTransparent.UseVisualStyleBackColor = true;
            // 
            // txtColone
            // 
            this.txtColone.Location = new System.Drawing.Point(225, 213);
            this.txtColone.Name = "txtColone";
            this.txtColone.ReadOnly = true;
            this.txtColone.Size = new System.Drawing.Size(55, 22);
            this.txtColone.TabIndex = 52;
            this.txtColone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblColone
            // 
            this.lblColone.AutoSize = true;
            this.lblColone.Location = new System.Drawing.Point(128, 216);
            this.lblColone.Name = "lblColone";
            this.lblColone.Size = new System.Drawing.Size(68, 17);
            this.lblColone.TabIndex = 51;
            this.lblColone.Text = "Colonne :";
            // 
            // txtLigne
            // 
            this.txtLigne.Location = new System.Drawing.Point(225, 185);
            this.txtLigne.Name = "txtLigne";
            this.txtLigne.ReadOnly = true;
            this.txtLigne.Size = new System.Drawing.Size(55, 22);
            this.txtLigne.TabIndex = 50;
            this.txtLigne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLigneImage
            // 
            this.lblLigneImage.AutoSize = true;
            this.lblLigneImage.Location = new System.Drawing.Point(128, 188);
            this.lblLigneImage.Name = "lblLigneImage";
            this.lblLigneImage.Size = new System.Drawing.Size(51, 17);
            this.lblLigneImage.TabIndex = 49;
            this.lblLigneImage.Text = "Ligne :";
            // 
            // txtPathview
            // 
            this.txtPathview.Location = new System.Drawing.Point(225, 156);
            this.txtPathview.Name = "txtPathview";
            this.txtPathview.ReadOnly = true;
            this.txtPathview.Size = new System.Drawing.Size(180, 22);
            this.txtPathview.TabIndex = 48;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(128, 159);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(45, 17);
            this.lblPath.TabIndex = 47;
            this.lblPath.Text = "Path :";
            // 
            // lblCatégorie
            // 
            this.lblCatégorie.AutoSize = true;
            this.lblCatégorie.Location = new System.Drawing.Point(128, 131);
            this.lblCatégorie.Name = "lblCatégorie";
            this.lblCatégorie.Size = new System.Drawing.Size(69, 17);
            this.lblCatégorie.TabIndex = 46;
            this.lblCatégorie.Text = "Catégorie";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(225, 99);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(55, 22);
            this.txtID.TabIndex = 45;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(128, 102);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(29, 17);
            this.lblId.TabIndex = 44;
            this.lblId.Text = "ID :";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(225, 71);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(180, 22);
            this.txtNom.TabIndex = 43;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(128, 74);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(45, 17);
            this.lblNom.TabIndex = 42;
            this.lblNom.Text = "Nom :";
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(330, 8);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(75, 23);
            this.btnParcourir.TabIndex = 41;
            this.btnParcourir.Text = "Parcourir";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.btnParcourir_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(131, 9);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(181, 22);
            this.txtPath.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Choisir un Tile :";
            // 
            // picboxTile
            // 
            this.picboxTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxTile.Location = new System.Drawing.Point(12, 167);
            this.picboxTile.Name = "picboxTile";
            this.picboxTile.Size = new System.Drawing.Size(96, 96);
            this.picboxTile.TabIndex = 38;
            this.picboxTile.TabStop = false;
            this.picboxTile.Paint += new System.Windows.Forms.PaintEventHandler(this.picboxTile_Paint);
            // 
            // btnAddTile
            // 
            this.btnAddTile.Location = new System.Drawing.Point(12, 426);
            this.btnAddTile.Name = "btnAddTile";
            this.btnAddTile.Size = new System.Drawing.Size(66, 51);
            this.btnAddTile.TabIndex = 74;
            this.btnAddTile.Text = "Add Tile";
            this.btnAddTile.UseVisualStyleBackColor = true;
            this.btnAddTile.Click += new System.EventHandler(this.btnAddTile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "Taile tile";
            // 
            // cmbTaileTile
            // 
            this.cmbTaileTile.FormattingEnabled = true;
            this.cmbTaileTile.Items.AddRange(new object[] {
            "32",
            "64"});
            this.cmbTaileTile.Location = new System.Drawing.Point(12, 289);
            this.cmbTaileTile.Name = "cmbTaileTile";
            this.cmbTaileTile.Size = new System.Drawing.Size(75, 24);
            this.cmbTaileTile.TabIndex = 76;
            this.cmbTaileTile.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(12, 358);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(62, 21);
            this.chkSave.TabIndex = 77;
            this.chkSave.Text = "Save";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // CreateurCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 489);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.cmbTaileTile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddTile);
            this.Controls.Add(this.cmbcouleur);
            this.Controls.Add(this.lblcouleur);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.btnsaudliste);
            this.Controls.Add(this.lblnote);
            this.Controls.Add(this.lbljson);
            this.Controls.Add(this.btnPathJason);
            this.Controls.Add(this.txtPathJson);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtVie);
            this.Controls.Add(this.lblvie);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.lblfermer);
            this.Controls.Add(this.txtFrame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkTransparent);
            this.Controls.Add(this.txtColone);
            this.Controls.Add(this.lblColone);
            this.Controls.Add(this.txtLigne);
            this.Controls.Add(this.lblLigneImage);
            this.Controls.Add(this.txtPathview);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblCatégorie);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.btnParcourir);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picboxTile);
            this.Name = "CreateurCSV";
            this.Text = "CreateurCSV";
            ((System.ComponentModel.ISupportInitialize)(this.picboxTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbcouleur;
        private System.Windows.Forms.Label lblcouleur;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.Button btnsaudliste;
        private System.Windows.Forms.Label lblnote;
        private System.Windows.Forms.Label lbljson;
        private System.Windows.Forms.Button btnPathJason;
        private System.Windows.Forms.TextBox txtPathJson;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtVie;
        private System.Windows.Forms.Label lblvie;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.Label lblfermer;
        private System.Windows.Forms.TextBox txtFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTransparent;
        private System.Windows.Forms.TextBox txtColone;
        private System.Windows.Forms.Label lblColone;
        private System.Windows.Forms.TextBox txtLigne;
        private System.Windows.Forms.Label lblLigneImage;
        private System.Windows.Forms.TextBox txtPathview;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblCatégorie;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picboxTile;
        private System.Windows.Forms.Button btnAddTile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTaileTile;
        private System.Windows.Forms.CheckBox chkSave;
    }
}