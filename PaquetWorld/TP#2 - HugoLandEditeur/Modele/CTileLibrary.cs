using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HugoLandEditeur
{
	/// <summary>
	/// Summary description for CTileLibrary.
	/// </summary>
	public class CTileLibrary
	{

        private csApplication csteApplication = new csApplication();
        private int m_Count;			// number of tiles
        private Bitmap m_TileSource;    // to be loaded from external File or resource...
        private int m_Width;
        private int m_Height;
        public int ReelLargeur =0;
        public int ReelLongeur = 0;
        public Dictionary<string, Tile> _ObjMonde = new Dictionary<string, Tile>();

        public Dictionary<string, Tile> ObjMonde
        {
            get { return _ObjMonde; }
            set { _ObjMonde = value; }
        }

        // Count
        public int Count
        {
            get
            {
                return m_Count;
            }
            set
            {
                m_Count = value;
            }
        }

        //Width
        public int Width
        {
            get
            {
                return m_Width; //m_TileSource.Width;;
            }
        }

        //Height
        public int Height
        {
            get
            {
                return m_Height; //m_TileSource.Height;;
            }
        }

        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Constructeur qui crée un objet de type tile selon le choix de tile de administrateur
        /// Date:32-10-2017
        /// </summary>
		public CTileLibrary()
		{
            if(StaticClass.TileData != null)
            {
                m_TileSource = new Bitmap(StaticClass.TileData);
                ReelLargeur = m_TileSource.Width;
                ReelLongeur = m_TileSource.Height;
                m_Width = (m_TileSource.Width / csteApplication.TILE_WIDTH_IN_IMAGE);
                m_Height = (m_TileSource.Height / csteApplication.TILE_HEIGHT_IN_IMAGE);
                readTileDefinitions(StaticClass.TileCSV);
            }
                   
		}


		public void Draw(Graphics pGraphics, Rectangle destRect)
		{
            Rectangle srcRect = new Rectangle(0, 0, (m_Width ) * csteApplication.TILE_WIDTH_IN_IMAGE, (m_Height ) * csteApplication.TILE_HEIGHT_IN_IMAGE);
            Rectangle destRect2 = new Rectangle(0, 0, (m_Width ) * csteApplication.TILE_WIDTH_IN_IMAGE, (m_Height ) * csteApplication.TILE_HEIGHT_IN_IMAGE);
			pGraphics.DrawImage(m_TileSource, destRect2, srcRect, GraphicsUnit.Pixel);
		}

		public void DrawTile(Graphics pGraphics, int ID, int X, int Y)
		{
            Rectangle sourcerect = new Rectangle((ID % csteApplication.TILE_WIDTH_IN_LIBRARY) * csteApplication.TILE_WIDTH_IN_IMAGE, (ID / csteApplication.TILE_HEIGHT_IN_LIBRARY) * csteApplication.TILE_HEIGHT_IN_IMAGE, csteApplication.TILE_WIDTH_IN_IMAGE, csteApplication.TILE_HEIGHT_IN_IMAGE);
            Rectangle destrect = new Rectangle(X, Y, csteApplication.TILE_WIDTH_IN_MAP, csteApplication.TILE_HEIGHT_IN_MAP);
            Tile t = _ObjMonde.Values.First(m => TileToTileID(m.X_Image, m.Y_Image) == ID);

            // Rendre l'image transparent lorsque le spécification du tile le précise
            if(t.IsTransparent == true)
            {
                Bitmap temp = new Bitmap(64, 64);
                Graphics g = Graphics.FromImage(temp);
                g.DrawImage(m_TileSource, new Rectangle(0, 0, temp.Width, temp.Height), sourcerect, GraphicsUnit.Pixel);
                temp.MakeTransparent(temp.GetPixel(1, 1));
                pGraphics.DrawImage(temp, destrect, new Rectangle(0, 0, temp.Width, temp.Height), GraphicsUnit.Pixel);
            }
            else
			pGraphics.DrawImage(m_TileSource,destrect,sourcerect,GraphicsUnit.Pixel);
		}

		public void DrawTile(Graphics pGraphics, int ID, Rectangle destrect)
		{
                         
            Rectangle sourcerect = new Rectangle((ID % csteApplication.TILE_WIDTH_IN_LIBRARY) * csteApplication.TILE_WIDTH_IN_IMAGE, (ID / csteApplication.TILE_HEIGHT_IN_LIBRARY) * csteApplication.TILE_HEIGHT_IN_IMAGE, csteApplication.TILE_WIDTH_IN_IMAGE, csteApplication.TILE_HEIGHT_IN_IMAGE);
			pGraphics.DrawImage(m_TileSource,destrect,sourcerect,GraphicsUnit.Pixel);
		}

		public void GetSourceRect(Rectangle sourcerect, int ID)
		{
            sourcerect.X = ID % csteApplication.TILE_WIDTH_IN_LIBRARY;
            sourcerect.Y = ID / csteApplication.TILE_HEIGHT_IN_LIBRARY;
            sourcerect.Width = csteApplication.TILE_WIDTH_IN_IMAGE;
            sourcerect.Height = csteApplication.TILE_HEIGHT_IN_IMAGE;
		}

		public int TileToTileID(int xindex, int yindex)
		{	
			if (xindex > m_Width)
				xindex = m_Width;
			if (yindex > m_Height)
				yindex = m_Height;
			return (yindex *32 + xindex);
		}

		public void PointToBoundingRect(int x, int y, ref Rectangle bounding)
		{
            x = x / csteApplication.TILE_WIDTH_IN_IMAGE;
            y = y / csteApplication.TILE_HEIGHT_IN_IMAGE;
            bounding.Size = new Size(csteApplication.TILE_WIDTH_IN_IMAGE + 6, csteApplication.TILE_HEIGHT_IN_IMAGE + 6);
            bounding.X = (x * csteApplication.TILE_WIDTH_IN_IMAGE) - 3;
            bounding.Y = (y * csteApplication.TILE_HEIGHT_IN_IMAGE) - 3;			
		}

		public void PointToTile(int x, int y, ref int xindex, ref int yindex)
		{
            xindex = x / csteApplication.TILE_WIDTH_IN_IMAGE;
            yindex = y / csteApplication.TILE_HEIGHT_IN_IMAGE;
		}

        /// <summary>
        ///  Each line contains a comma delimited tile definition that the tile constructor understands.
        /// </summary>
        /// <param name="tileDescriptionFile"></param>
        private void readTileDefinitions(string tileDescriptionFile)
        {
            try
            {
                using (StreamReader stream = new StreamReader(tileDescriptionFile))
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        //separate out the elements of the 
                        string[] elements = line.Split(',');

                        Tile objMonde;
                        objMonde = new Tile(elements);
                        _ObjMonde.Add(objMonde.Name, objMonde);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
              
            
           
        }

	}
}
