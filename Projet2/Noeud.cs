using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet2
{
    class Noeud : ISupprimable
    {
        public Point Position { get; set; }
        public Size Taille { get; set; }

        public int Epaisseur{get; set;}

        public Color Couleur { get; set; }

        public String Texte { get; set; }

        public bool Supprime { get; set; } = false;

        public void Dessine(Graphics g)
        {
            Rectangle r = new Rectangle(Outils.DessinVersEcran(Position), Outils.DessinVersEcran(Taille));
            Pen p = new Pen(Couleur, Epaisseur);
            g.DrawRectangle(p, r);
            g.DrawString(Texte, new Font("Times New Roman", Outils.Zoom*10, FontStyle.Regular),
                Brushes.Black, new Point(Outils.DessinVersEcran(Position).X
                                    , Outils.DessinVersEcran(Position).Y));
        }

        public Point Deplace(Point p)
        {
            int x = p.X;
            int y = p.Y;
            return new Point(x, y);
        }

        public Point Centre
        {
            get
            {
                return new Point(Outils.DessinVersEcran(Position).X + Outils.DessinVersEcran(Taille).Width / 2,
          Outils.DessinVersEcran(Position).Y + Outils.DessinVersEcran(Taille).Height / 2);
            }
        }
        public bool Contient(Point p)
        {
            Rectangle r = new Rectangle(Position, Taille);
            return r.Contains(Outils.EcranVersDessin(p));
        }

        public void DessineEnDirect(Graphics g, Point p)
        {
            g.DrawLine(Pens.Red, this.Centre, p);
        }
    }
    
}
