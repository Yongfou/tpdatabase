using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace PaquetWorld
{
    public static class MthCompteJoueur
    {
        private static string _message;
        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description:Méthode qui créé un compte joueur
        /// Date:27-09-2017
        /// </summary>
        /// <param name="sNomUtilisateur">Variable qui prend le nom d'utilisateur</param>
        /// <param name="sCourriel">Variable qui prend le courriel du joueur</param>
        /// <param name="sPrenom">Variable qui prend le prénom du joueur</param>
        /// <param name="sNom">Variable qui prend le nom du joueur</param>
        /// <param name="iTypeUtilisateur">Variable qui prend le  type d'utilisateur du joueur</param>
        /// <param name="sMotPasse">Variable qui prend le mot de passe du joueur</param>
        /// <returns></returns>
        public static string CreerCompteJoueur(string sNomUtilisateur, string sCourriel, string sPrenom, string sNom,int iTypeUtilisateur,string sMotPasse)
        {
            string smessage = "";
            using (Entities context = new Entities())
            {
                try
                {
                    var req = context.CompteJoueurs.First(m => m.NomJoueur == sNomUtilisateur);
                    smessage = "Le nom d'utilisateur du joueur existe déjà";
                    
                }
                catch(Exception e)
                {
                    if(e.HResult == -2146233079)
                    {
                        ADO d = new ADO();
                        d.Connecter();
                        d.cmd.Parameters.Clear();
                        d.cmd.CommandType = CommandType.StoredProcedure;
                        d.cmd.CommandText = "CreerCompteJoueur";
                        d.cmd.Parameters.Add("@pNomUtilisateur", SqlDbType.NVarChar, 50).Value = sNomUtilisateur;
                        d.cmd.Parameters.Add("@pCourriel", SqlDbType.NVarChar, 255).Value = sCourriel;
                        d.cmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 50).Value = sPrenom;
                        d.cmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 50).Value = sNom;
                        d.cmd.Parameters.Add("@pTypeUtilisateur", SqlDbType.Int).Value = iTypeUtilisateur;
                        d.cmd.Parameters.Add("@pMotDePasse", SqlDbType.NVarChar, 50).Value = sMotPasse;
                        SqlParameter message = new SqlParameter("@Message", SqlDbType.NVarChar, 255);
                        message.Direction = ParameterDirection.Output;
                        d.cmd.Parameters.Add(message);
                        d.cmd.Connection = d.con;
                        d.cmd.ExecuteNonQuery();
                        d.Deconnecter();
                        smessage = message.Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }

                
            }
                       
            return smessage;
        }
        public static string Connexion(string sNomUtilisateur, string sMotPasse)
        {

            ADO d = new ADO();
            d.Connecter();
            d.cmd.Parameters.Clear();
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "Connexion";
            d.cmd.Parameters.Add("@pNomJoueur", SqlDbType.NVarChar, 50).Value = sNomUtilisateur;            
            d.cmd.Parameters.Add("@pMotDePasse", SqlDbType.NVarChar, 50).Value = sMotPasse;
            SqlParameter message = new SqlParameter("@Message", SqlDbType.NVarChar, 255);
            message.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(message);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();
            _message = message.Value.ToString();
            return message.Value.ToString();
        }

        public static bool LoginJoueur(string sNom)
        {
            bool bAdmin = false;
            using (Entities context = new Entities())
            {
                    CompteJoueur cj = context.CompteJoueurs.First(c => c.NomJoueur == sNom);
                    if (cj.TypeUtilisateur == 1)
                    {
                        bAdmin = true;
                    }                
            }

            return bAdmin;
        }
    }

}
