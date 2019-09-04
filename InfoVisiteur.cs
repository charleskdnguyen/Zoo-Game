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

namespace TP2
{
    public partial class InfoVisiteur : UserControl
    {
        List<Visiteur> listeVisiteur;
        int index = 0;

        public InfoVisiteur()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affiche les informations du visiteur dans les labels
        /// </summary>
        /// <param name="listeVisiteur"></param>
        /// <param name="indexVisiteur"></param>
        public void AfficherInformationsVisiteur(List<Visiteur> listeVisiteur, int indexVisiteur)
        {
            PicVisiteur.Image = listeVisiteur[indexVisiteur].TabOrientation[0];
            this.listeVisiteur = listeVisiteur;
            index = indexVisiteur;
            LblNomEcrit.Text = listeVisiteur[indexVisiteur].GetNom;
            LblSexeEcrit.Text = listeVisiteur[indexVisiteur].GetSexe.ToString();
            LblTempsEcrit.Text = listeVisiteur[indexVisiteur].TempsZooPersonne.ToString() + " jours";
        }
    }
}
