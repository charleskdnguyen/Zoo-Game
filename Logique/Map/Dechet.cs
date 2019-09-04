using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TP2.Logique;

namespace TP2.Logique.Map
{
    public class Dechet
    {
        private int x;
        private int y;

        /// <summary>
        /// Constructeur pour créer un déchet
        /// </summary>
        /// <param name="positionVisiteurX"></param>
        /// <param name="positionVisiteurY"></param>
        public Dechet(int positionVisiteurX, int positionVisiteurY)
        {
            x = positionVisiteurX;
            y = positionVisiteurY;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }
    
}