﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaquetWorld;

namespace HugoLandEditeur
{
    public partial class frmMain : Form
    {


        private CMap m_Map;
        public CTileLibrary m_TileLibrary;
        private csApplication csteApplication;
        public static List<Tile> listeTile = new List<Tile>();
        private int m_XSel;
        private int m_YSel;
        private int m_TilesHoriz;
        private System.Windows.Forms.Timer timer1;
        private int m_TilesVert;
        private bool m_bRefresh;
        private bool m_bResize;
        private int m_Zoom;
        private Rectangle m_TileRect;
        private Rectangle m_LibRect;
        private int m_ActiveXIndex;
        private int m_ActiveYIndex;
        private int m_ActiveTileID;
        private int m_ActiveTileXIndex;
        private int m_ActiveTileYIndex;
        private int PosX;
        private int PosY;
        public static int IdMonde;
        bool resizeOn = false;

        /// <summary>
        /// Summary description for Form1.
        /// </summary>
        /// 	
        public struct ComboItem
        {
            public string Text;
            public int Value;

            public ComboItem(string text, int val)
            {
                Text = text;
                Value = val;
            }
            public override string ToString()
            {
                return Text;
            }
        };

        public frmMain()
        {
            InitializeComponent();
        }

        /* -------------------------------------------------------------- *\
        frmMain_Load()			
        - Main Form Initialization		
    \* -------------------------------------------------------------- */
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            csteApplication = new csApplication();
            m_Zoom = csteApplication.ZOOM;
            timer1.Enabled = true;
            StaticClass.SizeTileHeight = 32;
            StaticClass.SizeTileWidth = 32;
            
        }


        /* -------------------------------------------------------------- *\
        Menus
    \* -------------------------------------------------------------- */
        #region Menu Code
        private void mnuFileExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuHelpAbout_Click(object sender, System.EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog(this);
        }

