using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur: Sébastien Paquet
    /// Description: Classe qui est utiliser pour la construction d'un nouveau tile
    /// Date : 23-10-2017
    /// </summary>
    class TileCreateur
    {
        public enum Type
        {
            Objet,
            Monstre,
            Item
        }
        public enum Categorie
        {
            Normal,
            Treasure,
            Key,
            Food,
            Door,
            Potion,
            Character
        }

        public string Nom { get; set; }
        public int ID { get; set; }
        public Categorie categorie { get; set; }
        public string CategorieTexte { get; set; }
        public string Path { get; set; }
        public int Ligne { get; set; }
        public int Colonne { get; set; }
        public string Transparent { get; set; }
        public int Frame { get; set; }
        public string Fermer { get; set; }
        public string VieCouleur { get; set; }
        public Type type { get; set; }
        public string TypeTexte { get; set; }
    }
}
