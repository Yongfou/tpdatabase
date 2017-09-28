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
            TestHero();
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
                MthMonde.CreerMonde("premier", 1000, 1000);
                Monde md = context.Mondes.First(m=>m.Id != 1080);
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

            MessageBox.Show(MthCompteJoueur.CreerCompteJoueur("yongfou1", "s-paquet@hotmail.fr", "Sébastien", "Paquet", 2, "282656347"));
            MessageBox.Show(MthCompteJoueur.CreerCompteJoueur("yongfou12", "s-paquet@hotmail.fr", "Sébastien", "Paquet", 2, "282656347"));

            MessageBox.Show(MthCompteJoueur.Connexion("yongfou12", "282656347"));
            MessageBox.Show(MthCompteJoueur.Connexion("yongfou", "282656347"));
            using (Entities context = new Entities())
            {
                var req = context.CompteJoueurs.Where(m => m.NomJoueur == "yongfou12");
                foreach (CompteJoueur x in req)
                {
                    context.CompteJoueurs.Remove(x);
                }
                context.SaveChanges();
            }
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
                MthClasse.ModifierClasse(50,"chevalier", "paladin", 15, 12, 10, 20, m1.Id);
                Classe c2 = context.Classes.First();
                MthClasse.ModifierClasse(c2.Id,"chevalier", "paladin", 15, 12, 10, 20, 50);
                MthClasse.ModifierClasse(c2.Id,"chevalier", "paladin", 15, 12, 10, 20, m1.Id);


            }
        }

        public void TestHero()
        {
            //MthHero.CreerHero(1009, 1080, 18, 20, 15151, 25, 25, 64, 64, 64, 64, "paul", true);
            MthHero.RayonHero(1);
            //foreach(ObjetMonde om in MthHero.ListeObjetMonde)
            //{
            //    txttext.AppendText("ID : " + om.Id +" X : " +om.x+" Y : " + om.y + " Description : "+om.Description+" Type d'objet : "+om.TypeObjet +" Monde id : "+om.MondeId + "\n");
            //}
            //foreach (Monstre m in MthHero.ListeMonstre)
            //{
            //    txttext.AppendText(m + "\n");
            //}
            //foreach(Item i in MthHero.ListeItem)
            //{
            //    txttext.AppendText(i + "\n");
            //}
            //foreach(Hero h in MthHero.ListeHero)
            //{
            //    txttext.AppendText(h + "\n");
            //}
        }
        #endregion
    }
}