        private void mnuZoomX1_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 1;
            //m_ResizeMap();
            m_bResize = true;
        }

        private void mnuZoomX2_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 2;
            m_bResize = true;
        }

        private void mnuZoomX4_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 4;
            m_bResize = true;
        }

        private void mnuZoomX8_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 8;
            m_bResize = true;
        }

        private void mnuZoomX16_Click(object sender, System.EventArgs e)
        {
            ResetScroll();
            m_Zoom = 16;
            m_bResize = true;
        }

        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            LoadMap();
        }

        private void mnuFileSave_Click(object sender, System.EventArgs e)
        {
            m_SaveMap();
        }

        private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == tbbSave)
                m_SaveMap();
            if (e.Button == tbbOpen)
                LoadMap();
            else if (e.Button == tbbNew)
                NewMap();
        }

        #endregion


        /* -------------------------------------------------------------- *\
            vscMap_Scroll()
            - vertical scroll bar for map editor window		
        \* -------------------------------------------------------------- */
        private void vscMap_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            m_YSel = e.NewValue;
            //if (m_bOpen)
                picMap.Refresh();
        }

        /* -------------------------------------------------------------- *\
            hscMap_Scroll()
            - horizontal scroll bar for map editor window		
        \* -------------------------------------------------------------- */
        private void hscMap_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            m_XSel = e.NewValue;
            //if (m_bOpen)
                picMap.Refresh();
        }

        /* -------------------------------------------------------------- *\
            picEditArea_Resize()
			
            - resize event for the parent of the map. The edit area is
              auto-sized to the space not taken by the lower and right 
              panes.		
        \* -------------------------------------------------------------- */
        private void picEditArea_Resize(object sender, System.EventArgs e)
        {
            if (m_bOpen)
            {
                m_XSel = 0;
                hscMap.Value = m_XSel;
                m_YSel = 0;
                vscMap.Value = m_YSel;
                m_bResize = true;
            }
        }

        /* -------------------------------------------------------------- *\
            timer1_Tick()
			
            - I'm not sure if this is necessary or not, but I was having
              difficulty updating things correctly due to timing of resizing
              items or updating scrolls and their values not getting set 
              until after the event already occurred... so I'm setting
              flags instead.
        \* -------------------------------------------------------------- */
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (m_bRefresh)
            {
                m_bRefresh = false;
                picMap.Refresh();
            }
            if (m_bResize)
            {
                m_bResize = false;
                m_ResizeMap();
            }
            if (m_bRefreshLib)
            {
                m_bRefreshLib = false;
                picTiles.Refresh();
            }
        }

        /* -------------------------------------------------------------- *\
            picMap_Paint()
			
            - This is where the Map picture box is painted to.
              This event happens when Refresh() is called or any section
              of the picture box is invalidated (i.e. covering up part of
              the picture box with another windows and then moving it away)
        \* -------------------------------------------------------------- */
        private void picMap_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if(m_Zoom != 0)
            {
                if (m_bOpen)
                {
                    if (m_XSel < 0)
                        m_XSel = 0;
                    if (m_YSel < 0)
                        m_YSel = 0;
                    m_Map.Draw(e.Graphics, e.ClipRectangle, m_XSel, m_YSel);

                    if (m_bDrawMapRect)
                        e.Graphics.FillRectangle(m_brush, m_TileRect);
                }
            }
           
        }

        /* -------------------------------------------------------------- *\
            m_ResizeMap()
			
            - Takes care of Zoom, scroll and visible area logic.
        \* -------------------------------------------------------------- */
        private void m_ResizeMap()
        {


            int xpos, ypos;
            int nWidth = (vscMap.Left - 0); //picEditArea.Left);
            int AvailableWidth = nWidth - (2 * csteApplication.BUFFER_WIDTH);
            m_TilesHoriz = AvailableWidth / (m_Zoom * csteApplication.TILE_WIDTH_IN_MAP);
            int nMapWidth = m_TilesHoriz * csteApplication.TILE_WIDTH_IN_MAP * m_Zoom;
            int BorderX = (nWidth - nMapWidth) / 2;

            int nHeight = (hscMap.Top - 0); //picEditArea.Top);
            int AvailableHeight = nHeight - 2 * csteApplication.BUFFER_HEIGHT;
            m_TilesVert = AvailableHeight / (m_Zoom * csteApplication.TILE_HEIGHT_IN_MAP);
            int nMapHeight = m_TilesVert * csteApplication.TILE_HEIGHT_IN_MAP * m_Zoom;
            int BorderY = (nHeight - nMapHeight) / 2;

            PrintDebug("AvailableHeight = " + AvailableHeight.ToString());
            PrintDebug("BorderY = " + BorderY.ToString());
            PrintDebug("AvailableWidth = " + AvailableWidth.ToString());
            PrintDebug("BorderX = " + BorderX.ToString());

            m_Map.OffsetX = 0; //BorderX;
            m_Map.OffsetY = 0; //BorderY;						
            m_Map.Zoom = m_Zoom;

            if (m_TilesHoriz < m_Map.Width)
            {
                //xpos = 16;
                xpos = 16 + (AvailableWidth - nMapWidth) / 2;
                m_Map.TilesHoriz = m_TilesHoriz;
                hscMap.Maximum = m_Map.Width - m_TilesHoriz;
            }
            else
            {
                m_Map.TilesHoriz = m_Map.Width;
                nMapWidth = m_Map.Width * csteApplication.TILE_WIDTH_IN_MAP * m_Zoom;
                xpos = 16 + (AvailableWidth - nMapWidth) / 2;
                hscMap.Maximum = 0;
            }

            if (m_TilesVert < m_Map.Height)
            {
                //ypos = 32;
                ypos = 32 + (AvailableHeight - nMapHeight) / 2;
                m_Map.TilesVert = m_TilesVert;
                vscMap.Maximum = m_Map.Height - m_TilesVert;
            }
            else
            {
                m_Map.TilesVert = m_Map.Height;
                nMapHeight = m_Map.Height * csteApplication.TILE_HEIGHT_IN_MAP * m_Zoom;
                ypos = 32 + (AvailableHeight - nMapHeight) / 2;
                vscMap.Maximum = 0;
            }

            picMap.Location = new System.Drawing.Point(xpos, ypos);
            picMap.Size = new Size(nMapWidth, nMapHeight);

            m_bRefresh = true;


        }


        /* -------------------------------------------------------------- *\
            picMap_MouseMove()
			
            - Keeps track / translates coordinates to map tile to be
              updated if clicked on.
        \* -------------------------------------------------------------- */
        private void picMap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_TileLibrary != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;
                if (e.X < m_TileRect.Left || e.X > m_TileRect.Right || e.Y < m_TileRect.Top || e.Y > m_TileRect.Bottom)
                {
                    m_bDrawMapRect = true;

                    m_Map.PointToTile(e.X, e.Y, ref m_ActiveXIndex, ref m_ActiveYIndex);
                    
                    m_Map.PointToBoundingRect(e.X, e.Y, ref m_TileRect);
                    m_ActiveXIndex += m_XSel;
                    m_ActiveYIndex += m_YSel;

                    m_bRefresh = true;

                    PrintDebug("XIndex = " + m_ActiveXIndex.ToString() + " YIndex = " + m_ActiveYIndex.ToString());
                }
            } 
                   
        }

        /* -------------------------------------------------------------- *\
            picMap_Click()
			
            - Plots the ActiveTile from the tile library to the selected
              tile location on the map.
        \* -------------------------------------------------------------- */
        private void picMap_Click(object sender, System.EventArgs e)
        {
            //hUGO : mODIFIER ICI POUR AVOIR le tile et le type
            m_Map.PlotTile(m_ActiveXIndex, m_ActiveYIndex, m_ActiveTileID);
            
            TrouverTile(m_ActiveXIndex, m_ActiveYIndex);
            picTiles.Refresh();
            m_bRefresh = true;
        }

        /* -------------------------------------------------------------- *\
            picTiles_Paint()
			
            - Paints the tile library at the bottom of the screen.
        \* -------------------------------------------------------------- */
        private void picTiles_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (m_TileLibrary != null)
            {
                m_TileLibrary.Draw(e.Graphics, e.ClipRectangle);
                if (m_bDrawTileRect)
                    e.Graphics.FillRectangle(m_brush2, m_LibRect);
            }
        }

        /* -------------------------------------------------------------- *\
            picTiles_Click()
			
            - Selects the active tile ID
        \* -------------------------------------------------------------- */
        private void picTiles_Click(object sender, System.EventArgs e)
        {
            m_ActiveTileID = m_TileLibrary.TileToTileID(m_ActiveTileXIndex, m_ActiveTileYIndex);
            picActiveTile.Refresh();
        }

        /* -------------------------------------------------------------- *\
            vscTiles_Scroll()
			
            - controls the tile library scroll / position
        \* -------------------------------------------------------------- */
        private void vscTiles_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            picTiles.Top = -e.NewValue;
        }

        /* -------------------------------------------------------------- *\
            picTiles_MouseMove()
			
            - Keeps track / translates coordinates to tilelibrary tile to be
              selected if clicked on.
        \* -------------------------------------------------------------- */
        private void picTiles_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_TileLibrary != null)
            {
                if (e.X < 0 || e.Y < 0)
                    return;
                if (e.X < m_LibRect.Left || e.X > m_LibRect.Right || e.Y < m_LibRect.Top || e.Y > m_LibRect.Bottom)
                {
                    m_bDrawTileRect = true;

                    m_TileLibrary.PointToTile(e.X, e.Y, ref m_ActiveTileXIndex, ref m_ActiveTileYIndex);                  
                    m_TileLibrary.PointToBoundingRect(e.X, e.Y, ref m_LibRect);
                    
                    m_bRefreshLib = true;

                    PrintDebug("TileXIndex = " + m_ActiveTileXIndex.ToString() + " TileYIndex = " + m_ActiveTileYIndex.ToString());
                    PrintDebug("X = " + e.X.ToString() + " Y = " + e.Y.ToString());
                }
            }
           
        }

        /* -------------------------------------------------------------- *\
            ResetScroll()
			
            - Resets the scrollbar to 0.
              I'm not sure if this is necessary anymore.. I was trouble-
              shooting an odd issue.			  
        \* -------------------------------------------------------------- */
        private void ResetScroll()
        {
            vscMap.Value = 0;
            m_YSel = 0;
            hscMap.Value = 0;
            m_XSel = 0;
        }

        /* -------------------------------------------------------------- *\
            picActiveTile_Paint()
			
            - Displays the selected tile.	  
        \* -------------------------------------------------------------- */
        private void picActiveTile_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (m_TileLibrary != null)
            {
                Rectangle destrect = new Rectangle(0, 0, picActiveTile.Width, picActiveTile.Height);
                m_TileLibrary.DrawTile(e.Graphics, m_ActiveTileID, destrect);
            }
            
        }

        /* -------------------------------------------------------------- *\
            tmrLoad_Tick()
			
            - Loads the default map. 
        \* -------------------------------------------------------------- */
        private void tmrLoad_Tick(object sender, System.EventArgs e)
        {
            tmrLoad.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            m_Map.Refresh();
            m_bOpen = true;
            m_bRefresh = true;
            picMap.Visible = true;
            m_MenuLogic();
            this.Cursor = Cursors.Default;
        }
        #region Debug Code

        private void PrintDebug(String strDebug)
        {
            Console.WriteLine(strDebug);
        }
        #endregion

