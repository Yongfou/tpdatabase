using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur
{
    public class csApplication
    {
        //csteApplication
        public  int BUFFER_WIDTH = 0;
        public  int BUFFER_HEIGHT = 0;
        public  int ZOOM = 2;

        public  int MAPFILE_ID = 0x1222;
        public  int MAP_MAX_WIDTH = 64000;
        public  int MAP_MAX_HEIGHT = 64000;
        public int TILE_WIDTH_IN_IMAGE;
        public int TILE_HEIGHT_IN_IMAGE;

        public  int TILE_WIDTH_IN_LIBRARY = 32;
        public  int TILE_HEIGHT_IN_LIBRARY = 32;
        public  int TILE_WIDTH_IN_MAP = 32;
        public  int TILE_HEIGHT_IN_MAP = 32;

        public csApplication()
        {
            TILE_WIDTH_IN_IMAGE = StaticClass.SizeTileWidth;
            TILE_HEIGHT_IN_IMAGE = StaticClass.SizeTileHeight;
        }
    }
}
