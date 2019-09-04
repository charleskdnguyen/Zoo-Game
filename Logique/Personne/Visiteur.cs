using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP2.Logique;

namespace TP2.Logique
{
    public enum Sexe { Homme, Femme };

    public class Visiteur : Personne
    {
        protected bool seDeplacer = true;
        protected int tempsVisiteur = 0;
        protected Sexe _sexe;
        protected string nom;
        private static Random rand = new Random();
        private Bitmap[] tabOrientation = new Bitmap[4];
        private string[] listeNoms = { //Liste des noms des visiteurs
            "John Smith",
            "Johnny Cage",
            "Carol Danvers",
            "Nick Fury",
            "Tony Stark",
            "Steve Rogers",
            "Thor Thor",
            "Clint Barton",
            "Natasha Romanoff",
            "James Rhodes",
            "Bruce Banner",
            "Scott Lang",
            "Stephen Strange",
            "T'Challa Panther",
            "Peter Parker",
            "Wanda Maximoff",
            "Sam Wilson",
            "Bucky Barnes" };


        private List<Visiteur> _listeVisiteur = new List<Visiteur>();
        private List<Concierge> _listeConcierge = new List<Concierge>();
        Hero hero;

        /// <summary>
        /// Constructeur pour créer un visiteur
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="s"></param>
        /// <param name="tab"></param>
        /// <param name="listeVisiteur"></param>
        /// <param name="listeConcierge"></param>
        /// <param name="Hero"></param>
        public Visiteur(int x, int y, Sexe s, Bitmap[,] tab, List<Visiteur> listeVisiteur, List<Concierge> listeConcierge, Hero Hero) : base(x, y, tab)
        {
            _sexe = s;
            nom = listeNoms[GenererNom()];
            tabOrientation = DeterminerVisiteur();
            _listeConcierge = listeConcierge;
            _listeVisiteur = listeVisiteur;
            hero = Hero;
        }

        /// <summary>
        /// Vérifie que son prochain mouvement n'écrase pas d'autres visiteurs ni l'héro
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
        /// Génère le nom du visiteur
        /// </summary>
        /// <returns></returns>
        private int GenererNom()
        {
            return rand.Next(0, 18);
        }

        /// <summary>
        /// Determine quel image de visiteur on utilise
        /// </summary>
        /// <returns></returns>
        private Bitmap[] DeterminerVisiteur()
        {
            Bitmap[] tab = new Bitmap[4];
            int visiteur = rand.Next(1, 9);
            switch (visiteur)
            {
                case 1: //Droite
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_1_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_1_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_1_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_1_BAS);
                    break;
                case 2:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_2_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_2_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_2_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_2_BAS);
                    break;
                case 3:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_3_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_3_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_3_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_3_BAS);
                    break;
                case 4:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_4_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_4_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_4_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_4_BAS);
                    break;
                case 5:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_5_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_5_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_5_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_5_BAS);
                    break;
                case 6:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_6_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_6_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_6_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_6_BAS);
                    break;
                case 7:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_7_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_7_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_7_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_7_BAS);
                    break;
                case 8:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_8_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_8_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_8_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_8_BAS);
                    break;
                case 9:
                    tab[0] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_DROITE);
                    tab[1] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_GAUCHE);
                    tab[2] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_HAUT);
                    tab[3] = TilesetVisiteurGenerator.GetTile(TilesetVisiteurGenerator.VISITEUR_9_BAS);
                    break;
            }
            return tab;
        }

        /// <summary>
        /// Vérification du prochain mouvement de visiteurs et applique l'image approprié
        /// </summary>
        public void DeplacementVisiteur()
        {
            int direction = rand.Next(1, 5);
            switch (direction)
            {
                case 1: //Droite
                    if (X + 1 < TabAjout.GetLength(0) - 1)
                    {
                        if (VerifDeplacementObstacleDroite(TabAjout))
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
                        if (VerifDeplacementObstacleGauche(TabAjout))
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
                        if (VerifDeplacementObstacleHaut(TabAjout))
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
                        if (VerifDeplacementObstacleBas(TabAjout))
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
        /// Arrête son déplacement
        /// </summary>
        public void ArreterDeplacement()
        {
            seDeplacer = false;
        }

        /// <summary>
        /// Vérifie que le visiteur peut quitter après 60 secondes dans le zoo
        /// </summary>
        /// <returns></returns>
        public bool PeutQuitter()
        {
            return (bool)(tempsVisiteur > 60 ? true : false);
        }

        public Sexe GetSexe
        {
            get { return _sexe; }
            set { _sexe = value; }
        }

        public int TempsVisiteur
        {
            get { return tempsVisiteur; }
            set { tempsVisiteur = value; }
        }

        public string GetNom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Bitmap[] TabOrientation
        {
            get { return tabOrientation; }
        }
        public bool SeDeplacer
        {
            get { return seDeplacer; }
        }
    }
}
