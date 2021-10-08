using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2
{
    public class Action
    {
        public Type_Action TypeAction { get; set; }
        public List<ISupprimable> Objets { get; set; } = new List<ISupprimable>();

        public void UndoRedo(Boolean estUnUndo)
        {
            switch (TypeAction)
            {
                case Type_Action.Creer:
                    foreach (ISupprimable o in Objets) { o.Supprime = estUnUndo; }
                    break;
                case Type_Action.Detruire:
                    foreach (ISupprimable o in Objets) { o.Supprime = !estUnUndo;}
                    break;
            }
        }
    }
}
