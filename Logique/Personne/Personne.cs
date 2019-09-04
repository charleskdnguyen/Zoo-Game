using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Logique;
using System.Drawing;

namespace TP2
{
    public class Personne
    {
        protected static int DROITE = 0;
        protected static int GAUCHE = 1;
        protected static int HAUT = 2;
        protected static int BAS = 3;

        private int x;
        private int y;
        private int piedChangement = 0; // changer le nom du compteur
        private string orientation = "BAS";
        private static Bitmap[,] tabAjout = new Bitmap[49, 24];
        private int tempsZooPersonne;

        /// <summary>
        /// Constructeur d'une personne (visiteurs ou héro)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="tab"></param>
        public Personne(int X, int Y, Bitmap[,] tab)
        {
            x = X;
            y = Y;
            tabAjout = tab;
        }
        
        public Bitmap[,] TabAjout
        {
            get { return tabAjout; }
            set { tabAjout = value; }
        }
        public int Pied
        {
            get { return piedChangement; }
            set { piedChangement = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        
        /// <summary>
        /// Vérifie qu'il peut se déplace seulement sur une tuile de gazon, asphalte ou sable
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool VerifDeplacementObstacleDroite(Bitmap[,] tab)
        {
            if (tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x + 1 , y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vérifie qu'il peut se déplace seulement sur une tuile de gazon, asphalte ou sable
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool VerifDeplacementObstacleGauche(Bitmap[,] tab)
        {
            if (tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vérifie qu'il peut se déplace seulement sur une tuile de gazon, asphalte ou sable
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool VerifDeplacementObstacleHaut(Bitmap[,] tab)
        {
            if (tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vérifie qu'il peut se déplace seulement sur une tuile de gazon, asphalte ou sable
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool VerifDeplacementObstacleBas(Bitmap[,] tab)
        {
            if (tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Détermine la direction qu'il se déplace
        /// </summary>
        /// <returns></returns>
        public int DeterminerOrientation()
        {
            switch (Orientation)
            {
                case "DROITE": //Droite
                    return 0;
                case "GAUCHE":
                    return 1;
                case "HAUT":
                    return 2;
                case "BAS":
                    return 3;
                default:
                    return 3;
            }
        }

        /// <summary>
        /// Temps que les visiteurs sont dans le zoo
        /// </summary>
        public int TempsZooPersonne
        {
            get { return tempsZooPersonne; }
            set { tempsZooPersonne = value; }
        }

        public string Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }
    }
}
