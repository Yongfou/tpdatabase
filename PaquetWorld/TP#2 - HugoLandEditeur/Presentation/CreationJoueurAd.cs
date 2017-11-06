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
    /// Auteur: Sébastien PAquet
    /// Description: Programme qui crée un nouveau joueur
    /// Date:23-10-2017
    /// </summary>
    public partial class CreationJoueurAd : Form
    {
        public CreationJoueurAd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int iType = 0;
            if (cmbType.Text == "Normal")
            {
                iType = 2;
            }
            else
                iType = 1;

            PaquetWorld.MthCompteJoueur.CreerCompteJoueur(txtNomUtilisateur.Text, txtCourriel.Text, txtPrenom.Text, txtNom.Text, iType, txtMotpasse.Text);
            MessageBox.Show(" Le joueur à bien été créé ");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
