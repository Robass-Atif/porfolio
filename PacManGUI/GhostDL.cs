using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;


namespace PacManGUI
{
   public  class GhostDL
    {
        public static List<Ghost> ghosts = new List<Ghost>();
        public static void move()
        {
            for(int i=0;i<ghosts.Count;i++)
            {
                
                    ghosts[i].move();
                  
                
                
            }
        }
        
        

        
        
    }
}
