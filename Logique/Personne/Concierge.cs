using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP2.Logique.Map;

namespace TP2.Logique
{
    public class Concierge : Personne
    {
        protected Bitmap asphalte = TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE);
        protected List<Dechet> _listeDechet = new List<Dechet>();
        protected static Random rand = new Random();
        private List<Visiteur> _listeVisiteur = new List<Visiteur>();
        private List<Concierge> _listeConcierge = new List<Concierge>();
        protected Hero hero;
        private Bitmap[] tabOrientation = {
            TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_DROITE),
            TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_GAUCHE),
            TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_HAUT),
            TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_BAS) };

        /// <summary>
        /// Constructeur pour créer une personne
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tab"></param>
        /// <param name="listeVisiteur"></param>
        /// <param name="listeDechet"></param>
        /// <param name="listeConcierge"></param>
        /// <param name="Hero"></param>
        public Concierge(int x, int y, Bitmap[,] tab, List<Visiteur> listeVisiteur, List<Dechet> listeDechet, List<Concierge> listeConcierge, Hero Hero) : base(x, y, tab)
        {
            _listeDechet = listeDechet;
            _listeConcierge = listeConcierge;
            _listeVisiteur = listeVisiteur;
            hero = Hero;
        }

        /// <summary>
        /// Vérifie qu'il y a aucun obstacle de visiteur, de concierges ou d'héro 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool VerifAucuneObstacle(int x, int y)
        {
            bool obstacle = false;
            foreach (Visiteur v in _listeVisiteur)
            {
                if (x == v.X && y == v.Y)
                {
                    obstacle = true;
                    break;
                }
            }
            foreach (Concierge c in _listeConcierge)
            {
                if (x == c.X && y == c.Y)
                {
                    obstacle = true;
                    break;
                }
            }
            if (x == hero.X && y == hero.Y)
            {
                obstacle = true;
            }

            return obstacle;
        }

        /// <summary>
        /// Déplacement du concierge
        /// </summary>
        public void DeplacementConcierge()
        {
            int direction = rand.Next(1, 5);
            switch (direction)
            {
                case 1: //Droite
                    if (X + 1 < TabAjout.GetLength(0) - 1)
                    {
                        if (TabAjout[X + 1, Y] == asphalte)
                        {
                            if (!VerifAucuneObstacle(X + 1, Y))
                            {
                                X += 1;
                                Orientation = "DROITE";
                            }
                        }
                    }
                    break;
                case 2: //Gauche
                    if (X - 1 > -1)
                    {
                        if (TabAjout[X - 1, Y] == asphalte)
                        {
                            if (!VerifAucuneObstacle(X - 1, Y))
                            {
                                X -= 1;
                                Orientation = "GAUCHE";
                            }
                        }
                    }

                    break;
                case 3: //Haut
                    if (Y - 1 > -1)
                    {
                        if (TabAjout[X, Y - 1] == asphalte)
                        {
                            if (!VerifAucuneObstacle(X, Y - 1))
                            {
                                Y -= 1;
                                Orientation = "HAUT";
                            }

                        }
                    }

                    break;
                case 4: //Bas
                    if (Y + 1 < TabAjout.GetLength(1) - 1)
                    {
                        if (TabAjout[X, Y + 1] == asphalte)
                        {
                            if (!VerifAucuneObstacle(X, Y + 1))
                            {
                                Y += 1;
                                Orientation = "BAS";
                            }

                        }
                    }
                    break;
            }
            _listeDechet = EnleverDechet(X, Y);
        }
        
        /// <summary>
        /// Méthode pour enlever un déchet si le concierge marche dessus
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private List<Dechet> EnleverDechet(int x, int y)
        {

            List<Dechet> listeTemp = _listeDechet;
            if (ValiderDechet(x, y))
            {
                int index = 0;
                foreach (Dechet d in listeTemp)
                {
                    if (d.X == x)
                    {
                        if (d.Y == y)
                        {
                            listeTemp.RemoveAt(index);
                            break;
                        }
                    }
                    index++;
                }
            }
            return listeTemp;
        }

        /// <summary>
        /// Valide que la tuile contient un déchet
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool ValiderDechet(int x, int y)
        {
            bool verification = false;
            foreach (Dechet d in _listeDechet)
            {
                if (d.X == x)
                {
                    if (d.Y == y)
                    {
                        verification = true;
                        break;
                    }
                }
            }
            return verification;
        }

        public Bitmap[] TabOrientation
        {
            get { return tabOrientation; }
        }
    }
}
