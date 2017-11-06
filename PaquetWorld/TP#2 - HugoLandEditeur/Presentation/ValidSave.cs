using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur:Sébastien Paquet
    /// Description: Programme qui demande le nom de la sauvegarde de la map
    /// Date:23-10-2017
    /// </summary>
    public partial class ValidSave : Form
    {
        public string Nom { get; set; }
        public bool Txt { get; set; } = true;
        public ValidSave()
        {
            InitializeComponent();
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Nom = txtNom.Text;
           this.DialogResult = DialogResult.OK;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ValidSave_Load(object sender, EventArgs e)
        {
            if (Txt == false)
            {
                txtNom.Enabled = false;
            }
        }
    }
}
