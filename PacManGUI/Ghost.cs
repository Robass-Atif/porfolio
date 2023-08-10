using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PacMan.GameGL;

namespace PacManGUI
{
   public abstract class Ghost:GameObject
    {
        public Ghost(GameObjectType type,Image image) : base(GameObjectType.ENEMY, image)
        {
            //this.CurrentCell = startCell;
        }

        public abstract void move();
    }
}
