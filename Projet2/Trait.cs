using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Projet2
{
    class Trait : ISupprimable
    {
        public Noeud Source { get; set; }
        public Noeud Destination { get; set; }
        public String Lien { get; set; }
        public bool Supprime { get; set; } = false;

        public void Dessine(Graphics g)
        {
            g.DrawLine(Pens.Blue, Source.Centre, Destination.Centre);
        }

    }
}
