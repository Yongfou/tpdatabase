using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthItem
    {

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description : Méthode qui créé un item
        /// Date: 28-09-2017
        /// </summary>
        /// <param name="sNom">Variable qui prend la le nom d'un item</param>
        /// <param name="sDescription">Variable qui prend la description d'un objet</param>
        /// <param name="iPosX">Variable qui prend la position vertical de l'item</param>
        /// <param name="iPosY">Variable qui prend la position horizontale de l'item</param>
        /// <param name="iIdMonde">Variable qui prend l'id du monde</param>
        /// <param name="iIdimage">Variable qui prend l'id de l'image</param>
        /// <param name="iIdHero">Variable qui prend l'id du Héro</param>
        public static void CreerItem(string sNom, string sDescription, int iPosX, int iPosY, int iIdMonde, int iIdimage, int iIdHero)
        {
            using (Entities context = new Entities())
            {
                Monde m = new Monde();
                Hero hr = new Hero();
                try
                {
                     m = context.Mondes.Find(iIdMonde);
                    hr = context.Heros.Find(iIdHero);
                    Item i = new Item();
                    i.Nom = sNom;
                    i.Description = sDescription;
                    i.x = iPosX;
                    i.y = iPosY;
                    i.MondeId = m.Id;
                    i.ImageId = iIdimage;
                    i.IdHero = hr.Id;
                    context.Items.Add(i);
                    context.SaveChanges();
                    MessageBox.Show("L'item " + sNom + " à bien été créé", "Création réussi");

                }
                catch (Exception e)
                {
                    if (m == null)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (hr == null)
                    {
                        MessageBox.Show("l'id (" + iIdHero + ") du héro n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Description : Méthode qui supprime un item
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="iIdItem"></param>
        public static void SupprimerItem(int iIdItem)
        {
            Item i = new Item();
            using(Entities context = new Entities())
            {
                try
                {
                    i = context.Items.Find(iIdItem);
                    context.Items.Remove(i);
                    context.SaveChanges();
                    MessageBox.Show("L'objet id (" + iIdItem + ") a été supprimé", "Suppression réussi");

                }
                catch (Exception e)
                {
                    if (i == null)
                    {
                        MessageBox.Show("l'id (" + iIdItem + ") de l'item n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description : Méthode qui modifie la quantité d'item dans le monde
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="sNomItem"> Variable qui prend le nom de l'item</param>
        /// <param name="iIdMonde">Variable qui prend l'id du monde </param>
        /// <param name="iQuantite">Variable qui prend le la quantité a modifier soit ajouter ou a supprimer</param>
        public static void ModifierQuantiteItem(string sNomItem,int iIdMonde, int iQuantite)
        {
            Item i = new Item();
            Monde m = new Monde();
            using (Entities context = new Entities())
            {
                try
                {
                    m = context.Mondes.Find(iIdMonde);
                    i = context.Items.First(itm => itm.MondeId == m.Id && itm.Nom == sNomItem);
                    if (iQuantite > 0)
                    {
                        for (int x = iQuantite; x > 0; x--)
                        {
                            Item it = new Item();
                            it.Nom = i.Nom;
                            it.Description = i.Description;
                            it.x = i.x;
                            it.y = i.y;
                            it.MondeId = i.MondeId;
                            it.ImageId = i.ImageId ;
                            it.IdHero = i.IdHero;
                            context.Items.Add(it);
                            context.SaveChanges();
                        }
                        MessageBox.Show(iQuantite +" "+ sNomItem + " a été créé", "Création réussi");

                    }
                    else if (iQuantite < 0)
                    {
                        for(int y = iQuantite; y <0; y++)
                        {
                            Item item = context.Items.First(itm => itm.MondeId == iIdMonde && itm.Nom == sNomItem);
                            context.Items.Remove(item);
                            context.SaveChanges();

                        }
                        MessageBox.Show(iQuantite +" " + sNomItem + " a été supprimés", "Suppression réussi");

                    }
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    if (i == null)
                    {
                        MessageBox.Show("l'Item (" + sNomItem + ") n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if(m == null)
                    {
                        MessageBox.Show("Id (" + iIdMonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

    }
}
