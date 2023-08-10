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
  public  class SmartGhost:Ghost
    {

        GamePacManPlayer Pacman;
        public SmartGhost(Image image, GameCell startCell,GamePacManPlayer p) : base(GameObjectType.ENEMY, image)
        {
            this.CurrentCell = startCell;

            this.Pacman = p;
            objects = Game.getBlankGameObject();
            a = Game.getBlankGameObject();
        }
        GameObject objects;
        GameObject a;
        public override void move()
        {
           
            double[] distance = new double[4];
            
            
                distance[0] = calculateDistance(this.CurrentCell.X - 1, this.CurrentCell.Y, Pacman.CurrentCell);
                distance[1] = calculateDistance(this.CurrentCell.X + 1, this.CurrentCell.Y, Pacman.CurrentCell);
                distance[2] = calculateDistance(this.CurrentCell.X, this.CurrentCell.Y - 1, Pacman.CurrentCell);
                distance[3] = calculateDistance(this.CurrentCell.X, this.CurrentCell.Y + 1, Pacman.CurrentCell);

            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
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
            else if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
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
            else if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
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
            else
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
        

        }
        

       public static double calculateDistance(int x,int y,GameCell p)
        {
            return Math.Sqrt(Math.Pow((p.X - x), 2) + Math.Pow((p.Y - y), 2));
        }
    }
}
