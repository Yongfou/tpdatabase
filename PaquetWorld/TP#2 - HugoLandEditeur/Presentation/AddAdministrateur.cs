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
    /// Description: Forme qui permet de promuvoir un joueur en administrateur seulement par un autre administrateur;
    /// Date: 23-10-2017
    /// </summary>
    public partial class AddAdministrateur : Form
    {
        private Entities _context = new Entities();
        private List<CompteJoueur> listeCompteJoueur;
        public AddAdministrateur()
        {
            InitializeComponent();
            listeCompteJoueur = _context.CompteJoueurs.ToList();
            compteJoueurBindingSource.DataSource = listeCompteJoueur;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CompteJoueur c = compteJoueurBindingSource.Current as CompteJoueur;
            c.TypeUtilisateur = 1;
            _context.SaveChanges();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
