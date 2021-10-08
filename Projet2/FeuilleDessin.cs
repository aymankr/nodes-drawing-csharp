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
    public partial class FeuilleDessin : Form
    {

        private List<Noeud> noeuds;
        private List<Trait> traits;
        private bool enMouvement;
        private bool enDessinTrait;
        private Noeud selection;
        private Point pointCourant;
        private Stack<Action> actionsEffectuees;
        private Stack<Action> actionsAnnulees;

        public FeuilleDessin()
        {
            noeuds = new List<Noeud>();
            traits = new List<Trait>();
            InitializeComponent();
            enMouvement = false;
            enDessinTrait = false;
            actionsEffectuees = new Stack<Action>(50);
            actionsAnnulees = new Stack<Action>(50);
        }
        
        private void App_Paint(object sender, PaintEventArgs e)
        {
            noeuds.FindAll(n => !n.Supprime).ForEach(n => n.Dessine(e.Graphics));
            traits.FindAll(t => !t.Supprime).ForEach(t => t.Dessine(e.Graphics));

            if (selection != null && enDessinTrait)
            {
                selection.DessineEnDirect(e.Graphics, pointCourant);
                selection.Dessine(e.Graphics);
                Rectangle r = new Rectangle(Outils.DessinVersEcran(selection.Position), selection.Taille);
                e.Graphics.DrawRectangle(Pens.Red, r);
            }
        }

        private void FeuilleDessin_MouseDown(object sender, MouseEventArgs e)
        {
            selection = Selection(e.Location);
            Action action;
            MouseWheel += FeuilleDessin_MouseWheel;
            if (deplacement.Checked)
            {
                enMouvement = selection != null;
                action = new Action { TypeAction = Type_Action.Deplacer, Objets = { selection } };
                actionsEffectuees.Push(action);
            }
            else
            {
                if (selection == null && e.Button == MouseButtons.Left)
                {
                    Noeud noeud =
                    new Noeud
                    {
                        Position = Outils.EcranVersDessin(e.Location),
                        Taille = new Size(30, 30),
                        Epaisseur = Outils.epaisseurParDefaut,
                        Couleur = Outils.couleurParDefaut,
                        Texte = Outils.texteParDefaut + noeuds.Count.ToString()
                    };

                    noeuds.Add(noeud);
                    action = new Action { TypeAction = Type_Action.Creer, Objets = { noeud } };
                    actionsEffectuees.Push(action);
                }
                else if (selection != null && e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip cm = new ContextMenuStrip();
                    foreach (string libel in new string[] { "Supprimer", "Modifier" })
                    {
                        ToolStripMenuItem element = new ToolStripMenuItem(libel);
                        element.Click += Element_Click;
                        cm.Items.Add(element);
                    }
                    cm.Show(this, e.Location);

                }
                else if (e.Button != MouseButtons.Right) enDessinTrait = true;
            }
            Refresh();
        }

        private void Element_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            Action action;
            switch (tm.Text)
            {
                case "Modifier":
                    ParametresNoeud param = new ParametresNoeud(selection.Couleur, selection.Epaisseur, selection.Texte);
                    if (param.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        selection.Epaisseur = param.Epaisseur;
                        selection.Couleur = param.Couleur;
                        selection.Texte = param.Texte;
                        action = new Action { TypeAction = Type_Action.Modifier, Objets = { selection } };
                        actionsEffectuees.Push(action);
                        Refresh();
                    }
                    break;
                case "Supprimer":
                    selection.Supprime = true;
                    List<ISupprimable> listObjets = new List<ISupprimable> {selection};

                    traits.ForEach(t =>
                    {
                        if (t.Source == selection || t.Destination == selection) { t.Supprime = true; }
                        { listObjets.Add(t); }
                    });

                    action = new Action { TypeAction = Type_Action.Detruire, Objets = listObjets};
                    actionsEffectuees.Push(action);
                    break;
            }
        }

        private Noeud Selection(Point p)
        {
            return noeuds.FirstOrDefault(n => !n.Supprime && n.Contient(p));
        }

        private void FeuilleDessin_MouseUp(object sender, MouseEventArgs e)
        {
            enMouvement = false;

            if (enDessinTrait)
            {
                Noeud fin = Selection(e.Location);
                
                if (fin != null && !fin.Equals(selection))
                {
                    Trait t = new Trait { Source = selection, Destination = fin };
                    traits.Add(t);
                    Action action = new Action { TypeAction = Type_Action.Creer, Objets = { t } };
                    actionsEffectuees.Push(action);
                }
                else if (fin == null)
                {
                    Noeud noeud =
                    new Noeud
                    {
                        Position = Outils.EcranVersDessin(e.Location),
                        Taille = new Size(30, 30),
                        Epaisseur = Outils.epaisseurParDefaut,
                        Couleur = Outils.couleurParDefaut,
                        Texte = Outils.texteParDefaut + noeuds.Count.ToString()
                    };
                    noeuds.Add(noeud);
                    Action action1 = new Action { TypeAction = Type_Action.Creer, Objets = { noeud } };
                    actionsEffectuees.Push(action1);

                    Trait t = new Trait { Source = selection, Destination = noeud };
                    traits.Add(t);
                    Action action2 = new Action { TypeAction = Type_Action.Creer, Objets = { t } };
                    actionsEffectuees.Push(action2);
                }
                enDessinTrait = false;
            }
            Refresh();
        }

        private void FeuilleDessin_MouseMove(object sender, MouseEventArgs e)
        {
            pointCourant = e.Location;
            
            if (enMouvement)
            {
                selection.Position = selection.Deplace(Outils.EcranVersDessin(pointCourant));
            }
            Refresh();
        }

        private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            if (actionsEffectuees.Count > 0)
            {
                Action a = actionsEffectuees.Pop();
                actionsAnnulees.Push(a);
                a.UndoRedo(true);
                Refresh();
            }

        }

        private void retablirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionsAnnulees.Count > 0)
            {
                Action a = actionsAnnulees.Pop();
                actionsEffectuees.Push(a);
                a.UndoRedo(false);
                Refresh();
            }
        }

        private void reduire_Click(object sender, EventArgs e)
        {
            if (Outils.epaisseurParDefaut >= 1) Outils.epaisseurParDefaut--;
        }
        
        private void agrandir_Click(object sender, EventArgs e)
        {
            Outils.epaisseurParDefaut++;
        }

        private void couleur_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog { Color = Outils.couleurParDefaut };
            if (col.ShowDialog() == DialogResult.OK)
            {
                Outils.couleurParDefaut = col.Color;
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            List<ISupprimable> listObjets = new List<ISupprimable>();

            noeuds.ForEach(n => { n.Supprime = true; listObjets.Add(n); } ) ;
            traits.ForEach(t => { t.Supprime = true; listObjets.Add(t); });

            Action action = new Action { TypeAction = Type_Action.Detruire, Objets = listObjets };
            Outils.Zoom = 1.0f;
            actionsEffectuees.Push(action);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e){}

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Outils.Origine = new Point(Outils.Origine.X, -e.NewValue);
            Refresh();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Outils.Origine = new Point(-e.NewValue, Outils.Origine.Y);
            Refresh();
        }

        private void FeuilleDessin_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    Outils.Zoom *= 1.03f;
                    
                    if (Outils.Zoom > 2f)
                        Outils.Zoom = 2f;
                }
                if (e.Delta < 0)
                {
                    Outils.Zoom *= 0.97f;
                    if (Outils.Zoom < 0.7f)
                    {
                        Outils.Zoom = 0.7f;
                    }
                }
                Refresh();  
            }
        }
    }
}
