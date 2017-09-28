using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
     public static class MthClasse
    {
        #region Méthodes

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Méthode qui créé une classe
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="sNomClasse">Variable qui prend le nom de la classe</param>
        /// <param name="sDescription">Variable qui prend la description de la classe</param>
        /// <param name="iStr">Variable qui prend le stat de force de la classe</param>
        /// <param name="iDex">Variable qui prend le stat de la destérité de la classe</param>
        /// <param name="iInt">Variable qui prend le stat de l'intelligence de la classe</param>
        /// <param name="iVitalite">Variable qui prend le stat de vitalité de la classe</param>
        /// <param name="iIdMonde">Variable qui prend l'id du monde </param>
        public static void CreerClasse(string sNomClasse, string sDescription, int iStr, int iDex, int iInt, int iVitalite, int iIdMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Monde m = context.Mondes.First(md => md.Id == iIdMonde);
                    Classe c1 = new Classe();
                    c1.NomClasse = sNomClasse;
                    c1.Description = sDescription;
                    c1.StatBaseStr = iStr;
                    c1.StatBaseDex = iDex;
                    c1.StatBaseInt = iInt;
                    c1.StatBaseVitalite = iVitalite;
                    c1.MondeId = iIdMonde;
                    context.Classes.Add(c1);
                    context.SaveChanges();
                    MessageBox.Show("La classe " + sNomClasse + " à bien été créé", "Création réussi");

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
        /// Auteur:Sébastien Paquet
        /// Description: Méthode qui supprime une classe
        /// Date:27-09-2017
        /// </summary>
        /// <param name="iIdClasse">Variable qui prend l'id de la classe</param>
        public static void SupprimerClasse(int iIdClasse)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Classe c1 = context.Classes.First(c => c.Id == iIdClasse);
                    context.Classes.Remove(c1);
                    context.SaveChanges();
                    MessageBox.Show("La classe id (" + iIdClasse + ") a été supprimé", "Suppression réussi");

                }
                catch (Exception e)
                {
                    if(e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdClasse + ") de la classe n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Description:Méthode qui modifie une classe
        /// Date:27-09-2017
        /// </summary>
        /// <param name="sNomClasse">Variable qui prend le nouveau nom de la classe</param>
        /// <param name="sDescription">Variable qui prend la nouvelle description</param>
        /// <param name="iStr">Variable qui prend le nouveau stat de force</param>
        /// <param name="iDex">Variable qui prend le nouveau stat de dextérité</param>
        /// <param name="iInt">Variable qui prend le nouveau stat d'intelligence</param>
        /// <param name="iVitalite">Variable qui prend le nouveau stat de vitalité</param>
        /// <param name="iIdMonde">Variable qui prend le nouvau id du monde</param>
        /// <param name="iIdClasse">Variable qui prend l'id de la classe</param>
        public static void ModifierClasse(int iIdClasse, string sNomClasse, string sDescription, int iStr, int iDex, int iInt, int iVitalite, int iIdMonde)
        {
            using (Entities context = new Entities())
            {
                Monde m = new Monde();
                Classe c = new Classe();
                try
                {
                    c = context.Classes.Find(iIdClasse);
                    c.NomClasse = sNomClasse;
                    c.Description = sDescription;
                    c.StatBaseStr = iStr;
                    c.StatBaseDex = iDex;
                    c.StatBaseInt = iInt;
                    c.StatBaseVitalite = iVitalite;
                    m = context.Mondes.Find(iIdMonde);
                    c.MondeId = m.Id;
                    context.SaveChanges();
                    MessageBox.Show("La classe id: (" + iIdClasse + " nom : "+ sNomClasse + ") a été modifier", "Modification réussi");


                }
                catch (Exception e)
                {
                    if (c == null)
                    {
                        MessageBox.Show("l'id (" + iIdClasse + ") de la classe n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (m == null)
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



        #endregion

    }
}
