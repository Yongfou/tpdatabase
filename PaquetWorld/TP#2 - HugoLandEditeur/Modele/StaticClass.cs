using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur
{
    /// <summary>
    /// Auteur: Sébastien Paquet
    /// Description : Classe qui prend les valeur du choix du tile selon le choix de l'administrateur
    /// Date:23-10-2017
    /// </summary>
    class StaticClass
    {
        public static string TileData { get; set; }
        public static string TileCSV { get; set; }
        public static int SizeTileWidth { get; set; }
        public static int SizeTileHeight { get; set; }
        public static int TileBase { get; set; } = 0;
    }
}
