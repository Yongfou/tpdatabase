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
using System.Data.SqlClient;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur:Sébastien PAquet
    /// Description: Programme qui permet de se connecter en tant qu'administrateur
    /// Date:23-10-2017
    /// </summary>
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)// type 1 = admin
        {
            if(PaquetWorld.MthCompteJoueur.Connexion(txtNomUtilisateur.Text, txtMotPasse.Text) == "SUCCESS")
            {
                if (PaquetWorld.MthCompteJoueur.LoginJoueur(txtNomUtilisateur.Text) == true)
                {
                    frmMain fr = new frmMain();
                    this.Hide();

                    fr.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Votre compte d'utilisateur n'est pas un compte administrateur", "Compte invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Votre compte d'utilisateur n'exite pas ou votre mot de passe est invalide", "Échec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtMotPasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnOk_Click(sender, e);

            }
        }
    }
}
