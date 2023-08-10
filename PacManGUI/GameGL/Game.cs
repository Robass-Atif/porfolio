using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PacManGUI;
namespace PacMan.GameGL
{
    public class Game
    {
        public static int score=0;
        public static int playerLife = 100;
        public static int life = 3;
        public static int Vghost = 10;
        public static int bigGHost = 10;
       public static bool flag1 = true;
        public static bool powerFlag = true;
      public static  bool bigGhost = false;


        public static List<GHost_fires> bigGhostFires = new List<GHost_fires>();


        public static bool flag = false;
    public  static   List<PlayerFires> fires = new List<PlayerFires>();
        public static List<GHost_fires> GHostFires = new List<GHost_fires>();

        public static GameObject getBlankGameObject(){
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, PacManGUI.Properties.Resources.simplebox);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = PacManGUI.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = PacManGUI.Properties.Resources.vertical;
            }
            if(displayCharacter=='+')
            {
                img = PacManGUI.Properties.Resources.not_removebg_preview;
            }

            if(displayCharacter=='#')
            {
                img = PacManGUI.Properties.Resources.horizontal;
            }

            
            if (displayCharacter == 'P' || displayCharacter == 'p') {
                img = PacManGUI.Properties.Resources.image;
            }
            if(displayCharacter=='H')
            {
                img = PacManGUI.Properties.Resources.hullLarge__2_;
            }
            if(displayCharacter=='R')
            {
                img = PacManGUI.Properties.Resources.image__2_;

            }
            if(displayCharacter=='~')
            {
                img = PacManGUI.Properties.Resources.image__3_;

            }
            if(displayCharacter=='V')
            {
                img = PacManGUI.Properties.Resources.Vertical_Board;
            }
            if(displayCharacter=='-')
            {
                img = PacManGUI.Properties.Resources.image__5_;
            }
            if (displayCharacter == '*')
            {
                img = PacManGUI.Properties.Resources.laserRed01;
            }
            if (displayCharacter=='&')
            {
                img = PacManGUI.Properties.Resources.Vertical_laser;
            }
            if(displayCharacter=='B')
            {
                img = PacManGUI.Properties.Resources.Big_Ghost;
            }

            return img;
        }
        public static void removeFire()
        {
            for(int i=0;i<fires.Count;i++)
            {
                if(!fires[i].Active)
                {
                    fires[i].CurrentCell.setGameObject(Game.getBlankGameObject());
                    fires.Remove(fires[i]);
                }
            }
        }
        public static void moveFire()
        {
            foreach (PlayerFires x in fires)
            {
                x.move();
            }
        }
        public static void moveGhostFire()
        {
            foreach (GHost_fires x in GHostFires)
            {
                x.move();
            }
        }
        public static void removeGhostFire()
        {
            for (int i = 0; i < GHostFires.Count; i++)
            {
                if (!GHostFires[i].active)
                {
                    GHostFires.Remove(GHostFires[i]);
                }
            }
        }
        public static void movebigGhostFire()
        {
            foreach(GHost_fires x in bigGhostFires)
            {
                x.move();
            }
        }
        public static void removeBigGhostFire()
        {
            for (int i = 0; i < bigGhostFires.Count; i++)
            {
                if (!bigGhostFires[i].active)
                {
                    bigGhostFires.Remove(bigGhostFires[i]);
                }
            }
        }
    }
}
