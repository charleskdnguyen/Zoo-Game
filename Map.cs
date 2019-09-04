using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.Logique;
using TP2.Logique.Map;

namespace TP2
{
    public partial class Map : UserControl
    {
        private Dechet dechet;
        private int nbDechet = 0;
        static Random rand = new Random();
        private Bitmap[,] tabGazon = new Bitmap[49, 24];
        private Bitmap[,] tabAjout = new Bitmap[49, 24];
        private Hero hero;
        private const int dimensionTuile = 32;
        private List<Visiteur> listeVisiteur = new List<Visiteur>();
        private List<Concierge> listeConcierge = new List<Concierge>();
        private List<Animal> listeAnimal = new List<Animal>();
        private List<Dechet> listeDechet = new List<Dechet>();

        /// <summary>
        /// Constructeur du User Control Map et ce qui s'initialise au départ
        /// </summary>
        public Map()
        {
            InitializeComponent();
            //test
            hero = new Hero(46, 20, tabAjout, listeVisiteur, listeConcierge, listeAnimal);
            for (int x = 0; x < tabGazon.GetLength(0); x++)
            {
                for (int y = 0; y < tabGazon.GetLength(1); y++)
                {
                    tabGazon[x, y] = TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON);
                }
            }

            for (int x = 0; x < tabAjout.GetLength(0); x++)
            {
                for (int y = 0; y < tabAjout.GetLength(1); y++)
                {
                    tabAjout[x, y] = TilesetImageGenerator.GetTile(TilesetImageGenerator.GAZON);
                }
            }
            RemplacementGazonEnclos(0, 1); //sable dans l'enclos
            AjoutTuileEnclos(0, 1, 14, 8); //enclos en haut à gauche
            AjoutTuileEnclos(17, 1, 14, 8); //enclos en haut au milieu
            AjoutTuileEnclos(34, 1, 14, 8); //enclos en haut à droite
            AjoutTuileEnclosRhino(0, 11, 31, 10); //gros enclos en bas a gauche
            AjoutTuileBuisson(14, 1, 3, 8); //buissons en haut a gauche
            AjoutTuileBuisson(31, 1, 3, 8); //buissons en haut a droite
            AjoutTuileBuisson(31, 11, 3, 12); //buissons en bas
            AjoutTuileBuisson(48, 1, 1, 22); //buisson seul a droite
            AjoutTuileBuisson(0, 0, 49, 1); //buisson en haut completement
            AjoutTuileRoute(0, 9, 49, 2); //route horizontale
            AjoutTuileRoute(33, 11, 16, 12); //route entrée
            AjoutTuileBuisson(47, 9, 2, 14);
            AjoutTuileDivers(43, 15, 4, 5, 18); //MAISON
            AjoutTuileDivers(7, 8, 1, 1, 50); //porte enclos en haut a gauche
            AjoutTuileDivers(24, 8, 1, 1, 50); //porte enclos en haut au milieu
            AjoutTuileDivers(41, 8, 1, 1, 50); //porte enclos en haut a droite
            AjoutTuileDivers(15, 11, 1, 1, 50); //porte enclos en bas

