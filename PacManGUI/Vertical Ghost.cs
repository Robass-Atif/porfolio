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
  public  class Vertical_Ghost:Ghost
    {
        public Vertical_Ghost(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            this.direction = GameDirection.Down;

            objects = Game.getBlankGameObject();
          
        }
        public bool active = true;
        public GameDirection direction;
        public GameObject objects;
        

        public override void move()
        {

            if (direction == GameDirection.Down)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
              
                if (nextCell.currentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                        direction = GameDirection.Up;

                }
                else
                {
                    
                    
                    {


                        this.CurrentCell = nextCell;
                        if (currentCell != nextCell)
                        {
                            currentCell.setGameObject(objects);

                        }
                        else
                        {
                            direction = GameDirection.Up;
                        }
                    }
                }

            }
            else if (direction == GameDirection.Up)
            {

                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                if (nextCell.currentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                        direction = GameDirection.Down;
                }
                else
                {
                    if (nextCell.currentGameObject.GameObjectType == GameObjectType.PLAYER)
                    {
                        Game.flag1 = false;
                        Game.life--;
                    }
                    else
                    {
                        this.CurrentCell = nextCell;
                        if (currentCell != nextCell)
                        {
                            currentCell.setGameObject(objects);

                        }
                        else
                        {
                            direction = GameDirection.Down;
                        }
                    }
                }
            }


        }
    }
}
