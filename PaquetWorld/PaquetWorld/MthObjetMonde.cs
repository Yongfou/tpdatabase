using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthObjetMonde
    {
        #region Méthodes

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Descriion:Méthode qui créé un nouveau objet monde
        /// Date:22-09-2017
        /// </summary>
        /// <param name="sDescription">Variable qui prend la descripton de l'objet monde</param>
        /// <param name="iPosX">Variable qui prend la position horizontale(x) de l'objet dans le monde</param>
        /// <param name="iPosY">Variable qui prend la position verticale(y) de l'objet dans le monde</param>
        /// <param name="iTypeObjet">Variable qui prend le type de l'objet monde</param>
        /// <param name="iIdmonde">Variable qui prend l'id du monde dans lequel l'objet monde est intégré</param>
        public static void CreerObjetMonde(string sDescription, int iPosX, int iPosY, int iTypeObjet, int iIdmonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    Monde md1 = context.Mondes.First(md => md.Id == iIdmonde);
                    ObjetMonde obm1 = new ObjetMonde();
                    obm1.Description = sDescription;
                    obm1.x = iPosX;
                    obm1.y = iPosY;
                    obm1.MondeId = iIdmonde;
                    obm1.TypeObjet = iTypeObjet;
                    context.ObjetMondes.Add(obm1);
                    context.SaveChanges();
                    //MessageBox.Show("L'objet du monde à bien été créé", "Création réussi");

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
        /// Description:Méthode qui supprime un objet monde
        /// </summary>
        /// <param name="iIdObjetMonde">Varaiable qui prend l'id de l'objet monde</param>
        public static void SupprimerObjetMonde(int iIdObjetMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    ObjetMonde obm1 = context.ObjetMondes.First(obm => obm.Id == iIdObjetMonde);
                    context.ObjetMondes.Remove(obm1);
                    context.SaveChanges();
                    //MessageBox.Show("L'objet monde id (" + iIdObjetMonde + ") a été supprimer", "Suppression réussi");

                }
                catch (Exception e)
                {
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdObjetMonde + ") de l'objet monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Descriion:Méthode qui modifie la description de l'objet monde
        /// Date:22-09-2017
        /// </summary>
        /// <param name="sDescription">Variable qui prend la descripton de l'objet monde</param>
        /// <param name="iIdObjetMonde">Varaible qui prend l'id de l'objet monde</param>
        public static void ModifierObjetMonde(string sDescription, int iIdObjetMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    ObjetMonde obm1 = context.ObjetMondes.First(obm => obm.Id == iIdObjetMonde);
                    obm1.Description = sDescription;
                    context.SaveChanges();
                    //MessageBox.Show("L'objet monde id (" + iIdObjetMonde + ") a été modifié.", "Modification réussi");

                }
                catch (Exception e)
                {
                    if (e.HResult == -2146233079)
                    {
                        MessageBox.Show("l'id (" + iIdObjetMonde + ") de l'objet monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Auteur:Sébastien PAquet
        /// Description:Liste tous les objet d'un monde
        /// Date:23-10-2017
        /// </summary>
        /// <param name="idMOnde"></param>
        /// <returns></returns>
        public static List<ObjetMonde> ListeObjetMonde (int idMOnde)
        {
            List<ObjetMonde> liste = new List<ObjetMonde>();
            using(Entities context = new Entities())
            {
                try
                {
                    var req = context.ObjetMondes.Where(o => o.MondeId == idMOnde);
                    foreach(ObjetMonde om in req)
                    {
                        liste.Add(om);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return liste;
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Supprime tous les objet d'un monde
        /// Date:23-10-2017
        /// </summary>
        /// <param name="IdMonde"></param>
        public static void SupprimerTousMondeobjetMonde(int IdMonde)
        {
            using (Entities context = new Entities())
            {
                try
                {
                    var req = context.ObjetMondes.Where(i => i.MondeId == IdMonde);
                    foreach (ObjetMonde i in req)
                    {
                        context.ObjetMondes.Remove(i);
                    }
                    context.SaveChanges();

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
