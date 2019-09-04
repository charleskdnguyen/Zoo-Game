using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Logique
{
    class Rhino : Animal
    {
        /// <summary>
        /// Constructeur pour créer un rhinocéros
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="genre"></param>
        /// <param name="vieillesse"></param>
        /// <param name="etat"></param>
        /// <param name="tab"></param>
        /// <param name="type"></param>
        /// <param name="listeAnimal"></param>
        /// <param name="Hero"></param>
        public Rhino(int X, int Y, Genre genre, Vieillesse vieillesse, Etat etat, Bitmap[,] tab, TypeAnimal type, List<Animal> listeAnimal, Hero Hero) : base(X, Y, Genre.Male, Vieillesse.Adulte, Etat.Nourrit, tab, TypeAnimal.Rhino,listeAnimal,Hero)
        {
            _etat = etat;
            _genre = genre;
            _vieillesse = vieillesse;
            _type = type;
            tabTypeAnimal = DeterminerAnimal(TypeAnimal.Rhino);
        }

        /// <summary>
        /// Vérifier que le déplacement à droite est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleDroite(Bitmap[,] tab)
        {
            if (tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE)
               || tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vérifier que le déplacement à gauche est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleGauche(Bitmap[,] tab)
        {
            if (tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE)
               || tab[x - 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Vérifier que le déplacement en haut est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleHaut(Bitmap[,] tab)
        {
            if (tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE)
               || tab[x, y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vérifier que le déplacement en bas est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleBas(Bitmap[,] tab)
        {
            if (tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE)
               || tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON)
               || tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE)
               || tab[x, y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
