using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;
using PacManGUI;
using System.Drawing;

namespace PacMan.GameGL
{
   public  class PlayerFires:GameObject
    {
        private bool active = true;
        GameDirection d;
        public PlayerFires( Image image,GameCell start,GameDirection d): base (GameObjectType.FIRE,image)
        {
            this.CurrentCell = start;
            this.d = d;
        }

        public bool Active { get => active; set => active = value; }

        public void move()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(d);
            if(nextCell.CurrentGameObject.GameObjectType==GameObjectType.ENEMY)
            {
                Game.Vghost--;
                if(Game.bigGhost)
                {
                    Game.bigGHost--;
                }
                Game.score+=2;
                
            }
            



            
            
            if(currentCell==nextCell || nextCell.CurrentGameObject.GameObjectType==GameObjectType.ENEMY )
            {
                Active = false;
               
            }
            if(Active)
            {
                this.CurrentCell = nextCell;

            }
            currentCell.setGameObject(Game.getBlankGameObject());
            
            
        }
    }
}
