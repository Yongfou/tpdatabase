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
                            it.IdHero = i.Id;
                            context.Items.Add(it);
                            context.SaveChanges();
                        }
                        MessageBox.Show(iQuantite + sNomItem + " a été créé", "Création réussi");

                    }
                    else if (iQuantite < 0)
                    {
                        for(int y = iQuantite; y <0; y++)
                        {
                            Item item = context.Items.First(itm => itm.MondeId == iIdMonde && itm.Nom == sNomItem);
                            context.Items.Remove(item);
                            context.SaveChanges();

                        }
                        MessageBox.Show(iQuantite  + sNomItem + ") a été supprimé", "Suppression réussi");

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
