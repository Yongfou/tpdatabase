using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaquetWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TextBox txttext = new TextBox();
        public MainWindow()
        {
            InitializeComponent();
            txttext = txtText;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //TestMonde();
            //TestObjetMonde();
            //TestMonstre();
            //TestCompteJoueur();
            //TestClasse();
            //TestHero();
            //TestItem();
            //TestEffetItem();
        }

        #region Méthodes

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui teste les méthode de la classe MthMonde
        /// Date:22-09-2017
        /// </summary>
        public void TestMonde()
        {
            using(Entities context = new Entities())
            {
                MthMonde.CreerMonde("premier", 1000, 1000,"","",0,null);
                Monde md = context.Mondes.First(m=>m.Id > 1080);
                MthMonde.SupprimerMonde(md.Id);
                MthMonde.SupprimerMonde(50);
                Monde md2 = context.Mondes.First();
                MthMonde.ModifierMonde(md2.Id, "Patate", 50, 50);
                MthMonde.ModifierMonde(50, "patate", 50, 50);
                MthMonde.AfficherListeMonde();
            }
           
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description:Méthode qui teste les méthodes de la classe MthObjetMonde
        /// Date:22-09-2017
        /// </summary>
        public void TestObjetMonde()
        {
            using(Entities context = new Entities())
            {
                Monde md = context.Mondes.First();
                MthObjetMonde.CreerObjetMonde("Petite fleur", 200, 200, 3, md.Id);
                MthObjetMonde.CreerObjetMonde("patate", 300, 300, 3, 50);
                ObjetMonde obm = context.ObjetMondes.First();
                MthObjetMonde.SupprimerObjetMonde(obm.Id);
                MthObjetMonde.SupprimerObjetMonde(50);
                ObjetMonde obm2 = context.ObjetMondes.First();
                MthObjetMonde.ModifierObjetMonde("Poil", obm2.Id);
                MthObjetMonde.ModifierObjetMonde("Poil", 50);
            }
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Méthode qui teste toutes les méthodes de la classe MthMonstre
        /// Date:27-09-2017
        /// </summary>
        public void TestMonstre()
        {
            using(Entities context = new Entities())
            {
                Monstre ms = context.Monstres.First();
                MthMonstre.CreerMonstre("Ti_paule", 300, 300, 1080, 0);
                MthMonstre.CreerMonstre("Grou", 100, 100, 50, 0);
                MthMonstre.SupprimerMonstre(ms.Id);
                MthMonstre.SupprimerMonstre(50);
                Monstre ms2 = context.Monstres.First();
                Monde m = context.Mondes.First();
                MthMonstre.ModifierMonstre(ms2.Id, "lili", 15, 8787, 78878, 50, 10, 20, 0,m.Id);
                MthMonstre.ModifierMonstre(50, "lili", 15, 8787, 78878, 50, 10, 20, 0,m.Id);
                MthMonstre.ModifierMonstre(ms2.Id, "lili", 15, 8787, 78878, 50, 10, 20, 0, 50);

            }
        }

        /// <summary>
        /// Auteur:Sébastien Paquet
        /// Description: Méthode qui teste toutes les méthode de la classe MthCompteJoueur
        /// </summary>
        public void TestCompteJoueur()
        {
            //MthCompteJoueur.LoginJoueur("yongfou");
            //MessageBox.Show(MthCompteJoueur.CreerCompteJoueur("yongfou", "s-paquet@hotmail.fr", "Sébastien", "Paquet", 1, "282656347"));
            //MessageBox.Show(MthCompteJoueur.CreerCompteJoueur("yongfou12", "s-paquet@hotmail.fr", "Sébastien", "Paquet", 2, "282656347"));

            //MessageBox.Show(MthCompteJoueur.Connexion("yongfou12", "282656347"));
            //MessageBox.Show(MthCompteJoueur.Connexion("yongfou", "282656347"));
            //using (Entities context = new Entities())
            //{
                //CompteJoueur cpp = context.CompteJoueurs.First(c => c.Id == 1008);
                //context.CompteJoueurs.Remove(cpp);
                //var req = context.CompteJoueurs.Where(m => m.NomJoueur == "yongfou12");
                //foreach (CompteJoueur x in req)
                //{
                //    context.CompteJoueurs.Remove(x);
                //}
            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// Auteur:Sébstien Paquet
        /// Description: Méthode qui teste toutes le méthode de la classe MthClasse
        /// Date:27-09-2017
        /// </summary>
        public void TestClasse()
        {
            using(Entities context = new Entities())
            {
                Monde m1 = context.Mondes.First();

                MthClasse.CreerClasse("chevalier", "paladin", 15, 12, 10, 20, m1.Id);
                MthClasse.CreerClasse("chevalier", "paladin", 15, 12, 10, 20, 50);
                Classe c = context.Classes.First();
                MthClasse.SupprimerClasse(c.Id);
                MthClasse.SupprimerClasse(50);
                MthClasse.ModifierClasse(50, "chevalier", "paladin", 15, 12, 10, 20, m1.Id);
                Classe c2 = context.Classes.First();
                MthClasse.ModifierClasse(c2.Id, "chevalier", "paladin", 15, 12, 10, 20, 50);
                MthClasse.ModifierClasse(c2.Id, "chevalier", "paladin", 15, 12, 10, 20, m1.Id);
                txttext.AppendText("Toutes les classes d'un monde" + "\n");
                foreach (Classe cx in MthClasse.ClasseMonde(79))
                {
                    txttext.AppendText(cx.NomClasse + "\n");
                }
                txttext.AppendText("La classe de paul est " + MthClasse.ClasseHero(1).NomClasse);

            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description : Méthode qui teste toutes les méthodes de la classe mthHero
        /// Date:27-09-2017
        /// </summary>
        public void TestHero()
        {
            using(Entities context = new Entities())
            {
                MthHero.CreerHero(1009, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                MthHero.CreerHero(50, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                MthHero.CreerHero(1009, 1080, 100, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                Hero hr = context.Heros.First(hero => hero.Id != 1);
                MthHero.SupprimerHero(hr.Id);
                MthHero.SupprimerHero(1000);
                Hero hr2 = context.Heros.First(her=> her.Id != 1);
                MthHero.ModifierHero(75, 1009, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                MthHero.ModifierHero(hr2.Id, 50, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                MthHero.ModifierHero(hr2.Id, 1009, 1080, 100, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
                MthHero.ModifierHero(hr2.Id, 1009, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "Ti-groux", true);
                MthHero.RayonHero(1);
                MthHero.AfficherRayonHero();
                foreach (Hero h in MthHero.HeroJoueur(1009))
                {
                    txttext.AppendText(h.NomHero + "\n");
                }
            }
            
           
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description:Méthode qui teste toutes les méthode de la classe mthItem
        /// </summary>
        public void TestItem()
        {
            using(Entities context = new Entities())
            {

                MthItem.CreerItem("Dildo", " sa vibre", 15, 15, 1080, 0);
                MthItem.CreerItem("chat", "noir", 15, 15, 1080, 0);
                MthItem.CreerItem("Carte", "plate", 15, 15, 0, 1);
                MthItem.CreerItem("Carte", "plate", 15, 15, 1080, 0);
                Item i = context.Items.First(it => it.Id != 81);
                MthItem.SupprimerItem(i.Id);
                MthItem.SupprimerItem(10);
                MthItem.ModifierQuantiteItem("dildo", 1080, 2);
                MthItem.ModifierQuantiteItem("dildo", 1080, -2);

            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui toutes les méthode de la classe effet item
        /// Date:27-09-2017
        /// </summary>
        public void TestEffetItem()
        {
            using(Entities context = new Entities())
            {               
                Item it = context.Items.First();
                MthEffetItem.AjouterEffetItem(it.Id,23,23);
                MthEffetItem.AjouterEffetItem(it.Id, 330, 030);
                MthEffetItem.AjouterEffetItem(it.Id, 256, 2565);
                MthEffetItem.AjouterEffetItem(50, 23, 23);
                EffetItem ef = context.EffetItems.First();
                MthEffetItem.SupprimerEffetItem(ef.Id);
                MthEffetItem.SupprimerEffetItem(120);
                EffetItem ef2 = context.EffetItems.First();
                MthEffetItem.ModifierEffetItem(ef2.Id, it.Id, 454654, 545646);
                MthEffetItem.ModifierEffetItem(45, it.Id, 454654, 545646);
                MthEffetItem.ModifierEffetItem(ef2.Id, 1000, 454654, 545646);
            }
        }

        #endregion
    }
}
