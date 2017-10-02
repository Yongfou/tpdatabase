using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthEffetItem
    {

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description : Ajouter un effet d'item
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="iIdItem">Variable qui prend l'id de l'item</param>
        /// <param name="iValeurEffet">Variable qui prend la valeur de l'effet</param>
        /// <param name="iTypeEffet">Variable qui prend le type de l'effet de l'item</param>
        public static void AjouterEffetItem(int iIdItem, int iValeurEffet, int iTypeEffet)
        {
            Item i = new Item();
            using(Entities context = new Entities())
            {
                try
                {
                    i = context.Items.Find(iIdItem);
                    EffetItem ef = new EffetItem();
                    ef.ItemId = i.Id;
                    ef.ValeurEffet = iValeurEffet;
                    ef.TypeEffet = iTypeEffet;
                    context.EffetItems.Add(ef);
                    context.SaveChanges();
                    MessageBox.Show("L'Effet d'item a bien été créé", "Création réussi");

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
        /// Auteur: Sébastien Paquet
        /// Description : Supprimer effet d'item
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="iIdEffetItem"></param>       
        public static void SupprimerEffetItem(int iIdEffetItem)
        {
            EffetItem ef = new EffetItem();
            using(Entities context = new Entities())
            {
                try
                {
                    ef = context.EffetItems.Find(iIdEffetItem);
                    context.EffetItems.Remove(ef);
                    context.SaveChanges();
                    MessageBox.Show("L'effet d'item id ("+ iIdEffetItem +") à bien été suprimé", "Supression réussi");

                }
                catch (Exception e)
                {
                    if (ef == null)
                    {
                        MessageBox.Show("l'id (" + iIdEffetItem + ") de l'effet d'item n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Description : Modifier les effets d'item
        /// Date: 27-09-2017
        /// </summary>
        /// <param name="iIdEffetItem">Variable qui prend l'id de l'effet item </param>
        /// <param name="iIdItem">Variable qui prend l"id de l'item</param>
        /// <param name="iValeurEffet">Variable qui prend la valeur de l'effet</param>
        /// <param name="iTypeEffet">Variable qui prend le typre de l'effet</param>
        public static void ModifierEffetItem(int iIdEffetItem, int iIdItem, int iValeurEffet, int iTypeEffet)
        {
            EffetItem ef = new EffetItem();
            Item it = new Item();
            using(Entities context = new Entities())
            {
                try
                {
                    it = context.Items.First(i => i.Id == iIdItem);
                    ef = context.EffetItems.Find(iIdEffetItem);
                    ef.ItemId = it.Id;
                    ef.ValeurEffet = iValeurEffet;
                    ef.TypeEffet = iTypeEffet;
                    context.SaveChanges();
                    MessageBox.Show("L'effet d'item id (" + iIdEffetItem + ") à bien été Modifier", "Modification réussi");

                }
                catch (Exception e)
                {
                    if (ef == null)
                    {
                        MessageBox.Show("l'id (" + iIdEffetItem + ") de l'effet d'item n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (e.HResult == -2146233079)
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

    }
}
