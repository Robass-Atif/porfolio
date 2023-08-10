using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PacManGUI;

namespace PacMan.GameGL
{
  public  class GamePacManPlayer : GameObject
    {
        
        public GamePacManPlayer(Image image,GameCell startCell):base (GameObjectType.PLAYER,image) {
            this.CurrentCell = startCell;
        }
        public void move(GameDirection direction) {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell= currentCell.nextCell(direction);
            if(nextCell.currentGameObject.GameObjectType==GameObjectType.POWER)
            {
                Game.life++;
                Game.powerFlag = true;
            }

            if (nextCell.currentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                Game.flag1 = false;
                Game.playerLife = 0; 

            }
            this.CurrentCell = nextCell;
            if (currentCell != nextCell) {
                
                currentCell.setGameObject(Game.getBlankGameObject());

            }
        
        }

    }

    
}
