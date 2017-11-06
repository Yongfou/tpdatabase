using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthMonde
    {

        #region Méthodes
        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui crée un monde
        /// Date: 22-09-2017
        /// </summary>
        /// <param name="sDescription">Variable qui prend la description du monde</param>
        /// <param name="iLimiteX">Variable qui prend la grandeur verticale (x) du monde</param>
        /// <param name="iLimiteY">Variable qui prend la grandeur horizontale (y) du monde</param>
        public static int CreerMonde(string sDescription, int iLimiteX, int iLimiteY,string sPathTile,string sPathCSv,int? iDefaultTile,int? iTileSize )
        {
            using (Entities context = new Entities())
            {

                int ID = 0; 
                try
                {
                    Monde md1 = new Monde();
                    md1.Description = sDescription;
                    md1.LimiteX = iLimiteX;
                    md1.LimiteY = iLimiteY;
                    md1.PathTile = sPathTile;
                    md1.PathCsv = sPathCSv;
                    md1.DefaultTile = iDefaultTile;
                    md1.SizeTile = iTileSize;
                    context.Mondes.Add(md1);
                    context.SaveChanges();
                    ID = md1.Id;
                    MessageBox.Show("Monde à bien été créé", "Création réussi");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return ID;
            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui supprime un monde 
        /// Date:22-09-2017
        /// </summary>
        /// <param name="iIdMonde"> Variable qui prend l'id du monde</param>
        public static void SupprimerMonde(int iIdMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Monde md1 = context.Mondes.First(md => md.Id == iIdMonde);
                    context.Mondes.Remove(md1);
                    context.SaveChanges();
                    MessageBox.Show("Le monde id (" + iIdMonde + ") a été supprimé", "Suppression réussi");
                }
                catch (Exception e)
                {
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (e.HResult== -2146233087)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") ne peut pas être supprimer, car il est utillisé par un autre table", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui modifie un monde
        /// Date:22-09-2017
        /// </summary>
        /// <param name="iIdmonde">Variable qui prend le id du monde</param>
        /// <param name="sDescription">Variable qui prend la nouvelle description</param>
        /// <param name="iLimiteX">Variable qui prend la nouvelle limite verticale(x) du monde</param>
        /// <param name="iLimiteY">Variable qui prend la nouvelle limite horizonale(y) du monde</param>
        public static void ModifierMonde(int iIdmonde, string sDescription, int iLimiteX, int iLimiteY)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Monde md1 = context.Mondes.First(md => md.Id == iIdmonde);
                    md1.Description = sDescription;
                    md1.LimiteX = iLimiteX;
                    md1.LimiteY = iLimiteY;
                    context.SaveChanges();
                    MessageBox.Show("Le monde id (" + iIdmonde + ") a été modifier", "Modification réussi");
                }
                catch (Exception e)
                {
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdmonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Métode qui affiche tous les mondes
        /// Date:22-09-2017
        /// </summary>
        public static void AfficherListeMonde()
        {
            using (Entities context = new Entities())
            {
                try
                {
                    var req = context.Mondes.Where(ms => ms.Id >= 0);
                    foreach (Monde md in req)
                    {
                        MainWindow.txttext.AppendText("Id : " + md.Id + "- Description : " + md.Description + "- Limite X : " + md.LimiteX + "- Limite Y : " + md.LimiteY + "\n");

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        #endregion
    }
}
