using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projet2
{
    public static class Outils
    {
        public static int epaisseurParDefaut = 1;
        public static Color couleurParDefaut = Color.Black;
        public static String texteParDefaut = "N";
        public static Point Origine = new Point(0, 0);
        public static float Zoom = 1.0f;

        public static Point DessinVersEcran(Point p)
        {
            return new Point( (int)(p.X* Zoom) + Origine.X, (int)(p.Y * Zoom) + Origine.Y);
        }

        public static Point EcranVersDessin(Point p)
        {
            return new Point((int)(p.X * Zoom) - Origine.X, (int)(p.Y * Zoom) - Origine.Y);
        }

        public static Size DessinVersEcran(Size t)
        {
            return new Size((int)(t.Width * Zoom), (int)(t.Height * Zoom));
        }
    }
}
