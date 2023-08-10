using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;
using System.Windows.Forms;
using System.Drawing;

namespace PacManGUI
{
  public   class LifeCharacter:GameObject
    {
        public LifeCharacter(Image image, GameCell startCell) : base(GameObjectType.POWER, image)
        {
            this.CurrentCell = startCell;
        }
        
    }
}
