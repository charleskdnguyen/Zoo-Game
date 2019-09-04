using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TP2.Logique
{
    class Licorne : Animal
    {
        /// <summary>
        /// Constructeur pour créer une licorne
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
        public Licorne(int X, int Y, Genre genre, Vieillesse vieillesse, Etat etat, Bitmap[,] tab, TypeAnimal type, List<Animal> listeAnimal, Hero Hero) : base(X, Y, Genre.Male, Vieillesse.Adulte, Etat.Nourrit, tab, TypeAnimal.Licorne,listeAnimal,Hero)
        {
            _etat = etat;
            _genre = genre;
            _vieillesse = vieillesse;
            _type = type;
            tabTypeAnimal = DeterminerAnimal(TypeAnimal.Licorne);
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
               || tab[x + 1, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE))
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
        /// Vérifier que le déplacement en haut est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleHaut(Bitmap[,] tab)
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
        /// Vérifier que le déplacement en bas est valide
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        override
        protected bool VerifDeplacementObstacleBas(Bitmap[,] tab)
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
    }
}
