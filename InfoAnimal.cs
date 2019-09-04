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
    public partial class InfoAnimal : UserControl
    {
        int index = 0;
        List<Animal> listeAnimal;

        public InfoAnimal()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Affiche les informations de l'animal dans les labels
        /// </summary>
        /// <param name="_liste"></param>
        /// <param name="indexAnimal"></param>
        public void AfficherInformationAnimal(List<Animal> _liste, int indexAnimal)
        {

            LblEnceinte.Visible = false;
            LblEnceinteEcrit.Visible = false;
            index = indexAnimal;
            listeAnimal = _liste;
            LblTypeEcrit.Text = _liste[index].TypeAnimal.ToString();
            LblGenreEcrit.Text = _liste[index].Genre.ToString();
            LblVieillesseEcrit.Text = _liste[index].Vieillesse.ToString();

            //Pour afficher combien de jours l'animal a faim
            if (_liste[index].Etat.ToString() == "Faim")
            {
                LblEtatEcrit.Text = _liste[index].Etat.ToString() + ", " +_liste[index].TempsZooAnimal.ToString() + " jours";
            }
            else
            {
                LblEtatEcrit.Text = _liste[index].Etat.ToString();
            }

            //Si c'est une femelle, affiche si elle est enceinte
            if (LblGenreEcrit.Text == "Femelle")
            {
                foreach (Animal a in _liste)
                {
                    //Il faut avoir au moins 1 male dans l'enclos, qu'elle soit une adulte et qu'ils soient du meme type d'animal
                    if (a.Genre == Genre.Male &&
                        a.TypeAnimal == _liste[index].TypeAnimal &&
                        _liste[index].Vieillesse != Vieillesse.Bebe)
                    {
                        LblEnceinte.Visible = true;
                        LblEnceinteEcrit.Visible = true;
                        LblEnceinteEcrit.Text = _liste[index].Enceinte.ToString();
                        break;
                    }
                }
            }

            if (LblTypeEcrit.Text == "Licorne")
            {
                PicAnimal.Image = TilesetImageGenerator.GetTile(TilesetImageGenerator.LICORNE_BAS);
            }
            else if (LblTypeEcrit.Text == "Rhino")
            {
                PicAnimal.Image = TilesetImageGenerator.GetTile(TilesetImageGenerator.RHINO_BAS);
            }
            else
            {
                PicAnimal.Image = TilesetImageGenerator.GetTile(TilesetImageGenerator.LION_BAS);
            }
        }

        private void BtnSuivant_click(object sender, EventArgs e)
        {
            if (index < listeAnimal.Count-1)
            {
                index++;
                AfficherInformationAnimal(listeAnimal, index);
            }
            else
            {
                AfficherInformationAnimal(listeAnimal, 0);
            }

        }
    }
}
