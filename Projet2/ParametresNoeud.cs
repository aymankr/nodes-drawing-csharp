using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet2
{
    public partial class ParametresNoeud : Form
    {
        public Color Couleur { get { return couleur.BackColor; } }
        public int Epaisseur { get { return (int)epaisseur.Value; } }

        public String Texte { get { return (String)texte.Text; } }


        public ParametresNoeud(Color c, int e, String t)
        {
            InitializeComponent();
            epaisseur.Value = e;
            couleur.BackColor = c;
            texte.Text = t;
        }

        private void couleur_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog { Color = Couleur };
            if (col.ShowDialog() == DialogResult.OK)
            {
                couleur.BackColor = col.Color;
            }
        }
    }
}
