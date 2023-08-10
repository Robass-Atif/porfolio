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
  public   class GHost_fires:GameObject
    {
        public bool active = true;
        GameDirection d;
        public GHost_fires(Image image, GameCell start, GameDirection d) : base(GameObjectType.FIRE, image)
        {
            this.CurrentCell = start;
            this.d = d;
        }
        public void move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(d);
            if(nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                Game.playerLife -= 25;
            }
            if (currentCell == nextCell || nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER || nextCell.CurrentGameObject.GameObjectType == GameObjectType.FIRE || nextCell.CurrentGameObject.GameObjectType == GameObjectType.POWER)
            {
                active = false;

            }

            if (active)
            {
                this.CurrentCell = nextCell;
            }

             currentCell.setGameObject(Game.getBlankGameObject());

            
        }
    }
}
