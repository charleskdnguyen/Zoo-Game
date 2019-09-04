using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Logique
{
    public class Hero : Personne
    {

        private List<Visiteur> _listeVisiteur = new List<Visiteur>();
        private List<Concierge> _listeConcierge = new List<Concierge>();
        private List<Animal> _listeAnimal = new List<Animal>();
        private Bitmap[] tabOrientation = { TP2.Properties.Resources.herodroite1, TP2.Properties.Resources.herogauche1, TP2.Properties.Resources.herohaut1, TP2.Properties.Resources.herobas1 };
        public Hero(int x, int y, Bitmap[,] tab, List<Visiteur> listeVisiteur, List<Concierge> listeConcierge, List<Animal> listeAnimal) : base(x, y, tab)
        {
            _listeVisiteur = listeVisiteur;
            _listeConcierge = listeConcierge;
            _listeAnimal = listeAnimal;
        }
        public Bitmap[] TabOrientation
        {
            get { return tabOrientation; }
        }
        
        /// <summary>
        /// Animation de l'héro et change l'image dépendant de la direction qu'il se déplace
        /// </summary>
        public void Animation_Hero()
        {
            switch (Orientation)
            {
                case "DROITE": 
                    if (Pied == 0)
                    {
                        tabOrientation[DROITE] = TP2.Properties.Resources.herodroite1;
                        Pied++;
                    }
                    else
                    {
                        tabOrientation[DROITE] = TP2.Properties.Resources.herodroite2;
                        Pied = 0;
                    }
                    break;
                case "GAUCHE":
                    if (Pied == 0)
                    {
                        tabOrientation[GAUCHE] = TP2.Properties.Resources.herogauche1;
                        Pied++;
                    }
                    else
                    {
                        tabOrientation[GAUCHE] = TP2.Properties.Resources.herogauche2;
                        Pied = 0;
                    }
                    break;
                case "HAUT": 
                    if (Pied == 0)
                    {
                        tabOrientation[HAUT] = TP2.Properties.Resources.herohaut2;
                        Pied++;
                    }
                    else
                    {
                        tabOrientation[HAUT] = TP2.Properties.Resources.herohaut3;
                        Pied = 0;
                    }
                    break;
                case "BAS":
                    if (Pied == 0)
                    {
                        tabOrientation[BAS] = TP2.Properties.Resources.herobas2;
                        Pied++;
                    }
                    else
                    {
                        tabOrientation[BAS] = TP2.Properties.Resources.herobas3;
                        Pied = 0;
                    }
                    break;
            }
        }

        /// <summary>
        /// Vérifie que le héro ne peut écraser un visiteur, concierges ou animaux
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool VerifAucuneObstacleHero(int x, int y)
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
            foreach (Animal a in _listeAnimal)
            {
                if (x == a.X && y == a.Y)
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
            return obstacle;
        }
    }
}
