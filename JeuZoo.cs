using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP2.Logique;
using TP2.Logique.Map;
using System.Media;

namespace TP2
{
    public partial class JeuZoo : Form
    {
        private const double PRIX_LION = 35;
        private const double PRIX_LICORNE = 50;
        private const double PRIX_RHINO = 40;
        private const double PROFIT_INITIAL = 100;
        private const double OUBLI_NOURRIR_ANIMAL = 2;

        private int nbLion = 0;
        private int nbLicorne = 0;
        private int nbRhino = 0;

        private double nourrirAnimal = 0;
        private int compteurVisiteurPeutQuitter = 0;
        private static Random rand = new Random();
        private static DateTime tempsJeu;
        private List<Visiteur> _listeVisiteur = new List<Visiteur>();
        private List<Animal> _listeAnimal = new List<Animal>();
        private List<Dechet> _listeDechet = new List<Dechet>();
        private List<Concierge> _listeConcierge = new List<Concierge>();

        SoundPlayer sonRhino = new System.Media.SoundPlayer(TP2.Properties.Resources.sonRhino);
        SoundPlayer sonLicorne = new System.Media.SoundPlayer(TP2.Properties.Resources.sonLicorne);
        SoundPlayer sonLion = new System.Media.SoundPlayer(TP2.Properties.Resources.sonLion);

        private static int compteurMinute = 0;
        double profitVisiteurAnimaux = 0;
        private static double nbDechet = 0;
        private static double profitTotal = 0;
        private static double penaliteAnimal = 0;
        
        /// <summary>
        /// Constructeur du JeuZoo
        /// </summary>
        public JeuZoo()
        {
            tempsJeu = DateTime.Today;
            InitializeComponent();
        }

        /// <summary>
        /// Lorsque le joueur pèse soit W-A-S-D pour se déplacer, on vérifie que la prochaine position est valide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) //Droite
            {
                if (Map.Hero.X + 1 < Map.GetTabGazon().GetLength(0)) ///////////////////////////////enlevé le -1 au get length 
                {
                    if (Map.Hero.VerifDeplacementObstacleDroite(Map.GetTabAjout()))
                    {
                        if (!Map.Hero.VerifAucuneObstacleHero(Map.Hero.X + 1, Map.Hero.Y))
                        {
                            Map.Hero.X += 1;
                            Map.Hero.Orientation = "DROITE";
                        }

                    }
                }
            }
            else if (e.KeyCode == Keys.A) // Gauche
            {
                if (Map.Hero.X - 1 > -1)
                {
                    if (Map.Hero.VerifDeplacementObstacleGauche(Map.GetTabAjout()))
                    {
                        if (!Map.Hero.VerifAucuneObstacleHero(Map.Hero.X - 1, Map.Hero.Y))
                        {
                            Map.Hero.X -= 1;
                            Map.Hero.Orientation = "GAUCHE";
                        }

                    }
                }
            }
            else if (e.KeyCode == Keys.W) // Haut
            {
                if (Map.Hero.Y - 1 > -1)
                {
                    if (Map.Hero.VerifDeplacementObstacleHaut(Map.GetTabAjout()) || Map.GetTabAjout()[Map.Hero.X, Map.Hero.Y - 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.PORTE_ENCLOS))
                    {
                        if (!Map.Hero.VerifAucuneObstacleHero(Map.Hero.X, Map.Hero.Y - 1))
                        {
                            Map.Hero.Y -= 1;
                            Map.Hero.Orientation = "HAUT";
                        }

                    }
                }
            }
            else if (e.KeyCode == Keys.S) // Bas
            {
                if (Map.Hero.Y + 1 < Map.GetTabGazon().GetLength(1) - 1)
                {
                    if (Map.Hero.VerifDeplacementObstacleBas(Map.GetTabAjout()) || Map.GetTabAjout()[Map.Hero.X, Map.Hero.Y + 1] == TilesetImageGenerator.GetTile(TilesetImageGenerator.PORTE_ENCLOS))
                    {
                        if (!Map.Hero.VerifAucuneObstacleHero(Map.Hero.X, Map.Hero.Y + 1))
                        {
                            Map.Hero.Y += 1;
                            Map.Hero.Orientation = "BAS";
                        }
                    }
                }
            }
            //Console.WriteLine(Map.Hero.X + " " + Map.Hero.Y);
            Refresh();
        }

