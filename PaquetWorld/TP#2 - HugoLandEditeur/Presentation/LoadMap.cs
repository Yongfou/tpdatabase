using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaquetWorld;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur:Sébastien Paquet
    /// Description: Programme qui demnade quelle map qui doit être charger
    /// Date:23-10-2017
    /// </summary>
    public partial class LoadMap : Form
    {
        public int IdMonde { get; set; }

        public LoadMap()
        {
            InitializeComponent();
            using(Entities context = new Entities())
            {
                var req = context.Mondes;
                foreach(Monde m in req)
                {
                    string sNom = m.Description;
                    cmbMonde.Items.Add(sNom);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(Entities context = new Entities())
            {
                PaquetWorld.Monde monde = context.Mondes.First(m => m.Description == cmbMonde.Text);
                StaticClass.TileData = monde.PathTile;
                StaticClass.TileCSV = monde.PathCsv;
                StaticClass.TileBase =(int)monde.DefaultTile;
                StaticClass.SizeTileHeight =(int)monde.SizeTile;
                StaticClass.SizeTileWidth = (int)monde.SizeTile;
                IdMonde = monde.Id;
            }
        }
    }
}