//todo:load 

        /// <summary>
        /// Auteur: Sébastien Paquet 
        /// Description: Méthode qui load un monde
        /// Date:23-10-2017
        /// </summary>
        private void LoadMap()
        {
            listeTile.Clear();
            try
            {
                bool bResult;
                LoadMap map = new LoadMap();
                m_Map = new CMap();

                DialogResult dr = map.ShowDialog(this);
                csteApplication = new csApplication();
                m_Zoom = csteApplication.ZOOM;

                m_TileLibrary = new CTileLibrary();
                m_Map.TileLibrary = m_TileLibrary;
                IdMonde = map.IdMonde;
                Monde md = new Monde();

                using (Entities context = new Entities())
                {
                    md = context.Mondes.First(m => m.Id == IdMonde);
                }

                picEditSel.Width = m_TileLibrary.ReelLargeur;
                picEditSel.Height = m_TileLibrary.ReelLongeur;
                vscTiles.Maximum = m_TileLibrary.ReelLongeur;
                m_bRefreshLib = true;

                picMap.Parent = picEditArea;
                picMap.Left = 0;
                picMap.Top = 0;

                picTiles.Parent = picEditSel;
                picTiles.Width = m_TileLibrary.Width * csteApplication.TILE_WIDTH_IN_IMAGE;
                picTiles.Height = m_TileLibrary.Height * csteApplication.TILE_HEIGHT_IN_IMAGE;
                picTiles.Left = 0;
                picTiles.Top = 0;

                vscMap.Minimum = 0;
                vscMap.Maximum = m_Map.Height;
                m_YSel = 0;

                hscMap.Minimum = 0;
                hscMap.Maximum = m_Map.Width;
                m_XSel = 0;

                m_TileRect = new Rectangle(-1, -1, -1, -1);
                m_LibRect = new Rectangle(-1, -1, -1, -1);
                m_ActiveTileID = StaticClass.TileBase;
                picActiveTile.Refresh();
                m_bOpen = false;
                m_MenuLogic();
                m_pen = new Pen(Color.Orange, 4);
                m_brush = new SolidBrush(Color.FromArgb(160, 249, 174, 55));
                m_brush2 = new SolidBrush(Color.FromArgb(160, 255, 0, 0));
                m_bDrawTileRect = false;
                m_bDrawMapRect = false;

                cboZoom.Left = 270;
                cboZoom.Top = 2;
                if (cboZoom.SelectedIndex < 1)
                {
                    cboZoom.Items.Add(new ComboItem("1X", 1));
                    cboZoom.Items.Add(new ComboItem("2X", 2));
                    cboZoom.Items.Add(new ComboItem("4X", 4));
                    cboZoom.Items.Add(new ComboItem("8X", 8));
                    cboZoom.Items.Add(new ComboItem("16X", 16));
                }
                cboZoom.SelectedIndex = 1;
                cboZoom.DropDownStyle = ComboBoxStyle.DropDownList;

                lblZoom.Left = 180;
                lblZoom.Top = 2;

                tbMain.Controls.Add(lblZoom);
                tbMain.Controls.Add(cboZoom);
                if (dr == DialogResult.Cancel)
                {
                    map.Close();
                }
                else
                {

                    m_bOpen = false;
                    picMap.Visible = false;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        bResult = m_Map.CreateNew(md.LimiteX, md.LimiteY, StaticClass.TileBase);
                        if (bResult)
                        {
                            m_Map.Load(IdMonde);
                            m_ResizeMap();
                            m_bOpen = true;
                            m_bResize = true;
                            picMap.Visible = true;
                            resizeOn = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error Creating...");
                    }
                    m_MenuLogic();
                    this.Cursor = Cursors.Default;
                }
            }
            catch(Exception e)
            {

            }
            
        }

 //todo:Save
        /// <summary>
        /// Auteur: Sébastien Paquet
        /// Description: Méthode qui sauvegarde un monde 
        /// Date:23-10-2017
        /// </summary>
        private void m_SaveMap()
        {

            ValidSave validSave = new ValidSave();
            if(IdMonde > 0)
            {
                validSave.Txt = false;
            }

            DialogResult dr = validSave.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                validSave.Close();
            }
            else if (dr == DialogResult.OK)
            {
                if(IdMonde == 0)
                {
                    IdMonde = PaquetWorld.MthMonde.CreerMonde(validSave.Nom, m_Map.Width, m_Map.Height,StaticClass.TileData,StaticClass.TileCSV,StaticClass.TileBase,StaticClass.SizeTileHeight);

                }
                PaquetWorld.MthItem.SupprimerTousItemMonde(IdMonde);
                PaquetWorld.MthMonstre.SupprimerTousMonstreMonde(IdMonde);
                PaquetWorld.MthObjetMonde.SupprimerTousMondeobjetMonde(IdMonde);
                foreach (Tile t in listeTile)
                {
                    
                    if(t.TypeObjet == TypeTile.Item)
                    {
                        PaquetWorld.MthItem.CreerItem(t.Name, t.Category, t.X_Image, t.Y_Image, IdMonde,t.IdImage);
                    }
                    else if(t.TypeObjet == TypeTile.ObjetMonde)
                    {
                        PaquetWorld.MthObjetMonde.CreerObjetMonde(t.Name, t.X_Image, t.Y_Image,t.Typeobjet, IdMonde);
                    }
                    else if(t.TypeObjet == TypeTile.Monstre)
                    {
                        PaquetWorld.MthMonstre.CreerMonstre(t.Name, t.X_Image, t.Y_Image, IdMonde,t.IdImage);
                    }
                }
                validSave.Close();
            }

        }

        /* -------------------------------------------------------------- *\
            m_NewMap()
			
            - Creates a new map of the selected size.
        \* -------------------------------------------------------------- */
        private void NewMap()
        {

            frmNew f;
            DialogResult result;
            bool bResult;
            f = new frmNew();
            m_Map = new CMap();

            f.MapWidth = 0;
            f.MapHeight = 0;

            result = f.ShowDialog(this);
            csteApplication = new csApplication();
            m_TileLibrary = new CTileLibrary();
            picEditSel.Width = m_TileLibrary.ReelLargeur;
            picEditSel.Height = m_TileLibrary.ReelLongeur;
            vscTiles.Maximum = m_TileLibrary.ReelLongeur;
            m_bRefreshLib = true;

            m_Map.TileLibrary = m_TileLibrary;

            picMap.Parent = picEditArea;
            picMap.Left = 0;
            picMap.Top = 0;

            picTiles.Parent = picEditSel;
            picTiles.Width = m_TileLibrary.Width * csteApplication.TILE_WIDTH_IN_IMAGE;
            picTiles.Height = m_TileLibrary.Height * csteApplication.TILE_HEIGHT_IN_IMAGE;
            picTiles.Left = 0;
            picTiles.Top = 0;

            vscMap.Minimum = 0;
            vscMap.Maximum = m_Map.Height;
            m_YSel = 0;

            hscMap.Minimum = 0;
            hscMap.Maximum = m_Map.Width;
            m_XSel = 0;

            
            

            m_TileRect = new Rectangle(-1, -1, -1, -1);
            m_LibRect = new Rectangle(-1, -1, -1, -1);
            m_ActiveTileID = StaticClass.TileBase;
            picActiveTile.Refresh();
            m_bOpen = false;
            m_MenuLogic();
            m_pen = new Pen(Color.Orange, 4);
            m_brush = new SolidBrush(Color.FromArgb(160, 249, 174, 55));
            m_brush2 = new SolidBrush(Color.FromArgb(160, 255, 0, 0));
            m_bDrawTileRect = false;
            m_bDrawMapRect = false;

            cboZoom.Left = 270;
            cboZoom.Top = 2;
            if (cboZoom.SelectedIndex < 1)
            {
                cboZoom.Items.Add(new ComboItem("1X", 1));
                cboZoom.Items.Add(new ComboItem("2X", 2));
                cboZoom.Items.Add(new ComboItem("4X", 4));
                cboZoom.Items.Add(new ComboItem("8X", 8));
                cboZoom.Items.Add(new ComboItem("16X", 16));
            }
            cboZoom.SelectedIndex = 1;
            cboZoom.DropDownStyle = ComboBoxStyle.DropDownList;

            lblZoom.Left = 180;
            lblZoom.Top = 2;
            tbMain.Controls.Add(lblZoom);
            tbMain.Controls.Add(cboZoom);
            if (result == DialogResult.OK)
            {
                IdMonde = 0;

                m_bOpen = false;
                picMap.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    bResult = m_Map.CreateNew(f.MapWidth, f.MapHeight, StaticClass.TileBase);
                    if (bResult)
                    {
                        m_ResizeMap();
                        m_bOpen = true;
                        m_bResize = true;
                        picMap.Visible = true;
                        resizeOn = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Error Creating...");
                }
                m_MenuLogic();
                this.Cursor = Cursors.Default;
            }
        }

        /* -------------------------------------------------------------- *\
            m_MenuLogic()
			
            - Enables / Disables menus based on application status
        \* -------------------------------------------------------------- */
        private void m_MenuLogic()
        {
            bool bEnabled;

            bEnabled = m_bOpen;
            mnuFileSave.Enabled = bEnabled;
            mnuFileClose.Enabled = bEnabled;
            mnuCreateNewUser.Enabled = bEnabled;
            mnuZoom.Enabled = bEnabled;
            tbbSave.Enabled = bEnabled;
        }

        /* -------------------------------------------------------------- *\
            mnuFileNew_Click()
        \* -------------------------------------------------------------- */
        private void mnuFileNew_Click(object sender, System.EventArgs e)
        {
            NewMap();
        }

        private void picTiles_MouseLeave(object sender, System.EventArgs e)
        {
            m_bDrawTileRect = false;
            m_LibRect.X = -1;
            m_LibRect.Y = -1;
            m_LibRect.Width = -1;
            m_LibRect.Height = -1;
            m_bRefreshLib = true;
        }

        private void picMap_MouseLeave(object sender, System.EventArgs e)
        {
            m_bDrawMapRect = false;
            m_TileRect.X = -1;
            m_TileRect.Y = -1;
            m_TileRect.Width = -1;
            m_TileRect.Height = -1;
            m_bRefresh = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            ComboItem myItem;
            myItem = (ComboItem)cboZoom.SelectedItem;
            ResetScroll();
            m_Zoom = myItem.Value;
            m_bResize = true;
            picTiles.Focus();
        }

        private void mnuCreateNewUser_Click(object sender, EventArgs e)
        {
            CreationJoueurAd cj = new CreationJoueurAd();
            cj.Show();
        }

        private void menuNewTile_Click(object sender, EventArgs e)
        {
            CreateurCSV cs = new CreateurCSV();
            cs.ShowDialog(this);
        }

        private void TrouverTile(int iPosMapX, int iPOsMapY)
        {
            int X = PosX / StaticClass.SizeTileWidth;
            int Y = PosY / StaticClass.SizeTileHeight;
            var req = m_TileLibrary.ObjMonde.First(c => c.Value.X_Image == X && c.Value.Y_Image == Y);
            Tile t = new Tile();
            t.Category = req.Value.Category;
            t.Color = req.Value.Color;
            t.Health = req.Value.Health;
            t.IndexTypeObjet = req.Value.IndexTypeObjet;
            t.IsBlock = req.Value.IsBlock;
            t.IsTransparent = req.Value.IsTransparent;
            t.Name = req.Value.Name;
            t.NumberOfFrames = req.Value.NumberOfFrames;
            t.Rectangle = req.Value.Rectangle;
            t.TypeObjet = req.Value.TypeObjet;
            t.X_Image = iPosMapX;
            t.Y_Image = iPOsMapY;
            t.IdImage = 0;
            t.Typeobjet = 0;
            listeTile.Add(t);
        }

        private void picTiles_MouseUp(object sender, MouseEventArgs e)
        {
            PosX = e.X;
            PosY = e.Y;
        }

        private void frmMain_Leave(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (resizeOn == true)
            {
                m_ResizeMap();
                ResetScroll();
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            AddAdministrateur ad = new AddAdministrateur();
            ad.Show();
        }
    }
}
