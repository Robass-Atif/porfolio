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
  public  class Horizontal_Ghost:Ghost
    {
        public Horizontal_Ghost(Image image, GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
            this.direction = GameDirection.Right;
           
            objects = Game.getBlankGameObject();
           
        }
        public bool active = true;
        public   GameDirection direction;
        GameObject objects;
        int x = 0;
        public override void move()
        {
            if (x == 2)
            {
                if (direction == GameDirection.Left)
                {
                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(direction);
                 
                    if (nextCell.currentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        direction = GameDirection.Right;

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
                                direction = GameDirection.Right;


                            }
                        }
                    }

                }
                else if (direction == GameDirection.Right)
                {

                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(direction);
                    if (nextCell.currentGameObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        direction = GameDirection.Left;

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
                                direction = GameDirection.Left;

                            }
                        }
                    }
                }
                x = 0;
            }
            x++;


        }

    }
}