        /// <summary>
        /// On calcule le profit du joueur selon les animaux, concierges, visiteurs et déchets présents dans le jeu
        /// </summary>
        /// <param name="listeVisiteur"></param>
        /// <param name="listeAnimal"></param>
        /// <param name="listeDechet"></param>
        /// <param name="listeConcierge"></param>
        /// <param name="profitVisiteurAnimaux"></param>
        /// <returns></returns>
        private double CalculProfit(List<Visiteur> listeVisiteur, List<Animal> listeAnimal, List<Dechet> listeDechet, List<Concierge> listeConcierge, double profitVisiteurAnimaux)
        {
            double totalFinal = 0;

            totalFinal = 
                 PROFIT_INITIAL +
                 (listeVisiteur.Count * 2 * listeAnimal.Count) -
                 (listeConcierge.Count * 2) -
                 (listeDechet.Count * 0.1) - 
                 (nbLicorne * PRIX_LICORNE) -
                 (nbLion * PRIX_LION) -
                 (nbRhino * PRIX_RHINO) -
                 nourrirAnimal +
                 profitVisiteurAnimaux - 
                 penaliteAnimal;

            return totalFinal;
        }

        /// <summary>
        /// On calcule le profit par minute
        /// </summary>
        /// <returns></returns>
        private double CalculProfitMinute()
        {
            double profit;
            if (compteurMinute == 60)
            {
                profitVisiteurAnimaux += _listeAnimal.Count * _listeVisiteur.Count;
                compteurMinute = 0;
            }
            profit = CalculProfit(_listeVisiteur, _listeAnimal, _listeDechet, _listeConcierge, profitVisiteurAnimaux);
            return profit;
        }

        /// <summary>
        /// Vérifie que le visiteur peut quitter le zoo et génère les déchets
        /// </summary>
        /// <param name="liste"></param>
        /// <returns></returns>
        private List<Visiteur> ThreadVisiteurQuitterZoo(List<Visiteur> liste)
        {
            compteurVisiteurPeutQuitter = 0;
            foreach (Visiteur v in liste)
            {
                v.TempsVisiteur++;
                if (v.PeutQuitter() && (v.X == 45 && v.Y == 20))
                {
                    v.ArreterDeplacement();
                    liste.RemoveAt(compteurVisiteurPeutQuitter);
                    Console.WriteLine("visiteurs supprimé");
                    Map.AjoutVisiteur();
                    break;
                }
                compteurVisiteurPeutQuitter++; //parcours la liste de visiteur
                Map.AjouterDechet(v.X, v.Y); //5% de chance de jeter des dechets
            }
            return liste;
        }

        /// <summary>
        /// Exécute le thread du jeu au complet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerJeu_Tick(object sender, EventArgs e)
        {
            _listeVisiteur = Map.GetListeVisiteurs();
            _listeAnimal = Map.GetListeAnimal();
            _listeConcierge = Map.GetListeConcierge();
            _listeDechet = Map.GetListeDechet();
            //Ajoute un nouvel animal si la mère est enceinte
            VerifCreerBebe();

            //Les animaux bébés deviennent de adults
            MatureBebe();

            //Vérifie que les animaux sont nourrit, sinon il y aura une pénalité
            PenaliteNourrirAnimal();

            //Deplacement des visiteurs, animaux et concierges
            ExecuterDeplacement();

            //Supprime un visiteur si il est présent plus que 60 secondes et marche sur une porte de sortie
            _listeVisiteur = ThreadVisiteurQuitterZoo(_listeVisiteur);

            //Calcul du profit
            profitTotal = CalculProfitMinute();

            //Update des labels sur l'interface
            tempsJeu = tempsJeu.AddDays(1);
            LblJourModifier.Text = tempsJeu.ToLongDateString();
            LblProfitModifier.Text = String.Format("{0:N2}" + "$", profitTotal);
            LblNbAnimauxModifier.Text = _listeAnimal.Count.ToString();
            LblNombreDechet.Text = _listeDechet.Count.ToString();

            compteurMinute++;
            Refresh();
        }

