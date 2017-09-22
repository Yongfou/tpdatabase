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
            TestMonde();
        }

        #region Méthodes

        public void TestMonde()
        {
            //Monde.CreerMonde("premier", 1000, 1000);
            //Monde.SupprimerMonde(76);
            //Monde.SupprimerMonde(90);
            //Monde.ModifierMonde(77, "Patate", 50, 50);
            //Monde.ModifierMonde(90, "patate", 50, 50);
            Monde.AfficherListeMonde();
        }

        #endregion
    }
}
