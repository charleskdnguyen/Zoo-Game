using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class TilesetImageGenerator
    {
        // Différentes tailles concernant les images dans le fichier de tuiles de jeu
        public const int IMAGE_WIDTH = 32, IMAGE_HEIGHT = 32;
        private const int TILE_LEFT = 0, TILE_TOP = 0;
        private const int SEPARATEUR_TILE = 0;

        // La valeur entière correspond "par hasard" à la position de l'image dans la List<TileCoord>
        public static int GAZON = 0;
        public static int CLOTURE_PIERRE_HAUT = 1;
        public static int CLOTURE_PIERRE_COIN_GAUCHE = 2;
        public static int CLOTURE_PIERRE_COIN_HAUT_DROITE = 3;
        public static int CLOTURE_PIERRE_COIN_BAS_DROITE = 4;
        public static int CLOTURE_PIERRE_BAS_HAUT = 5;
        public static int ASPHALTE = 6;
        public static int GAZON_SABLE_HAUT_GAUCHE = 7;
        public static int GAZON_SABLE_HAUT_MILIEU = 8;
        public static int GAZON_SABLE_HAUT_DROITE = 9;
        public static int GAZON_SABLE_DROITE_MILIEU = 10;
        public static int GAZON_SABLE_BAS_DROITE = 11;
        public static int GAZON_SABLE_BAS_MILIEU = 12;
        public static int GAZON_SABLE_BAS_GAUCHE = 13;
        public static int GAZON_SABLE_GAUCHE_MILIEU = 14;
        public static int SABLE = 15;
        public static int BUISSON = 16;
        public static int EAU = 17;
        public static int MAISON_ENTREE_1 = 18;
        public static int MAISON_ENTREE_2 = 19;
        public static int MAISON_ENTREE_3 = 20;
        public static int MAISON_ENTREE_4 = 21;
        public static int MAISON_ENTREE_5 = 22;
        public static int MAISON_ENTREE_6 = 23;
        public static int MAISON_ENTREE_7 = 24;
        public static int MAISON_ENTREE_8 = 25;
        public static int MAISON_ENTREE_9 = 26;
        public static int MAISON_ENTREE_10 = 27;
        public static int MAISON_ENTREE_11 = 28;
        public static int MAISON_ENTREE_12 = 29;
        public static int MAISON_ENTREE_13 = 30;
        public static int MAISON_ENTREE_14 = 31;
        public static int MAISON_ENTREE_15 = 32;
        public static int MAISON_ENTREE_16 = 33;
        public static int MAISON_ENTREE_17 = 34;
        public static int MAISON_ENTREE_18 = 35;
        public static int MAISON_ENTREE_19 = 36;
        public static int MAISON_ENTREE_20 = 37;
        public static int LION_BAS = 38;
        public static int LION_HAUT = 39;
        public static int LION_GAUCHE = 40;
        public static int LION_DROITE = 41;
        public static int LICORNE_BAS = 42;
        public static int LICORNE_HAUT = 43;
        public static int LICORNE_GAUCHE = 44;
        public static int LICORNE_DROITE = 45;
        public static int RHINO_BAS = 46;
        public static int RHINO_HAUT = 47;
        public static int RHINO_GAUCHE = 48;
        public static int RHINO_DROITE = 49;
        public static int PORTE_ENCLOS = 50;
        public static int DECHET = 51;

        private static List<TileCoord> listeCoord = new List<TileCoord>();
        private static List<Bitmap> listeBitmap = new List<Bitmap>();

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static TilesetImageGenerator()
        {
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 0 }); // GAZON
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 22 }); // CLOTURE_PIERRE_H
            listeCoord.Add(new TileCoord() { Ligne = 12, Colonne = 23 }); // CLOTURE_PIERRE_V
            listeCoord.Add(new TileCoord() { Ligne = 9, Colonne = 23 }); // CLOTURE_PIERRE_COIN_HAUT_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 23 }); // CLOTURE_PIERRE_COIN_BAS_DROITE 
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 22 }); // CLOTURE_PIERRE_BAS_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 10, Colonne = 7 }); // ASPHALTE
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 3 }); // GAZON_SABLE_HAUT_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 4 }); // GAZON_SABLE_HAUT_MILIEU
            listeCoord.Add(new TileCoord() { Ligne = 13, Colonne = 5 }); // GAZON_SABLE_HAUT_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 5 }); // GAZON_SABLE_DROITE_MILIEU
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 5 }); // GAZON_SABLE_BAS_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 4 }); // GAZON_SABLE_BAS_MILIEU
            listeCoord.Add(new TileCoord() { Ligne = 15, Colonne = 3 }); // GAZON_SABLE_BAS_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 3 }); // GAZON_SABLE_GAUCHE_MILIEU
            listeCoord.Add(new TileCoord() { Ligne = 14, Colonne = 4 }); // SABLE
            listeCoord.Add(new TileCoord() { Ligne = 0, Colonne = 10 }); // BUISSON
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 0 }); // EAU
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 12 }); // MAISON_ENTREE_1
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 12 }); // MAISON_ENTREE_2
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 12 }); // MAISON_ENTREE_3
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 12 }); // MAISON_ENTREE_4
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 12 }); // MAISON_ENTREE_5
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 13 }); // MAISON_ENTREE_6
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 13 }); // MAISON_ENTREE_7
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 13 }); // MAISON_ENTREE_8
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 13 }); // MAISON_ENTREE_9
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 13 }); // MAISON_ENTREE_10
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 14 }); // MAISON_ENTREE_11
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 14 }); // MAISON_ENTREE_12
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 14 }); // MAISON_ENTREE_13
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 14 }); // MAISON_ENTREE_14
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 14 }); // MAISON_ENTREE_15
            listeCoord.Add(new TileCoord() { Ligne = 4, Colonne = 15 }); // MAISON_ENTREE_16
            listeCoord.Add(new TileCoord() { Ligne = 5, Colonne = 15 }); // MAISON_ENTREE_17
            listeCoord.Add(new TileCoord() { Ligne = 6, Colonne = 15 }); // MAISON_ENTREE_18
            listeCoord.Add(new TileCoord() { Ligne = 7, Colonne = 15 }); // MAISON_ENTREE_19
            listeCoord.Add(new TileCoord() { Ligne = 8, Colonne = 15 }); // MAISON_ENTREE_20
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 24 }); // LION_BAS
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 24 }); // LION_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 26 }); // LION_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 18, Colonne = 28 }); // LION_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 16 }); // LICORNE_BAS
            listeCoord.Add(new TileCoord() { Ligne = 16, Colonne = 17 }); // LICORNE_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 18, Colonne = 16 }); // LICORNE_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 17, Colonne = 23 }); // LICORNE_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 16 }); // RHINO_BAS
            listeCoord.Add(new TileCoord() { Ligne = 20, Colonne = 23 }); // RHINO_HAUT
            listeCoord.Add(new TileCoord() { Ligne = 21, Colonne = 18 }); // RHINO_GAUCHE
            listeCoord.Add(new TileCoord() { Ligne = 22, Colonne = 22 }); // RHINO_DROITE
            listeCoord.Add(new TileCoord() { Ligne = 11, Colonne = 18 }); // PORTE_ENCLOS
            listeCoord.Add(new TileCoord() { Ligne = 23, Colonne = 0 }); // DECHET


            //TUILES DESIGNS
            listeBitmap.Add(LoadTile(GAZON));
            listeBitmap.Add(LoadTile(CLOTURE_PIERRE_HAUT));
            listeBitmap.Add(LoadTile(CLOTURE_PIERRE_COIN_GAUCHE));
            listeBitmap.Add(LoadTile(CLOTURE_PIERRE_COIN_HAUT_DROITE));
            listeBitmap.Add(LoadTile(CLOTURE_PIERRE_COIN_BAS_DROITE));
            listeBitmap.Add(LoadTile(CLOTURE_PIERRE_BAS_HAUT));
            listeBitmap.Add(LoadTile(ASPHALTE));
            listeBitmap.Add(LoadTile(GAZON_SABLE_HAUT_GAUCHE));
            listeBitmap.Add(LoadTile(GAZON_SABLE_HAUT_MILIEU));
            listeBitmap.Add(LoadTile(GAZON_SABLE_HAUT_DROITE));
            listeBitmap.Add(LoadTile(GAZON_SABLE_DROITE_MILIEU));
            listeBitmap.Add(LoadTile(GAZON_SABLE_BAS_DROITE));
            listeBitmap.Add(LoadTile(GAZON_SABLE_BAS_MILIEU));
            listeBitmap.Add(LoadTile(GAZON_SABLE_BAS_GAUCHE));
            listeBitmap.Add(LoadTile(GAZON_SABLE_GAUCHE_MILIEU));
            listeBitmap.Add(LoadTile(SABLE));
            listeBitmap.Add(LoadTile(BUISSON));
            listeBitmap.Add(LoadTile(EAU));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_1));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_2));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_3));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_4));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_5));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_6));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_7));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_8));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_9));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_10));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_11));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_12));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_13));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_14));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_15));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_16));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_17));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_18));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_19));
            listeBitmap.Add(LoadTile(MAISON_ENTREE_20));
            

            //ANIMAUX
            listeBitmap.Add(LoadTile(LION_BAS));
            listeBitmap.Add(LoadTile(LION_HAUT));
            listeBitmap.Add(LoadTile(LION_GAUCHE));
            listeBitmap.Add(LoadTile(LION_DROITE));
            listeBitmap.Add(LoadTile(LICORNE_BAS));
            listeBitmap.Add(LoadTile(LICORNE_HAUT));
            listeBitmap.Add(LoadTile(LICORNE_GAUCHE));
            listeBitmap.Add(LoadTile(LICORNE_DROITE));
            listeBitmap.Add(LoadTile(RHINO_BAS));
            listeBitmap.Add(LoadTile(RHINO_HAUT));
            listeBitmap.Add(LoadTile(RHINO_GAUCHE));
            listeBitmap.Add(LoadTile(RHINO_DROITE));
            listeBitmap.Add(LoadTile(PORTE_ENCLOS));

            listeBitmap.Add(LoadTile(DECHET));

        }

        private static Bitmap LoadTile(int posListe)
        {
            Image source = TP2.Properties.Resources.zoo_tileset;
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

    public class TileCoord
    {
        public int Ligne { get; set; }
        public int Colonne { get; set; }
    };
}
