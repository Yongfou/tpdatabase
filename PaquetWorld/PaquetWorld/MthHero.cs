using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaquetWorld
{
    public static class MthHero
    {
        public static List<ObjetMonde> ListeObjetMonde = new List<ObjetMonde>();
        public static List<Monstre> ListeMonstre = new List<Monstre>();
        public static List<Item> ListeItem = new List<Item>();
        public static List<Hero> ListeHero = new List<Hero>();
        private static List<Hero> ListeHeroJoueur = new List<Hero>();



        #region Méthode

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description:Méthode qui créé un Héro
        /// Date:27-09-2017
        /// </summary>
        /// <param name="iIdCompteJoueur">Variable qui prend l'id du compte joueur du héro</param>
        /// <param name="iIdMonde">Variable qui prend l'id du monde du héro</param>
        /// <param name="iIdClasse">Variable qui prend l'id de la classe du héro</param>
        /// <param name="iNiveau">Variable qui prend le niveau du héro</param>
        /// <param name="iExperience">Variable qui prend l'expérience du héro</param>
        /// <param name="iPosX">Variable qui prend la position verticale du héro dans le monde</param>
        /// <param name="iPosY">Variable qui prend la position horizontale du héro dans le monde</param>
        /// <param name="iStr">Variable qui prend le stat du héro</param>
        /// <param name="iDex">Variable qui prend le stat de la dextérité du héro</param>
        /// <param name="iInt">Variable qui prend le stat de l'intelligence du héro</param>
        /// <param name="iVitalite">Variable qui prend le stat vitalité du héro</param>
        /// <param name="sNom">Variable qui prend le nom du héro</param>
        /// <param name="bConnecter">Variable qui prend booléén qui prend si le héro est connecter</param>
        public static void CreerHero(int iIdCompteJoueur, int iIdMonde, int iIdClasse, int iNiveau, int iExperience, int iPosX, int iPosY, int iStr, int iDex, int iInt, int iVitalite, string sNom, bool bConnecter)
        {
            using (Entities context = new Entities())
            {
                CompteJoueur cj = new CompteJoueur();
                Monde m = new Monde();
                Classe c = new Classe();
                try
                {
                    Hero hr = new Hero();
                    cj = context.CompteJoueurs.Find(iIdCompteJoueur);
                    hr.CompteJoueurId = iIdCompteJoueur;
                    hr.Niveau = iNiveau;
                    hr.Experience = iExperience;
                    hr.x = iPosX;
                    hr.y = iPosY;
                    hr.StatStr = iStr;
                    hr.StatDex = iDex;
                    hr.StatInt = iInt;
                    hr.StatVitalite = iVitalite;
                    m = context.Mondes.Find(iIdMonde);
                    hr.MondeId = iIdMonde;
                    c = context.Classes.Find(iIdClasse);
                    hr.ClasseId = iIdClasse;
                    hr.NomHero = sNom;
                    hr.EstConnecte = bConnecter;
                    context.Heros.Add(hr);
                    context.SaveChanges();
                    MessageBox.Show("Le héro " + sNom + " à bien été créé", "Création réussi");

                }
                catch (Exception e)
                {
                    if (cj == null)
                    {
                        MessageBox.Show("l'id (" + iIdCompteJoueur + ") du Compte joueur n'existe pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (m == null)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") du monde n'existe pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (c == null)
                    {
                        MessageBox.Show("l'id (" + iIdClasse + ") de la classe n'existe pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

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
        /// Description: Méthode qui supprime un héro
        /// Date:27-09-2017
        /// </summary>
        /// <param name="iIdHero">Variable qui prend l'id du héro à supprimer</param>
        public static void SupprimerHero(int iIdHero)
        {
            using(Entities context = new Entities())
            {
                Hero hr = new Hero();
                try
                {
                    hr = context.Heros.Find(iIdHero);
                    context.Heros.Remove(hr);
                    context.SaveChanges();
                    MessageBox.Show("Le héro id (" + iIdHero + ") a été supprimé", "Suppression réussi");


                }
                catch (Exception e)
                {
                    if(hr == null)
                    {
                        MessageBox.Show("l'id (" + iIdHero + ") du hero n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

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
        /// Description:Méthode qui modifie un Héro
        /// Date:27-09-2017
        /// </summary>
        /// <param name="iIdHero">Variable qui prend l'id du héro à modifier</param>
        /// <param name="iIdCompteJoueur">Variable qui prend le nouvelle id du compte joueur du héro</param>
        /// <param name="iIdMonde">Variable qui prend le nouvelle id du monde du héro</param>
        /// <param name="iIdClasse">Variable qui prend le nouvelle id de la classe du héro</param>
        /// <param name="iNiveau">Variable qui prend le nouveau niveau du héro</param>
        /// <param name="iExperience">Variable qui prend la nouvelle expérience du héro</param>
        /// <param name="iPosX">Variable qui prend la nouvelle position verticale du héro dans le monde</param>
        /// <param name="iPosY">Variable qui prend la nouvelle position horizontale du héro dans le monde</param>
        /// <param name="iStr">Variable qui prend le nouveau stat du héro</param>
        /// <param name="iDex">Variable qui prend le nouveau stat de la dextérité du héro</param>
        /// <param name="iInt">Variable qui prend le nouveau stat de l'intelligence du héro</param>
        /// <param name="iVitalite">Variable qui prend nouveau le stat vitalité du héro</param>
        /// <param name="sNom">Variable qui prend le nouveau nom du héro</param>
        /// <param name="bConnecter">Variable qui prend la nouvelle valeur booléén qui dicte si le héro est connecter</param>
        public static void ModifierHero(int iIdHero ,int iIdCompteJoueur, int iIdMonde, int iIdClasse, int iNiveau, int iExperience, int iPosX, int iPosY, int iStr, int iDex, int iInt, int iVitalite, string sNom, bool bConnecter)
        {
            using (Entities context = new Entities())
            {
                CompteJoueur cj = new CompteJoueur();
                Monde m = new Monde();
                Classe c = new Classe();
                Hero hr = new Hero();
                try
                {
                    hr = context.Heros.Find(iIdHero);
                    cj = context.CompteJoueurs.Find(iIdCompteJoueur);
                    hr.CompteJoueurId = iIdCompteJoueur;
                    hr.Niveau = iNiveau;
                    hr.Experience = iExperience;
                    hr.x = iPosX;
                    hr.y = iPosY;
                    hr.StatStr = iStr;
                    hr.StatDex = iDex;
                    hr.StatInt = iInt;
                    hr.StatVitalite = iVitalite;
                    m = context.Mondes.Find(iIdMonde);
                    hr.MondeId = iIdMonde;
                    c = context.Classes.Find(iIdClasse);
                    hr.ClasseId = iIdClasse;
                    hr.NomHero = sNom;
                    hr.EstConnecte = bConnecter;
                    context.SaveChanges();
                    MessageBox.Show("Le héro id ( " + iIdHero + " ) à bien été modifié", "Modification réussi");

                }
                catch (Exception e)
                {
                    if (cj == null)
                    {
                        MessageBox.Show("l'id (" + iIdCompteJoueur + ") du Compte joueur n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (m == null)
                    {
                        MessageBox.Show("l'id (" + iIdMonde + ") du monde n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (c == null)
                    {
                        MessageBox.Show("l'id (" + iIdClasse + ") de la classe n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if(hr== null)
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
        /// Auteur : Sébastien Paquet
        /// Description : Méthode qui prend tous les élément (ObjetMonde, Monstre, Item, Héro) dans un rayon de 200
        /// </summary>
        /// <param name="iIdHero">Variable qui prend l'id du hero</param>
        public static void RayonHero (int iIdHero)
        {
            ListeObjetMonde.Clear();
            ListeMonstre.Clear();
            ListeItem.Clear();
            ListeHero.Clear();

            Hero hr = new Hero();

            using (Entities context = new Entities())
            {
                try
                {
                    hr = context.Heros.Find(iIdHero);
                    var req =  context.ObjetMondes.Where(om => (om.x > (hr.x - 200) && om.x < (hr.x + 200)) &&( om.y > (hr.y - 200) && om.y < (hr.y + 200))&& om.MondeId == hr.MondeId);
                    foreach (ObjetMonde ob in req)
                    {
                        ListeObjetMonde.Add(ob);
                    }

                    var req2 = context.Monstres.Where(m => m.x > (hr.x - 200) && m.x < (hr.x + 200) && m.y > (hr.y - 200) && m.y < (hr.y + 200) && m.MondeId == hr.MondeId);
                    foreach (Monstre m in req2)
                    {
                       ListeMonstre.Add(m);
                    }

                    var req3 = context.Items.Where(i => i.x > (hr.x - 200) && i.x < (hr.x + 200) && i.y > (hr.y - 200) && i.y < (hr.y + 200) && i.MondeId == hr.MondeId);
                    foreach (Item i in req3)
                    {
                        ListeItem.Add(i);
                    }

                    var req4 = context.Heros.Where(h => h.x > (hr.x - 200) && h.x < (hr.x + 200) && h.y > (hr.y - 200) && h.y < (hr.y + 200) && h.MondeId == hr.MondeId && h.Id != hr.Id);
                    foreach (Hero h in req4)
                    {
                        ListeHero.Add(h);
                    }
                 
                }
                catch(Exception e)
                {
                    if( hr == null)
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
        /// Description: Méthode qui liste tous les héro d'un joueur
        /// Date:28-09-2017
        /// </summary>
        /// <param name="iIdCOmpteJoueur">Variable qui prend l'id du compte joueur</param>
        /// <returns></returns>
        public static List<Hero> HeroJoueur(int iIdCOmpteJoueur)
        {
            CompteJoueur cj = new CompteJoueur();
            using (Entities context = new Entities())
            {
                try
                {
                    cj = context.CompteJoueurs.First(c => c.Id == iIdCOmpteJoueur);

                    var req = context.Heros.Where(h => h.CompteJoueurId == iIdCOmpteJoueur);
                    foreach(Hero x in req)
                    {
                        ListeHeroJoueur.Add(x);
                    }
                }
                catch(Exception e)
                {
                    if (cj == null)
                    {
                        MessageBox.Show("l'id (" + iIdCOmpteJoueur + ") du Compte joueur n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            return ListeHeroJoueur;
        }

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description : Méthode qui déplace un héro
        /// Date: 28-09-2017
        /// </summary>
        /// <param name="iIdHero">Variable qui prend l'id du héro</param>
        /// <param name="iPosX">Vaiable qui prend la noi</param>
        /// <param name="iPosY"></param>
        public static void DeplacerHero(int iIdHero, int iPosX, int iPosY)
        {
            Hero hr = new Hero();
            using(Entities context = new Entities())
            {
                try
                {

                    hr = context.Heros.Find(iIdHero);
                    hr.x += iPosX;
                    hr.y += iPosY;
                    context.SaveChanges();

                    MessageBox.Show("L'héro id (" + iIdHero + ") a bien été déplacé", "Déplacement ruéssi");
                }
                catch(Exception e)
                {
                    if (hr == null)
                    {
                        MessageBox.Show("l'id (" + iIdHero + ") du hero n'exite pas", "Id invalide", MessageBoxButton.OK, MessageBoxImage.Error);

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
        /// Description : Méthode qui afficher la liste d'Hero d'un joueur
        /// Date:28-09-2017
        /// </summary>
        public static void AfficherListeHeroJoueur()
        {
            foreach(Hero h in ListeHeroJoueur)
            {
                MainWindow.txttext.AppendText("ID : " + h.Id + " X : " + h.x + " Y : " + h.y + " Expérience : " + h.Experience + " Niveau : " + h.Niveau + " CompteJoueur Id : " + h.CompteJoueurId + " Monde ID :" + h.MondeId + "\n");
            }
        }

        /// <summary>
        /// Auteur : Sébastien Paquet
        /// Description: Métho qui affiche tous se qui est dans un rayon de 200 auteur d'un héro
        /// Date:28-09-2017
        /// </summary>
        public static void AfficherRayonHero()
        {
            foreach (ObjetMonde om in ListeObjetMonde)
            {
                MainWindow.txttext.AppendText("ID : " + om.Id + " X : " + om.x + " Y : " + om.y + " Description : " + om.Description + " Type d'objet : " + om.TypeObjet + " Monde id : " + om.MondeId + "\n");
            }
            foreach (Monstre m in ListeMonstre)
            {
                MainWindow.txttext.AppendText("ID : " + m.Id + " X : " + m.x + " Y : " + m.y + " StatPV : " + m.StatPV + " StatDmgMin : " + m.StatDmgMin + " StstDmgMax : " + m.StatDmgMin + " Monde ID :" + m.MondeId + "\n");
            }
            foreach (Item i in ListeItem)
            {
                MainWindow.txttext.AppendText("ID : " + i.Id + " X : " + i.x + " Y : " + i.y + " Description : " + i.Description + " Hero Id : " + i.IdHero + " Monde ID :" + i.MondeId + "\n");
            }
            foreach (Hero h in ListeHero)
            {
                MainWindow.txttext.AppendText("ID : " + h.Id + " X : " + h.x + " Y : " + h.y + " Expérience : " + h.Experience + " Niveau : " + h.Niveau + " CompteJoueur Id : " + h.CompteJoueurId + " Monde ID :" + h.MondeId + "\n");
            }
        }

        #endregion
    }
}
