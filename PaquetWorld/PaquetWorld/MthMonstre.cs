using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthMonstre
    {
        public static Random _rnd;
        const int NIVEAUMIN = 1;
        const int NIVEAUMAX = 11;
        const int DMGMINMIN = 1;
        const int DMGMINMAX = 4;
        const int DMGMAXMIN = 5;
        const int DMGMAXMAX = 10;
        const int PVMIN = 3;
        const int PVMAX = 10;

        #region Méthodes

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description : Méthode qui créé un monstre 
        /// </summary>
        /// <param name="sNom">Variable qui prend le nom </param>
        /// <param name="iPosX">Variable qui prend le position vertivcale (x) du monstre</param>
        /// <param name="iPosY">Variable qui prend le position horizontale (y) du monstre</param>
        /// <param name="iIdMonde">Variable qui prend l'id du monde</param>
        /// <param name="iIdImage">Varaible qui prend l'id de l'image du monstre</param>
        public static void CreerMonstre(string sNom, int iPosX, int iPosY, int iIdMonde, int iIdImage)
        {
            _rnd = new Random();
            int iCoefficient = _rnd.Next(0, 101);
            int iLevel = _rnd.Next(NIVEAUMIN, NIVEAUMAX);
            int iDmgMax = _rnd.Next(DMGMAXMIN, DMGMAXMAX);
            int iDmgMin = _rnd.Next(DMGMINMIN, DMGMINMAX);
            int iPV = _rnd.Next(PVMIN, PVMAX);
            using (Entities context = new Entities())
            {
                try
                {
                    Monde md = context.Mondes.First(m => m.Id == iIdMonde);
                    Monstre ms = new Monstre();
                    ms.Nom = sNom;
                    ms.Niveau = iLevel;
                    ms.x = iPosX;
                    ms.y = iPosY;
                    ms.ImageId = iIdImage;
                    ms.MondeId = iIdMonde;
                    ms.StatPV = (int)(iLevel * iPV);
                    if (ms.StatPV >= 8 * iLevel)
                    {
                        ms.StatDmgMin = iDmgMin;
                        ms.StatDmgMax = iDmgMax;
                    }
                    else if (ms.StatPV >= 6 * iLevel && ms.StatPV < 8 * iLevel)
                    {
                        ms.StatDmgMin = (int)((iDmgMin * 0.5) + iDmgMin);
                        ms.StatDmgMax = (int)((iDmgMax * 0.5) + iDmgMax);
                    }
                    else
                    {
                        ms.StatDmgMin = (int)((iDmgMin * 0.7) + iDmgMin) + 1;
                        ms.StatDmgMax = (int)((iDmgMax * 0.7) + iDmgMax) + 1;
                    }
                    context.Monstres.Add(ms);
                    context.SaveChanges();
                    //MessageBox.Show("Le monstre à bien été créé", "Création réussi");


                }
                catch (Exception e)
                {
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Description: Méthode qui supprime un monstre.
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="iIdMonstre">Variable qui prend l'id du monstre à tuer</param>
        /// 
        public static void SupprimerMonstre(int iIdMonstre)
        {
            using(Entities context = new Entities())
            {
                try
                {
                    Monstre ms = context.Monstres.Find(iIdMonstre);
                    context.Monstres.Remove(ms);
                    context.SaveChanges();
                    //MessageBox.Show("Le monstre à bien été suprimé", "Supression réussi");

                }
                catch (Exception e)
                {
                    if (e.HResult == -2147467261)
                    {
                        MessageBox.Show("l'id (" + iIdMonstre + ") du monstre n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Description: Cette méthode modifie le caractéristique d'un monstre 
        /// Date:27-09-2017
        /// </summary>
        /// <param name="iIdMonstre">Variable qui prend le l'id du monstre à modifier</param>
        /// <param name="sNom">Variable qui prend le nouveau nom du monstre</param>
        /// <param name="iNiveau">Variable qui prend le nouveau niveau du monstre</param>
        /// <param name="iPosX">Variable qui prend la nouvelle position verticale du monstre</param>
        /// <param name="iPosY">Variable qui prend la nouvelle position Horizontale du monstre</param>
        /// <param name="iPV">Variable qui prend les nouveau point de vie du monstre</param>
        /// <param name="iDmgMin">Variable qui prend le nouveau dommage minimum du monstre</param>
        /// <param name="iDmgMax">Variable qui prend le nouveau dommage maximim du monstre</param>
        /// <param name="iIdImage">Variable qui prend le nouveau id de l'image du monstre</param>
        public static void ModifierMonstre(int iIdMonstre, string sNom, int iNiveau, int iPosX, int iPosY, int iPV , int iDmgMin, int iDmgMax, int iIdImage,int iIdmonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Monstre ms = context.Monstres.Find(iIdMonstre);
                    ms.Nom = sNom;
                    ms.Niveau = iNiveau;
                    ms.x = iPosX;
                    ms.y = iPosY;
                    ms.StatPV = iPV;
                    ms.StatDmgMin = iDmgMin;
                    ms.StatDmgMax = iDmgMax;
                    ms.ImageId = iIdImage;
                    Monde m = context.Mondes.Find(iIdmonde);
                    ms.MondeId = iIdmonde;
                    context.SaveChanges();

                    //MessageBox.Show("Le monstre "+ iIdMonstre+" à bien été modifié", "Modification réussi");


                }
                catch (Exception e)
                {
                    if (e.HResult == -2147467261)
                    {
                        MessageBox.Show("l'id (" + iIdMonstre + ") du monstre n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (e.HResult == -2146233087)
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
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui supprime tous les mondtre d'un monde
        /// Date:23-10-2017
        /// </summary>
        /// <param name="IdMonde"></param>
        public static void SupprimerTousMonstreMonde(int IdMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    var req = context.Monstres.Where(i => i.MondeId == IdMonde);
                    foreach (Monstre i in req)
                    {
                        context.Monstres.Remove(i);
                    }
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Auteur: Sébastien PAquet
        /// Description: Méthode qui liste tous les monnstre d'un monde
        /// Date:23-10-2017
        /// </summary>
        /// <param name="idMOnde"></param>
        /// <returns></returns>
        public static List<Monstre> ListeMonstres(int idMOnde)
        {
            List<Monstre> liste = new List<Monstre>();
            using (Entities context = new Entities())
            {
                try
                {
                    var req = context.Monstres.Where(o => o.MondeId == idMOnde);
                    foreach (Monstre m in req)
                    {
                        liste.Add(m);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return liste;
        }
        #endregion
    }
}