        /// <summary>
        /// Le bébé devient un adulte après un certain nombre de jour
        /// </summary>
        private void MatureBebe()
        {
            foreach (Animal a in _listeAnimal)
            {
                if (a.TypeAnimal == TypeAnimal.Lion && a.Vieillesse == Vieillesse.Bebe && a.TempsZooAnimal > 110)
                {
                    a.Vieillesse = Vieillesse.Adulte;
                    break;
                }
                else if (a.TypeAnimal == TypeAnimal.Rhino && a.Vieillesse == Vieillesse.Bebe && a.TempsZooAnimal > 480) 
                {
                    a.Vieillesse = Vieillesse.Adulte;
                    break;
                }
                else if (a.TypeAnimal == TypeAnimal.Licorne && a.Vieillesse == Vieillesse.Bebe && a.TempsZooAnimal > 360) 
                {
                    a.Vieillesse = Vieillesse.Adulte;
                    break;
                }
            }
        }

        /// <summary>
        /// Si une femelle est enceinte, un bébé va naitre après un certain nombre de jour
        /// </summary>
        private void VerifCreerBebe()
        {
            foreach (Animal a in _listeAnimal)
            {
                if (a.Enceinte == Enceinte.Oui && a.Genre == Genre.Femelle && a.TypeAnimal == TypeAnimal.Lion && a.TempsZooAnimal > 110) 
                {
                    a.Enceinte = Enceinte.Non;
                    Map.AjouterBebeLion(24, 5);
                    break;
                }
                else if (a.Enceinte == Enceinte.Oui && a.Genre == Genre.Femelle && a.TypeAnimal == TypeAnimal.Rhino && a.TempsZooAnimal > 480) 
                {
                    a.Enceinte = Enceinte.Non;
                    Map.AjouterBebeRhino(5, 5);
                    break;
                }
                else if (a.Enceinte == Enceinte.Oui && a.Genre == Genre.Femelle && a.TypeAnimal == TypeAnimal.Licorne && a.TempsZooAnimal > 360) 
                {
                    if (((Map.Hero.X > 34 && Map.Hero.X < 48) && (Map.Hero.Y > 1 && Map.Hero.Y < 8)))
                    {
                        a.Enceinte = Enceinte.Non;
                        Map.AjouterBebeLicorne(44, 5);
                        break;
                    }
                    else if (((Map.Hero.X > 0 && Map.Hero.X < 31) && (Map.Hero.Y > 11 && Map.Hero.Y < 21)))
                    {
                        a.Enceinte = Enceinte.Non;
                        Map.AjouterBebeLicorne(20, 18);
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Contravention de 2$ si l'animal n'est pas nourrit dans le temps approprié
        /// </summary>
        private void PenaliteNourrirAnimal()
        {
            foreach (Animal a in _listeAnimal)
            {
                //Si l'animal est un lion
                if (a.Etat == Etat.Faim && a.TempsZooAnimal > 120 && a.TypeAnimal == TypeAnimal.Lion)
                {
                    a.Etat = Etat.Nourrit;
                    penaliteAnimal += 2;
                }
                //Si l'animal est une licorne ou un rhinocéros
                else if (a.Etat == Etat.Faim && a.TempsZooAnimal > 180 && (a.TypeAnimal == TypeAnimal.Rhino || a.TypeAnimal == TypeAnimal.Licorne)) 
                {
                    a.Etat = Etat.Nourrit;
                    penaliteAnimal += 2;
                }
            }
        }

        /// <summary>
        /// On exécute les déplacements du concierge, des visiteurs et des animaux
        /// </summary>
        private void ExecuterDeplacement()
        {
            Map.Hero.Animation_Hero();
            foreach (Concierge c in _listeConcierge)
            {
                c.DeplacementConcierge();
            }
            foreach (Visiteur v in _listeVisiteur)
            {
                if (v.SeDeplacer)
                {
                    v.DeplacementVisiteur();
                    v.TempsZooPersonne++;
                }
            }
            foreach (Animal a in _listeAnimal)
            {
                a.DeplacementAnimal();
                a.TempsZooAnimal++;
            }
        }

        /// <summary>
        /// Intéraction du joueur avec la souris selon le click gauche ou droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            InformationAnimal.Visible = false;
            InformationVisiteur.Visible = false;
            bool animalPresent = false;
            String animalDeterminer = DeterminerEnclos();
            int x = e.X / 32;
            int y = e.Y / 32;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (EstAdjacentHero(x, y))
                    {
                        if (EstDansEnclos())
                        {
                            foreach (Animal a in _listeAnimal)
                            {
                                if (x + 1 > a.X && x - 1 < a.X)
                                {
                                    if (y + 1 > a.Y && y - 1 < a.Y)
                                    {
                                        //On nourrit l'animal et il émet un son
                                        animalPresent = true;
                                        a._etat = Etat.Nourrit;
                                        switch (animalDeterminer)
                                        {
                                            case "RHINO":
                                                sonRhino.Play();
                                                nourrirAnimal++;
                                                break;
                                            case "LION":
                                                sonLion.Play();
                                                nourrirAnimal++;
                                                break;
                                            case "LICORNE":
                                                sonLicorne.Play();
                                                nourrirAnimal++;
                                                break;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (!animalPresent)
                            {
                                if (animalDeterminer != "")
                                {
                                    if (!SurEnclos(x, y))
                                    {
                                        //On ajoute un animal dans l'enclos
                                        switch (animalDeterminer)
                                        {
                                            case "RHINO":
                                                Map.AjouterAdulteRhino(x, y);
                                                nbRhino++;
                                                break;
                                            case "LION":
                                                Map.AjouterAdulteLion(x, y);
                                                nbLion++;
                                                break;
                                            case "LICORNE":
                                                Map.AjouterAdulteLicorne(x, y);
                                                nbLicorne++;
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //On ramasse le déchet si c'est adjacent au héro
                            if (ValiderDechet(x, y))
                            {
                                List<Dechet> listeTemp = _listeDechet;
                                int index = 0;
                                foreach (Dechet d in listeTemp)
                                {
                                    if (d.X == x)
                                    {
                                        if (d.Y == y)
                                        {
                                            listeTemp.RemoveAt(index);
                                            _listeDechet = listeTemp;
                                            nbDechet = _listeDechet.Count;
                                            break;
                                        }
                                    }
                                    index++;
                                }
                            }
                            else
                            {
                                bool dechetExistant = false;
                                if (!(Map.GetTabAjout()[Map.Hero.X, Map.Hero.Y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.PORTE_ENCLOS)))
                                {
                                    foreach (Dechet d in _listeDechet)
                                    {
                                        if (d.X == x && d.Y == y)
                                        {
                                            dechetExistant = true;
                                            break;
                                        }
                                    }
                                    //On ajoute un concierge
                                    if (!dechetExistant)
                                    {
                                        Map.AjoutConcierge(x, y);
                                    }

                                }

                            }
                        }
                    }
                    break;
                case MouseButtons.Right:
                    if (!EstAdjacentHero(x, y))
                    {
                        int indexAnimal = 0;
                        int indexVisiteur = 0;
                        foreach (Animal a in _listeAnimal)
                        {
                            if (x + 1 > a.X && x - 1 < a.X)
                            {
                                if (y + 1 > a.Y && y - 1 < a.Y) //il faut viser en bas a gauche du carre, j'ai ajouter + 1 ou - 1 pour une marge d'erreur
                                {
                                    //On affiche les informations de l'animal avec le User Control
                                    InformationAnimal.AfficherInformationAnimal(_listeAnimal, indexAnimal);
                                    InformationAnimal.Visible = true;
                                    break;
                                }
                            }
                            indexAnimal++;
                        }
                        indexAnimal = 0;

                        foreach (Visiteur v in _listeVisiteur)
                        {
                            if (x + 1 > v.X && x - 1 < v.X)
                            {
                                if (y + 1 > v.Y && y - 1 < v.Y) //il faut viser en bas a gauche du carre, j'ai ajouter + 1 ou - 1 pour une marge d'erreur
                                {
                                    //On affiche les informations du visiteur avec le User Control
                                    InformationVisiteur.AfficherInformationsVisiteur(_listeVisiteur, indexVisiteur);
                                    InformationVisiteur.Visible = true;
                                    break;
                                }
                            }
                            indexVisiteur++;
                        }
                        indexVisiteur = 0;
                    }
                    break;
            }
        }

        /// <summary>
        /// On valide que c'est un déchet situé à une certain position
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
                    else
                    {
                        verification = false;
                    }
                }
            }
            return verification;
        }

        /// <summary>
        /// On vérifie que le joueur n'a pas cliqué sur un enclos (utilisé avec !)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool SurEnclos(int x, int y)
        {
            if (Map.GetTabAjout()[x, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_HAUT) ||
                Map.GetTabAjout()[x, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_HAUT_DROITE) ||
                Map.GetTabAjout()[x, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_GAUCHE) ||
                Map.GetTabAjout()[x, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_COIN_BAS_DROITE) ||
                Map.GetTabAjout()[x, y] == TilesetImageGenerator.GetTile(TilesetImageGenerator.CLOTURE_PIERRE_BAS_HAUT))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// On vérifie que le héro est dans l'enclos
        /// </summary>
        /// <returns></returns>
        private bool EstDansEnclos()
        {
            if (((Map.Hero.X > 0 && Map.Hero.X < 14) && (Map.Hero.Y > 1 && Map.Hero.Y < 8))
                || ((Map.Hero.X > 17 && Map.Hero.X < 31) && (Map.Hero.Y > 1 && Map.Hero.Y < 8))
                || ((Map.Hero.X > 34 && Map.Hero.X < 48) && (Map.Hero.Y > 1 && Map.Hero.Y < 8))
                || ((Map.Hero.X > 0 && Map.Hero.X < 31) && (Map.Hero.Y > 11 && Map.Hero.Y < 21)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// On vérifie que le click est adjacent au héro
        /// </summary>
        /// <param name="click_x"></param>
        /// <param name="click_y"></param>
        /// <returns></returns>
        private bool EstAdjacentHero(int click_x, int click_y)
        {
            if (click_x <= Map.Hero.X + 1 && click_x >= Map.Hero.X - 1)
            {
                if (click_y <= Map.Hero.Y + 1 && click_y >= Map.Hero.Y - 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// On détermine dans quel enclos le héro est situé
        /// </summary>
        /// <returns></returns>
        private string DeterminerEnclos()
        {
            String animal = "";
            if (((Map.Hero.X > 0 && Map.Hero.X < 14) && (Map.Hero.Y > 1 && Map.Hero.Y < 8)))
            {
                animal = "RHINO";
            }
            else if (((Map.Hero.X > 17 && Map.Hero.X < 31) && (Map.Hero.Y > 1 && Map.Hero.Y < 8)))
            {
                animal = "LION";
            }
            else if (((Map.Hero.X > 34 && Map.Hero.X < 48) && (Map.Hero.Y > 1 && Map.Hero.Y < 8)))
            {
                animal = "LICORNE";
            }
            else if (((Map.Hero.X > 0 && Map.Hero.X < 31) && (Map.Hero.Y > 11 && Map.Hero.Y < 21)))
            {
                animal = "LICORNE";
            }
            return animal;
        }

        /// <summary>
        /// Lorsqu'on quitte le jeu, un message nous montre le profit total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JeuZoo_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bravo! Votre profit est de: " + profitTotal + "$.", "Fin de jeu");
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
