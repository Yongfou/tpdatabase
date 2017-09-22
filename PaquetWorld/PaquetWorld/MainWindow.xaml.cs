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
            TestObjetMonde();
        }

        #region Méthodes

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui teste les méthode de la classe monde
        /// Date:22-09-2017
        /// </summary>
        public void TestMonde()
        {
            using(Entities context = new Entities())
            {
                Monde.CreerMonde("premier", 1000, 1000);
                Monde md = context.Mondes.First();
                Monde.SupprimerMonde(md.Id);
                Monde.SupprimerMonde(50);
                Monde md2 = context.Mondes.First();
                Monde.ModifierMonde(md2.Id, "Patate", 50, 50);
                Monde.ModifierMonde(50, "patate", 50, 50);
                Monde.AfficherListeMonde();
            }
           
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description:Méthode qui teste les méthodes de la classe objet monde
        /// Date:22-09-2017
        /// </summary>
        public void TestObjetMonde()
        {
            using(Entities context = new Entities())
            {
                Monde md = context.Mondes.First();
                ObjetMonde.CreerObjetMonde("Petite fleur", 50, 50, 3, md.Id);
                ObjetMonde.CreerObjetMonde("Petite fleur", 50, 50, 3, 50);
                ObjetMonde obm = context.ObjetMondes.First();
                ObjetMonde.SupprimerObjetMonde(obm.Id);
                ObjetMonde.SupprimerObjetMonde(50);
                ObjetMonde obm2 = context.ObjetMondes.First();
                ObjetMonde.ModifierObjetMonde("Poil", obm2.Id);
                ObjetMonde.ModifierObjetMonde("Poil", 50);
            }
        }

        #endregion
    }
}