            //Pour enlever les screen flash quand on se deplace, le CreateParams n'aide pas
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer,
            true);
        }
        
        /// <summary>
        /// Méthode paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //Dessin initiale de la map
            for (int i = 0; i < tabGazon.GetLength(0); i++)
            {
                for (int j = 0; j < tabGazon.GetLength(1); j++)
                {
                    g.DrawImage(tabGazon[i, j], i * dimensionTuile, j * dimensionTuile, dimensionTuile, dimensionTuile);
                    g.DrawImage(tabAjout[i, j], i * dimensionTuile, j * dimensionTuile, dimensionTuile, dimensionTuile);

                }
            }
            //Dessiner hero
            int direction_h = hero.DeterminerOrientation();
            g.DrawImage(hero.TabOrientation[direction_h], hero.X * dimensionTuile, hero.Y * dimensionTuile, dimensionTuile, dimensionTuile);

            //Dessiner animaux
            foreach (Animal a in listeAnimal)
            {
                int direction = a.DeterminerOrientation();
                g.DrawImage(a.TabTypeAnimal[direction], a.X * dimensionTuile, a.Y * dimensionTuile, dimensionTuile, dimensionTuile);
            }

            //Dessiner visiteurs
            foreach (Visiteur v in listeVisiteur)
            {
                int direction = v.DeterminerOrientation();
                g.DrawImage(v.TabOrientation[direction], v.X * dimensionTuile, v.Y * dimensionTuile, dimensionTuile, dimensionTuile);
            }

            //Dessiner concierge
            foreach (Concierge c in listeConcierge)
            {
                int direction = c.DeterminerOrientation();
                g.DrawImage(c.TabOrientation[direction], c.X * dimensionTuile, c.Y * dimensionTuile, dimensionTuile, dimensionTuile);
                Bitmap[] testbmp = c.TabOrientation;
                //Console.WriteLine("Concierge: " + c.X + "," + c.Y);
            }

            //Dessiner dechet
            foreach (Dechet d in listeDechet)
            {
                g.DrawImage(TilesetImageGenerator.GetTile(TilesetImageGenerator.DECHET), d.X * dimensionTuile, d.Y * dimensionTuile, dimensionTuile, dimensionTuile);
            }

        }

        /// <summary>
        /// Ajout de l'enclos de rhinocéros en bas à gauche
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="longueur"></param>
        /// <param name="hauteur"></param>
        private void AjoutTuileEnclosRhino(int x, int y, int longueur, int hauteur)
        {
            //Il faudra changer dans tabGazon pour changer au sable pour l'esthetique
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {

                    if (i == 0 || i == longueur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_GAUCHE);
                    }
                    if (j == 0)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_HAUT);
                    }
                    if (j == hauteur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_BAS_HAUT);
                    }
                    if ((i == 0 && j == 0) || (i == 0 && j == hauteur - 1))
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_GAUCHE);
                    }
                    if (i == longueur - 1 && j == hauteur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_BAS_DROITE);
                    }
                    if (i == longueur - 1 && j == 0)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_HAUT_DROITE);
                    }
                }
            }
        }

        /// <summary>
        /// Ajouter un enclos d'animal
        /// </summary>
        /// <param name="x">Positionnement horizontale</param>
        /// <param name="y">Positionnement verticale</param>
        private void AjoutTuileEnclos(int x, int y, int longueur, int hauteur)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    if (i == 0 || i == longueur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_GAUCHE);
                    }
                    if (j == 0)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_HAUT);
                    }
                    if (j == hauteur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_BAS_HAUT);
                    }
                    if ((i == 0 && j == 0) || (i == 0 && j == hauteur - 1))
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_GAUCHE);
                    }
                    if (i == longueur - 1 && j == hauteur - 1)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_BAS_DROITE);
                    }
                    if (i == longueur - 1 && j == 0)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_HAUT_DROITE);
                    }
                }
            }
        }

        /// <summary>
        /// Ajout de la route
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="longueur"></param>
        /// <param name="hauteur"></param>
        private void AjoutTuileRoute(int x, int y, int longueur, int hauteur)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    if (i > 0)
                    {
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.ASPHALTE);
                    }
                }
            }
        }

        /// <summary>
        /// Ajout des buissons
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="longueur"></param>
        /// <param name="hauteur"></param>
        private void AjoutTuileBuisson(int x, int y, int longueur, int hauteur)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.BUISSON);
                }
            }
        }

        /// <summary>
        /// Ajout des tuiles divers dans le jeu
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="longueur"></param>
        /// <param name="hauteur"></param>
        /// <param name="tile"></param>
        private void AjoutTuileDivers(int x, int y, int longueur, int hauteur, int tile)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(tile);
                    tile += 1;
                }
            }
        }

        /// <summary>
        /// On écrase les tuiles de gazon par du sable
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void RemplacementGazonEnclos(int x, int y)
        {
            int longueur = 14;
            int hauteur = 8;
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    if (x + i > 0)
                    {
                        tabGazon[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE);
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.SABLE);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (x + i > 0)
                    {
                        tabGazon[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU);
                        tabAjout[x + i, y + j] = TilesetImageGenerator.GetTile(TilesetImageGenerator.EAU);
                    }
                }
            }
        }

        /// <summary>
        /// Méthode pour ajouter les déchets sur la map
        /// </summary>
        /// <param name="positionVisiteurX"></param>
        /// <param name="positionVisiteurY"></param>
        public void AjouterDechet(int positionVisiteurX, int positionVisiteurY)
        {
            bool dechetExistant = false; ;
            int nb = rand.Next(0, 101);

            foreach (Dechet d in listeDechet)
            {
                if (d.X == positionVisiteurX && d.Y == positionVisiteurY)
                {
                    dechetExistant = true;
                }
            }
            if (!dechetExistant)
            {
                //5% de chance de jeter un déchet
                if (nb > 24 && nb < 31)
                {
                    dechet = new Dechet(positionVisiteurX, positionVisiteurY);
                    listeDechet.Add(dechet);
                    nbDechet++;
                }
            }
        }

        /// <summary>
        /// Génération aléatoire du sexe de l'animal
        /// </summary>
        /// <returns></returns>
        private Sexe GenererSexe()
        {
            int aleatoire = rand.Next(0, 2);
            return (Sexe)(aleatoire == 0 ? Sexe.Homme : Sexe.Femme);
        }

        /// <summary>
        /// Ajouter un visiteur
        /// </summary>
        public void AjoutVisiteur()
        {
            Visiteur temp = new Visiteur(46, 21, GenererSexe(), tabAjout, listeVisiteur, listeConcierge, hero);
            listeVisiteur.Add(temp);
        }

        /// <summary>
        /// Ajouter un concierge
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjoutConcierge(int x, int y)
        {
            Concierge temp = new Concierge(x, y, tabAjout, listeVisiteur, listeDechet, listeConcierge, hero);
            listeConcierge.Add(temp);

        }

        /// <summary>
        /// Génération aléatoire du genre de l'animal
        /// </summary>
        /// <returns></returns>
        private Genre GenererGenreAnimal()
        {
            int aleatoire = rand.Next(0, 2);
            return (Genre)(aleatoire == 0 ? Genre.Male : Genre.Femelle);
        }

        /// <summary>
        /// Génère un animal adulte
        /// </summary>
        /// <returns></returns>
        private Vieillesse GenererVieillesseAnimal()
        {
            return Vieillesse.Adulte;
        }

        /// <summary>
        /// Génération aléatoire de l'état de faim de l'animal
        /// </summary>
        /// <returns></returns>
        private Etat GenererEtatAnimal()
        {
            int aleatoire = rand.Next(0, 2);
            return (Etat)(aleatoire == 0 ? Etat.Faim : Etat.Nourrit);
        }

        /// <summary>
        /// Génération aléatoire si l'animal est enceinte
        /// </summary>
        /// <returns></returns>
        private Enceinte GenererEnceinteAnimal()
        {
            int aleatoire = rand.Next(0, 2);
            return (Enceinte)(aleatoire == 0 ? Enceinte.Non : Enceinte.Oui);
        }

        /// <summary>
        /// Ajouter un lion adulte
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterAdulteLion(int x, int y)
        {
            Animal lion = new Lion(x, y, GenererGenreAnimal(), Vieillesse.Adulte, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Lion, listeAnimal, hero);
            if (lion.Genre == Genre.Femelle)
            {
                lion.Enceinte = lion.GenererEnceinteAnimal();
            }
            listeAnimal.Add(lion);
            AjoutVisiteur();
        }

        /// <summary>
        /// Ajouter un rhinocéros adulte
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterAdulteRhino(int x, int y)
        {
            Rhino rhino = new Rhino(x, y, GenererGenreAnimal(), Vieillesse.Adulte, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Rhino, listeAnimal, hero);
            if (rhino.Genre == Genre.Femelle)
            {
                rhino.Enceinte = rhino.GenererEnceinteAnimal();
            }
            listeAnimal.Add(rhino);
            AjoutVisiteur();
        }

        /// <summary>
        /// Ajouter une licorne adulte
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterAdulteLicorne(int x, int y)
        {
            Licorne licorne = new Licorne(x, y, GenererGenreAnimal(), Vieillesse.Adulte, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Licorne, listeAnimal, hero);
            if (licorne.Genre == Genre.Femelle)
            {
                licorne.Enceinte = licorne.GenererEnceinteAnimal();
            }
            listeAnimal.Add(licorne);
            AjoutVisiteur();
        }

        /// <summary>
        /// Ajouter un lion bébé
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterBebeLion(int x, int y)
        {
            Animal lion = new Lion(x, y, GenererGenreAnimal(), Vieillesse.Bebe, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Lion, listeAnimal, hero);
            lion.Enceinte = Enceinte.Non;
            listeAnimal.Add(lion);
            AjoutVisiteur();
        }

        /// <summary>
        /// Ajouter un rhinocéros bébé
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterBebeRhino(int x, int y)
        {
            Rhino rhino = new Rhino(x, y, GenererGenreAnimal(), Vieillesse.Bebe, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Rhino, listeAnimal, hero);
            rhino.Enceinte = Enceinte.Non;
            listeAnimal.Add(rhino);
            AjoutVisiteur();
        }

        /// <summary>
        /// Ajouter une licorne bébé
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void AjouterBebeLicorne(int x, int y)
        {
            Licorne licorne = new Licorne(x, y, GenererGenreAnimal(), Vieillesse.Bebe, GenererEtatAnimal(), tabAjout, Logique.TypeAnimal.Licorne, listeAnimal, hero);
            licorne.Enceinte = Enceinte.Non;
            listeAnimal.Add(licorne);
            AjoutVisiteur();
        }

        public Bitmap[,] GetTabAjout()
        {
            return tabAjout;
        }

        public Bitmap[,] GetTabGazon()
        {
            return tabGazon;
        }

        public Hero Hero
        {
            get { return hero; }
            set { hero = value; }
        }

        public List<Visiteur> GetListeVisiteurs()
        {
            return listeVisiteur;
        }



        public List<Animal> GetListeAnimal()
        {
            return listeAnimal;
        }

        public List<Concierge> GetListeConcierge()
        {
            return listeConcierge;
        }

        public List<Dechet> GetListeDechet()
        {
            return listeDechet;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
