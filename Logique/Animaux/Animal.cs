using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Logique;

namespace TP2.Logique
{
    public enum Genre { Male, Femelle };
    public enum Vieillesse { Adulte, Bebe };
    public enum Etat { Nourrit, Faim };
    public enum TypeAnimal { Rhino, Licorne, Lion };
    public enum Enceinte { Oui, Non };
    abstract public class Animal
    {
        //ORIENTATION
        protected static int DROITE = 0;
        protected static int GAUCHE = 1;
        protected static int HAUT = 2;
        protected static int BAS = 3;

        //protected Bitmap[,] tabDeplacement = new Bitmap[49, 24];
        protected Bitmap[] tabTypeAnimal = new Bitmap[4];
        protected static Bitmap[,] tabAjout = new Bitmap[49, 24];

        protected int tempsZooAnimal;
        protected Genre _genre;
        protected Enceinte _enceinte= Enceinte.Non;
        protected Vieillesse _vieillesse;
        public Etat _etat;
        public TypeAnimal _type;
        protected int x;
        protected int y;
        private string orientation = "BAS";
        public static int nbTotalAnimaux;
        protected static Random rand = new Random();
        private List<Animal> _listeAnimal = new List<Animal>();
        private Hero hero;
        /// <summary>
        /// Constructeur pour créer un animal
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="genre"></param>
        /// <param name="age"></param>
        /// <param name="etat"></param>
        /// <param name="tab"></param>
        /// <param name="type"></param>
        /// <param name="listeAnimal"></param>
        /// <param name="Hero"></param>
        public Animal(int X, int Y, Genre genre, Vieillesse age, Etat etat, Bitmap[,] tab, TypeAnimal type, List<Animal> listeAnimal, Hero Hero)
        {
            x = X;
            y = Y;
            _genre = genre;
            _vieillesse = age;
            _etat = etat;
            _type = type;
            hero = Hero;
            _listeAnimal = listeAnimal;

            
            nbTotalAnimaux++;

            tabAjout = tab;
            tabTypeAnimal = DeterminerAnimal(_type);
            //deplacement.Elapsed += DeplacementAnimal;
            //deplacement.Start();
        }

