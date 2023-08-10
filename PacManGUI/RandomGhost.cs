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
   public  class RandomGhost:Ghost
    {
        
        public RandomGhost( Image image,GameCell startCell) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;
          

            objects = Game.getBlankGameObject();
            a = Game.getBlankGameObject();
        }
        public GameObject objects;
        GameObject a;
        public override void move()
        {
            int value = ghostDirection();
            if (value == 0)
            {

                {
                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(GameDirection.Left);
                    a = nextCell.currentGameObject;
                    if (nextCell.currentGameObject.GameObjectType == GameObjectType.PLAYER)
                    {
                        Game.flag = true;
                    }
                    else
                    {
                        this.CurrentCell = nextCell;
                        if (currentCell != nextCell)
                        {
                            currentCell.setGameObject(objects);
                            objects = nextCell.currentGameObject;
                            objects = a;


                        }

                    }

                }
            }
            else if (value == 1)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(GameDirection.Right);
                a = nextCell.currentGameObject;
                if (nextCell.currentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    Game.flag = true;
                }
                else
                {
                    this.CurrentCell = nextCell;
                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(objects);
                        objects = nextCell.currentGameObject;
                        objects = a;


                    }
                }

            }
            else if (value == 2)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(GameDirection.Up);
                a = nextCell.currentGameObject;
                if (nextCell.currentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    Game.flag = true;
                }
                else
                {
                    this.CurrentCell = nextCell;
                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(objects);
                        objects = nextCell.currentGameObject;
                        objects = a;


                    }
                }
            }
            else
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(GameDirection.Down);
                a = nextCell.currentGameObject;
                if (nextCell.currentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    Game.flag = true;
                }
                else
                {
                    this.CurrentCell = nextCell;
                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(objects);
                        objects = nextCell.currentGameObject;
                        objects = a;


                    }
                }
            }
        }
        static int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
    }
}
