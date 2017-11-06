using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur:Sébastien Paquet
    /// Description: Programme qui permet de créer de nouveau tile
    /// Date: 23-10-2017
    /// </summary>
    public partial class CreateurCSV : Form
    {
        private Bitmap m_TileSource;
        private Rectangle rectangle;
        private List<TileCreateur> ListeTile = new List<TileCreateur>();
        string AllTile = "gamedata\\alltile.txt";
        string PathCSV = "";
        string sPathTile = "";
        string PathCSVSans = "";
        string PathTileSans = "";
        string sPathJson;
        string PathJsonsSans;
        int IDtile = 0;
        int X = 0;
        int Y = 0;
        int PosX = 0;
        int PosY = 0;
        int TaileTile = 32;
        int Nb = 1;
 
        public CreateurCSV()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description: Crée l'image du tile
        /// Date: 23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picboxTile_Paint(object sender, PaintEventArgs e)
        {
            rectangle = new Rectangle(0, 0, picboxTile.Width, picboxTile.Height);
            if (m_TileSource != null)
                e.Graphics.DrawImage(m_TileSource, rectangle, X, Y, TaileTile, TaileTile, GraphicsUnit.Pixel);
        }
       
        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description:Événement qui prend selon le créateur un image de tile
        /// Date:23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParcourir_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Sélectionner un Tile";
            ofd.Filter = "*.*|*.*|JPG|*.jpg|PNG|*.png";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Faire chemin pour Visual stydio
                if (sPathTile != @"gamedata\"+ ofd.FileName || sPathTile == "")
                {
                    sPathTile = @"gamedata\" + Path.GetFileName(ofd.FileName);
                    PathTileSans = "gamedata\\"+Path.GetFileName(ofd.FileName);
                    txtPathJson.Text = "";
                    PathJsonsSans = Path.GetFileName(ofd.FileName);
                }
                txtPath.Text = sPathTile;
                m_TileSource = new Bitmap(@ofd.FileName);
                picboxTile.Refresh();
                txtPathJson.Enabled = true;
                btnPathJason.Enabled = true;
                lblnote.Visible = true;
                lbljson.Visible = true;
                txtPath.Visible = true;
                btnPathJason.Visible = true;
            }
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description:Événement qui montre le précédan tile et sauvegarde le suivant
        /// Date:23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Save();
            if (X >= 0 && Y >= 0)
            {
               
                PosTile(false);
                picboxTile.Refresh();

                if (IDtile > 0)
                {
                    IDtile--;
                    Nb--;

                }
                EffacerTxt();
                AfficherTile(IDtile);
            }

        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Événemnt qui montre le prochain taile et sauvegarde celui d'avant
        /// Date :23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            Save();
            
            int id = (m_TileSource.Height / TaileTile) * (m_TileSource.Width / TaileTile);
            if ((IDtile +1) <= (id - 1))
            {
                PosTile(true);
                picboxTile.Refresh();
                IDtile++;
                Nb++;
                EffacerTxt();
                AfficherTile(IDtile);
            }
               
        }

        /// <summary>
        /// AUteur: Sébastien Paquet
        /// Description: Événement qui prend le fichier json du créateur ou en cré eun nouveau
        /// Date:23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPathJson.Text == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Sélectionner un *.json";
                ofd.Filter = "*.*|*.*|JSON|*.json";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sPathJson = "gamedata\\" + Path.GetFileName(ofd.FileName);
                    txtPathJson.Text = sPathJson;
                    PathCSV = "gamedata\\" + PathJsonsSans.Substring(0,PathJsonsSans.Length - 4);
                    PathCSV += ".csv";

                    PathCSVSans = PathJsonsSans.Substring(0, PathJsonsSans.Length - 4);
                    PathCSVSans += ".csv";
                    LireJson();
                    AfficherTile(IDtile);

                }
            }
            else if (txtPathJson.Text == "New")
            {

                if (!File.Exists(sPathJson))
                {
                    sPathJson ="gamedata\\" + PathJsonsSans.Substring(0, PathJsonsSans.Length - 4);
                    PathCSV = "gamedata\\" + PathJsonsSans.Substring(0, PathJsonsSans.Length - 4);
                    sPathJson += ".json";
                    PathCSV += ".csv";
                    PathCSVSans = PathJsonsSans.Substring(0, PathJsonsSans.Length - 4);
                    PathCSVSans += ".csv";
                    using (StreamWriter sw = File.CreateText(sPathJson)) { }
                    using (StreamWriter sw = File.CreateText(PathCSV)) { }
                    txtPathJson.Text = sPathJson;
                    AfficherTile(IDtile);

                }
                else
                {
                    sPathJson = txtPathJson.Text;
                    LireJson();
                    AfficherTile(IDtile);

                }
            }


        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Événement  qui crée la le fichier Json et csv
        /// Date:23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsaudliste_Click(object sender, EventArgs e)
        {
            if (sPathJson != "")
            {
                StreamWriter fichierSortant = new StreamWriter(sPathJson);
                string sJson = JsonConvert.SerializeObject(ListeTile);
                fichierSortant.WriteLine(sJson);
                fichierSortant.Flush();
                fichierSortant.Close();

                StreamWriter fichiersortantcsv = new StreamWriter(PathCSV);

                foreach (TileCreateur t in ListeTile)
                {
                    string tile = t.Nom + "," + t.ID + "," + t.CategorieTexte + "," + t.Path + "," + t.Colonne + "," + t.Ligne + "," + t.Transparent + "," + t.Frame.ToString() + "," + t.Fermer + "," + t.VieCouleur + "," + t.TypeTexte;
                    fichiersortantcsv.WriteLine(tile, true);
                    fichiersortantcsv.Flush();

                }
                fichiersortantcsv.Close();

            }
            else
                MessageBox.Show("Choisir un fichier jason");

        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description : Événement qui crée le nom et les statisque automatiquement d'un tile
        /// Date: 23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorie.Text == "Door" || cmbCategorie.Text == "Key")
            {
                txtNom.Text = "Porte" + Nb;
                lblcouleur.Enabled = true;
                cmbcouleur.Enabled = true;
                cmbType.Text = "Objet";

            }

            else if (cmbCategorie.Text == "Character")
            {
                txtNom.Text = "Monstre" +Nb;
                lblvie.Enabled = true;
                txtVie.Enabled = true;

                lblcouleur.Enabled = false;
                cmbcouleur.Enabled = false;
                cmbType.Text = "Monstre";
                chkClose.Checked = false;
                chkTransparent.Checked = true;

            }
            else if(cmbCategorie.Text == "Normal")
            {
                txtNom.Text = "Objet" + Nb;
                cmbType.Text = "Objet";

            }
            else
            {
                lblcouleur.Enabled = false;
                cmbcouleur.Enabled = false;
                lblvie.Enabled = false;
                txtVie.Enabled = false;
            }

        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Événement qui crée le fichier txt pour stock le Fichier des tiles
        /// Auteur: 23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTile_Click(object sender, EventArgs e)
        {
            StreamWriter fichierSortant = new StreamWriter(AllTile,true);
            string sPhrase = sPathTile +"," + PathCSV; 
            fichierSortant.WriteLine(sPhrase);
            fichierSortant.Flush();
            fichierSortant.Close();

        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description : Événement qui dertermine la grandeur des tiles
        /// Date:23-10-2017
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaileTile = Convert.ToInt32(cmbTaileTile.Text);
            picboxTile.Refresh();
        }

        #region Méthodes


        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui permet de sauvegarder un Tile existant ou un nouveau
        /// Date: 23-10-2017
        /// </summary>
        public void Save()
        {
            TileCreateur t = ListeTile.Find(c => c.ID == IDtile);
            if (t != null)
            {
                t.Nom = txtNom.Text;
                t.ID = IDtile;
                if (cmbcouleur.Enabled == true)
                {
                    t.VieCouleur = cmbcouleur.Text;
                }
                else if (txtVie.Enabled == true)
                {
                    t.VieCouleur = txtVie.Text;
                }
                t.Path = sPathTile;
                t.Ligne = PosY;
                t.Colonne = PosX;
                t.Frame = Convert.ToInt32(txtFrame.Text);
                t.CategorieTexte = cmbCategorie.Text;
                t.TypeTexte = cmbType.Text;

                if (t.type == TileCreateur.Type.Monstre)
                {
                    t.VieCouleur = txtVie.Text;
                }
                if (t.categorie == TileCreateur.Categorie.Door || t.categorie == TileCreateur.Categorie.Key)
                {
                    t.VieCouleur = cmbcouleur.Text;
                }

                if (cmbType.Text == "Objet")
                {
                    t.type = TileCreateur.Type.Objet;
                }
                else if (cmbType.Text == "Monstre")
                {
                    t.type = TileCreateur.Type.Monstre;
                }
                else if (cmbType.Text == "Item")
                {
                    t.type = TileCreateur.Type.Item;
                }

                if (chkClose.Checked == true)
                {
                    t.Fermer = "Block";
                }
                else
                {
                    t.Fermer = "Open";
                }
                if (chkTransparent.Checked == true)
                {
                    t.Transparent = "Y";
                }
                else
                {
                    t.Transparent = "N";

                }
            }
            else
            {
                TileCreateur tile = new TileCreateur();
                tile.Nom = txtNom.Text;
                tile.ID = IDtile;
                if (cmbcouleur.Enabled == true)
                {
                    tile.VieCouleur = cmbcouleur.Text;
                }
                else if (txtVie.Enabled == true)
                {
                    tile.VieCouleur = txtVie.Text;
                }
                tile.Path = sPathTile;
                tile.Ligne = PosY;
                tile.Colonne = PosX;
                tile.Frame = Convert.ToInt32(txtFrame.Text);
                tile.CategorieTexte = cmbCategorie.Text;
                tile.TypeTexte = cmbType.Text;

                if (tile.type == TileCreateur.Type.Monstre)
                {
                    tile.VieCouleur = txtVie.Text;
                }
                if (tile.categorie == TileCreateur.Categorie.Door || tile.categorie == TileCreateur.Categorie.Key)
                {
                    tile.VieCouleur = cmbcouleur.Text;
                }

                if (cmbType.Text == "Objet")
                {
                    tile.type = TileCreateur.Type.Objet;
                }
                else if (cmbType.Text == "Monstre")
                {
                    tile.type = TileCreateur.Type.Monstre;
                }
                else if (cmbType.Text == "Item")
                {
                    tile.type = TileCreateur.Type.Item;
                }

                if (chkClose.Checked == true)
                {
                    tile.Fermer = "Block";
                }
                else
                {
                    tile.Fermer = "Open";
                }
                if (chkTransparent.Checked == true)
                {
                    tile.Transparent = "Y";
                }
                else
                {
                    tile.Transparent = "N";

                }
                ListeTile.Add(tile);
                chkSave.Checked = true;

            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui permet de déterminer la position d'un tile selon sa ligne et sa colonne
        /// Date:23-10-2017
        /// </summary>
        /// <param name="bpositif"></param>
        public void PosTile(bool bpositif)
        {
            if (bpositif == true)
            {
                if (X >= 0 && Y <= m_TileSource.Height - TaileTile)
                {
                    if (X < m_TileSource.Width - TaileTile)
                    {
                        X += TaileTile;

                    }
                    else
                    {
                        Y += TaileTile;
                        X = 0;
                    }
                }
            }
            else
            {
                if (Y > 0)
                {
                    if (X >= TaileTile)
                    {
                        X -= TaileTile;
                    }
                    else
                    {
                        Y -= TaileTile;
                        X = m_TileSource.Width - TaileTile;
                    }
                }
                else
                {
                    if (X >= TaileTile)
                    {
                        X -= TaileTile;

                    }
                }
            }
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Méthode qui efface tous l'affichagede la form
        /// Date:23-10-2017
        /// </summary>
        public void EffacerTxt()
        {
            txtNom.Text = null;
            cmbCategorie.Text = null;
            txtPathview.Text = null;
            txtLigne.Text = null;
            txtColone.Text = null;
            txtFrame.Text = 1.ToString();
            txtVie.Text = null;
            cmbType.Text = null;
            cmbcouleur.Text = null;
            chkClose.Checked = true;
            chkTransparent.Checked = false;

        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui calcule le nombre de tile horizontale et verticale
        /// Date:23-10-2017
        /// </summary>
        public void CalculeXY()
        {
            PosX = (X / TaileTile) + 1;
            PosY = (Y / TaileTile) + 1;
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui lit le fichier json
        /// Date:23-10-2017
        /// </summary>
        public void LireJson()
        {
            StreamReader fichierEntrant = new StreamReader(sPathJson);

            string sLigne = "";

            sLigne = fichierEntrant.ReadToEnd();

            fichierEntrant.Close();
            if (sLigne != "")
            {
                ListeTile = JsonConvert.DeserializeObject<List<TileCreateur>>(sLigne);

            }

        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description:Méthode qui affiche dans la vue
        /// Date:23-10-2017
        /// </summary>
        /// <param name="iId"></param>
        public void AfficherTile(int iId)
        {
            if (ListeTile != null && IDtile < ListeTile.Count())
            {
                CalculeXY();
                txtNom.Text = ListeTile[iId].Nom;
                txtID.Text = IDtile.ToString(); ;
                cmbCategorie.Text = ListeTile[iId].CategorieTexte;
                if (cmbcouleur.Enabled == true)
                    cmbcouleur.Text = ListeTile[iId].VieCouleur;
                if (txtVie.Enabled == true)
                    txtVie.Text = ListeTile[iId].VieCouleur;
                txtPathview.Text = ListeTile[iId].Path;
                txtLigne.Text = PosY.ToString();
                txtColone.Text = PosX.ToString();
                txtFrame.Text = ListeTile[iId].Frame.ToString();

                cmbType.Text = ListeTile[iId].type.ToString();
                if (ListeTile[iId].Fermer == "Block")
                {
                    chkClose.Checked = true;
                }
                else
                {
                    chkClose.Checked = false;
                }
                if (ListeTile[iId].Transparent == "Y")
                {
                    chkTransparent.Checked = true;
                }
                else
                {
                    chkTransparent.Checked = false;
                }

            }
            else
            {
                CalculeXY();
                cmbCategorie.Text = "Normal";
                txtID.Text = IDtile.ToString();
                txtLigne.Text = PosY.ToString();
                txtColone.Text = PosX.ToString();
                txtPathview.Text = PathTileSans;

            }
            try
            {
                var req = ListeTile.First(c => c.ID == IDtile);
                if (req != null)
                {
                    chkSave.Checked = true;
                }

            }
            catch
            {
                chkSave.Checked = false;
            }

        }
        #endregion



    }
}