        /// <summary>
        /// position X de l'animal
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// position Y de l'animal
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Vérifie qu'il y a aucun obstacle d'animal et du héro
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool VerifAucuneObstacle(int x, int y)
        {
            bool obstacle = false;

            foreach (Animal a in _listeAnimal)
            {
                if (x == a.X && y == a.Y)
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
        /// Détermine le type d'animal à créer
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected Bitmap[] DeterminerAnimal(TypeAnimal type)
        {
            Bitmap[] tab = new Bitmap[4];
            switch (type)
            {
                case TypeAnimal.Licorne: //LICORNE
                    tab[0] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LICORNE_BAS);
                    tab[1] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LICORNE_HAUT);
                    tab[2] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LICORNE_GAUCHE);
                    tab[3] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LICORNE_DROITE);
                    break;
                case TypeAnimal.Lion: //LION
                    tab[0] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LION_BAS);
                    tab[1] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LION_GAUCHE);
                    tab[2] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LION_HAUT);
                    tab[3] = TilesetImageGenerator.GetTile(TilesetImageGenerator.LION_DROITE);
                    break;
                case TypeAnimal.Rhino: //RHINO
                    tab[0] = TilesetImageGenerator.GetTile(TilesetImageGenerator.RHINO_BAS);
                    tab[1] = TilesetImageGenerator.GetTile(TilesetImageGenerator.RHINO_GAUCHE);
                    tab[2] = TilesetImageGenerator.GetTile(TilesetImageGenerator.RHINO_HAUT);
                    tab[3] = TilesetImageGenerator.GetTile(TilesetImageGenerator.RHINO_DROITE);
                    break;
            }
            return tab;
        }

        /// <summary>
        /// Exécute le déplacement de l'animal et l'image à changer
        /// </summary>
        public void DeplacementAnimal()
        {
            int direction = rand.Next(1, 5);
            switch (direction)
            {

                case 1: //Droite
                    if (X + 1 < TabAjout.GetLength(0) - 1)
                    {
                        if (VerifDeplacementObstacleDroite(TabAjout) && VerifDeplacementObstacleHeroDroite(tabAjout))
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
                        if (VerifDeplacementObstacleGauche(TabAjout) && VerifDeplacementObstacleHeroGauche(tabAjout))
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
                        if (VerifDeplacementObstacleHaut(TabAjout) && VerifDeplacementObstacleHeroHaut(tabAjout))
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
                        if (VerifDeplacementObstacleBas(TabAjout) && VerifDeplacementObstacleHeroBas(tabAjout))
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
        }

        /// <summary>
        /// Détermine où regarde l'animal
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
        /// Getter pour Orientation
        /// </summary>
        public string Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        /// <summary>
        /// Vérifie si le héro se situe à gauche de l'animal
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        private bool VerifDeplacementObstacleHeroGauche(Bitmap[,] tab)
        {
            if (tab[x - 1, y] == TP2.Properties.Resources.herohaut1
               || tab[x - 1, y] == TP2.Properties.Resources.herohaut2
               || tab[x - 1, y] == TP2.Properties.Resources.herohaut3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie si le héro se situe à droite de l'animal
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        private bool VerifDeplacementObstacleHeroDroite(Bitmap[,] tab)
        {
            if (tab[x + 1, y] == TP2.Properties.Resources.herohaut1
               || tab[x + 1, y] == TP2.Properties.Resources.herohaut2
               || tab[x + 1, y] == TP2.Properties.Resources.herohaut3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie si le héro se situe en haut de l'animal
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        private bool VerifDeplacementObstacleHeroHaut(Bitmap[,] tab)
        {
            if (tab[x, y - 1] == TP2.Properties.Resources.herohaut1
               || tab[x, y - 1] == TP2.Properties.Resources.herohaut2
               || tab[x, y - 1] == TP2.Properties.Resources.herohaut3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Vérifie si le héro se situe en bas de l'animal
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        private bool VerifDeplacementObstacleHeroBas(Bitmap[,] tab)
        {
            if (tab[x, y + 1] == TP2.Properties.Resources.herohaut1
               || tab[x, y + 1] == TP2.Properties.Resources.herohaut2
               || tab[x, y + 1] == TP2.Properties.Resources.herohaut3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Méthodes abstract pour vérifier les animaux et les obstacles
        abstract protected bool VerifDeplacementObstacleDroite(Bitmap[,] tab);
        abstract protected bool VerifDeplacementObstacleGauche(Bitmap[,] tab);
        abstract protected bool VerifDeplacementObstacleHaut(Bitmap[,] tab);
        abstract protected bool VerifDeplacementObstacleBas(Bitmap[,] tab);

        public Bitmap[,] TabAjout
        {
            get { return tabAjout; }
            set { tabAjout = value; }
        }

        public Bitmap[] TabTypeAnimal
        {
            get { return tabTypeAnimal; }
        }

        public Genre Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public Vieillesse Vieillesse
        {
            get { return _vieillesse; }
            set { _vieillesse = value; }
        }
        public Etat Etat
        {
            get { return _etat; }
            set { _etat = value; }
        }
        public TypeAnimal TypeAnimal
        {
            get { return _type; }
            set { _type = value; }
        }
        public Enceinte Enceinte
        {
            get { return _enceinte; }
            set { _enceinte = value; }
        }

        public Enceinte GenererEnceinteAnimal()
        {
            int aleatoire = rand.Next(0, 2);
            return (Enceinte)(aleatoire == 0 ? Enceinte.Non : Enceinte.Oui);
        }

        /// <summary>
        /// Temps que l'animal est dans le zoo
        /// </summary>
        public int TempsZooAnimal
        {
            get { return tempsZooAnimal; }
            set { tempsZooAnimal = value; }
        }
    }
}
