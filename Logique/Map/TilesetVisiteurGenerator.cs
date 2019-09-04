using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class TilesetVisiteurGenerator
    {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;
        private const int TILE_LEFT = 0, TILE_TOP = 0;
        private const int SEPARATEUR_TILE = 0;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        public static int VISITEUR_1_BAS = 0;
        public static int VISITEUR_1_HAUT = 1;
        public static int VISITEUR_1_GAUCHE = 2;
        public static int VISITEUR_1_DROITE = 3;
        public static int VISITEUR_2_BAS = 4;
        public static int VISITEUR_2_HAUT = 5;
        public static int VISITEUR_2_GAUCHE = 6;
        public static int VISITEUR_2_DROITE = 7;
        public static int VISITEUR_3_BAS = 8;
        public static int VISITEUR_3_HAUT = 9;
        public static int VISITEUR_3_GAUCHE = 10;
        public static int VISITEUR_3_DROITE = 11;
        public static int VISITEUR_4_BAS = 12;
        public static int VISITEUR_4_HAUT = 13;
        public static int VISITEUR_4_GAUCHE = 14;
        public static int VISITEUR_4_DROITE = 15;
        public static int VISITEUR_5_BAS = 16;
        public static int VISITEUR_5_HAUT = 17;
        public static int VISITEUR_5_GAUCHE = 18;
        public static int VISITEUR_5_DROITE = 19;
        public static int VISITEUR_6_BAS = 20;
        public static int VISITEUR_6_HAUT = 21;
        public static int VISITEUR_6_GAUCHE = 22;
        public static int VISITEUR_6_DROITE = 23;
        public static int VISITEUR_7_BAS = 24;
        public static int VISITEUR_7_HAUT = 25;
        public static int VISITEUR_7_GAUCHE = 26;
        public static int VISITEUR_7_DROITE = 27;
        public static int VISITEUR_8_BAS = 28;
        public static int VISITEUR_8_HAUT = 29;
        public static int VISITEUR_8_GAUCHE = 30;
        public static int VISITEUR_8_DROITE = 31;
        public static int VISITEUR_9_BAS = 32;
        public static int VISITEUR_9_HAUT = 33;
        public static int VISITEUR_9_GAUCHE = 34;
        public static int VISITEUR_9_DROITE = 35;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TilesetVisiteurGenerator()
        {
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 0 }); // VISITEUR_1_BAS
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 1 }); // VISITEUR_1_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 2 }); // VISITEUR_1_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 9 }); // VISITEUR_1_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 0 }); // VISITEUR_2_BAS 
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 1 }); // VISITEUR_2_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 2 }); // VISITEUR_2_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 1, Colonne = 9 }); // VISITEUR_2_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 0 }); // VISITEUR_3_BAS
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 1 }); // VISITEUR_3_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 2 }); // VISITEUR_3_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 2, Colonne = 9 }); // VISITEUR_3_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 0 }); // VISITEUR_4_BAS
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 1 }); // VISITEUR_4_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 2 }); // VISITEUR_4_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 3, Colonne = 9 }); // VISITEUR_4_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 0 }); // VISITEUR_5_BAS
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 1 }); // VISITEUR_5_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 2 }); // VISITEUR_5_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 9 }); // VISITEUR_5_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 0 }); // VISITEUR_6_BAS
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 1 }); // VISITEUR_6_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 2 }); // VISITEUR_6_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 9 }); // VISITEUR_6_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 0 }); // VISITEUR_7_BAS
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 1 }); // VISITEUR_7_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 2 }); // VISITEUR_7_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 9 }); // VISITEUR_7_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 0 }); // VISITEUR_8_BAS
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 1 }); // VISITEUR_8_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 2 }); // VISITEUR_8_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 9 }); // VISITEUR_8_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 0 }); // VISITEUR_9_BAS
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 1 }); // VISITEUR_9_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 2 }); // VISITEUR_9_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 9 }); // VISITEUR_9_DROITE



            listeBitmap.Add(LoadTile(VISITEUR_1_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_1_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_1_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_1_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_2_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_2_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_2_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_2_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_3_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_3_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_3_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_3_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_4_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_4_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_4_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_4_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_5_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_5_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_5_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_5_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_6_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_6_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_6_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_6_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_7_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_7_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_7_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_7_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_8_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_8_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_8_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_8_DROITE));
            listeBitmap.Add(LoadTile(VISITEUR_9_BAS));
            listeBitmap.Add(LoadTile(VISITEUR_9_HAUT));
            listeBitmap.Add(LoadTile(VISITEUR_9_GAUCHE));
            listeBitmap.Add(LoadTile(VISITEUR_9_DROITE));
        }

        private static Bitmap LoadTile(int posListe)
        {
            Image source = TP2.Properties.Resources.personnages;
            TileCoord coord = listeCoord[posListe];
            Rectangle crop = new Rectangle(TILE_LEFT + (coord.Colonne * (IMAGE_WIDTH + SEPARATEUR_TILE)), TILE_TOP + coord.Ligne * (IMAGE_HEIGHT + SEPARATEUR_TILE), IMAGE_WIDTH, IMAGE_HEIGHT);

            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Bitmap GetTile(int posListe)
        {
            return listeBitmap[posListe];
        }

    }
}

