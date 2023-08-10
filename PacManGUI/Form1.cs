using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
namespace PacManGUI
{
    public partial class Form1 : Form
    {
       GamePacManPlayer pacman;
        Horizontal_Ghost H;
        Vertical_Ghost V;
        Vertical_Ghost bigG;
        int timer = 0;
        
        LifeCharacter power;
        Random rand = new Random();
        
         
        
        public Form1()
        {
            InitializeComponent();
        }

        GameGrid grid;
        
        private void Form1_Load(object sender, EventArgs e)
        {
             grid = new GameGrid("maze.txt", 24, 69);
            createPacman();
            createHGhost();
            createVGhost(); 
            printMaze(grid);
            
            creationOfLAbelThings();
        }
        private void startCellOfPacman()
        {
            if(!Game.flag1)
            {
                GameCell curr = pacman.CurrentCell;
            GameCell startCell = grid.getCell(8, 10);

                pacman.CurrentCell = startCell;
                curr.setGameObject(Game.getBlankGameObject());
               Game.flag1 = true;
            }
        }
        private void start()
        {
            this.Controls.Clear();
            gameLoop.Enabled = true;
          Game.bigGhost = false;
            Game.bigGHost = 10;
            grid = new GameGrid("maze.txt", 24, 69);

            createPacman();
            createHGhost();
            createVGhost();
            Game.playerLife = 100;
            Game.life = 3;
            printMaze(grid);
            creationOfLAbelThings();
           
        }

        private void createPacman()
        {
            Image pacManImage = Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(8, 10);
            pacman = new GamePacManPlayer(pacManImage, startCell);
        }
        private void createPowerBooster()
        {
            int element = rand.Next(1, 4);
            if (element == 1)
            {
                Image pacManImage = Game.getGameObjectImage('+');
                GameCell startCell = grid.getCell(9, 10);
                power = new LifeCharacter(pacManImage, startCell);
            }
            if (element == 2)
            {
                Image pacManImage = Game.getGameObjectImage('+');
                GameCell startCell = grid.getCell(9, 14);
                power = new LifeCharacter(pacManImage, startCell);
            }
            if (element == 3)
            {
                Image pacManImage = Game.getGameObjectImage('+');
                GameCell startCell = grid.getCell(14, 5);
                power = new LifeCharacter(pacManImage, startCell);
            }
            if (element == 4)
            {
                Image pacManImage = Game.getGameObjectImage('+');
                GameCell startCell = grid.getCell(4, 40);
                power = new LifeCharacter(pacManImage, startCell);
            }
        }
        private void createHGhost()
        {
            Image pacManImage = Game.getGameObjectImage('H');
            GameCell startCell = grid.getCell(2, 63);
            H = new Horizontal_Ghost(pacManImage, startCell);
            GhostDL.ghosts.Add(H);
        }
        private void createVGhost()
        {
            Image pacManImage = Game.getGameObjectImage('V');
            GameCell startCell = grid.getCell(5, 64);
            V = new Vertical_Ghost(pacManImage, startCell);
            GhostDL.ghosts.Add(V);
        }
        private void createBigGHost()
        {
            Image pacManImage = Game.getGameObjectImage('B');
            GameCell startCell1 = grid.getCell(6, 62);
            bigG = new Vertical_Ghost(pacManImage, startCell1);
            GhostDL.ghosts.Add(bigG);
           Game.bigGhost = true;
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
               
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);          
            
                }

            }
        }
    
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

        int timerOfPower = 0;
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.LeftArrow)) {
                pacman.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow)){
                pacman.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow)){
                pacman.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow)){
               
                pacman.move(GameDirection.Down);
            }
            
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                if (timer == 2)
                {
                    createFire();
                    timer = 0;
                }
                timer++;
            }
            if(timerOfPower==150)
            {
                if (Game.powerFlag)
                {
                    createPowerBooster();
                    Game.powerFlag = false;
                }
                timerOfPower = 0;
                
            }
            timerOfPower++;
            score1.Text = Game.score.ToString();
            if (V.active)
            {
                createVFire();
            }
                Game.removeGhostFire();
            Game.moveGhostFire();
            if (H.active)
            {
                createGhostFire(GameDirection.Down);
            }
                Game.moveFire();
            GhostDL.move();
            Game.removeFire();
            
            health.Value = Game.playerLife;
            removevghost();
            if (Game.bigGhost == true)
            {
                if (timer2 == 3)
                {
                    BigGHostFire();
                    timer2 = 0;
                }
                timer2++;
            }
                Game.movebigGhostFire();
            Game.removeBigGhostFire();
            startCellOfPacman();
            life();
            YouWin();
            life1.Text = Game.life.ToString();
        }
        int timer2 = 0;
        private void removevghost()
        {
            
            if (Game.Vghost <= 0)
            {

                GhostDL.ghosts.Remove(V);
                GhostDL.ghosts.Remove(H);
                H.active = false;
                V.active = false;
                V.CurrentCell.setGameObject(Game.getBlankGameObject());
                H.CurrentCell.setGameObject(Game.getBlankGameObject());
                Game.Vghost = 10;
                createBigGHost();
            }

        }
        private void YouWin()
        {
            if(Game.bigGHost<=0)
            {
                gameLoop.Enabled = false;
                EndGame end = new EndGame(PacManGUI.Properties.Resources.download);
                DialogResult result = end.ShowDialog();
                if (result == DialogResult.OK)
                {
                    start();
                }
                else
                {
                    this.Close();
                }

            }
        }
        private void life()
        {
          if(  Game.playerLife == 0 && Game.life>0)
            {
                Game.life--;
                Game.playerLife = 100;
                
               
            }
          if(Game.life<0  )
            {
                
                    gameLoop.Enabled = false;
                    EndGame end = new EndGame(PacManGUI.Properties.Resources.GAme_over);
                    DialogResult result = end.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        start();
                    }
                    else
                    {
                        this.Close();
                    }
                
            }
          else if(Game.life==0 && Game.playerLife==0)
            {
                gameLoop.Enabled = false;
                EndGame end = new EndGame(PacManGUI.Properties.Resources.GAme_over);
                DialogResult result = end.ShowDialog();
                if (result == DialogResult.OK)
                {
                    start();
                }
                else
                {
                    this.Close();
                }
            }
        }
     private void createFire()
        {
            if (pacman.CurrentCell.Y + 2 < 67)
            {
                Image fireImage = Game.getGameObjectImage('-');
                GameCell startCell = grid.getCell(pacman.CurrentCell.X, pacman.CurrentCell.Y+1);
                PlayerFires f = new PlayerFires(fireImage, startCell,GameDirection.Right);
                Game.fires.Add(f);
            }
        }
        int x = 0;
        private void createVFire()
        {
            if (x==5)
            {
                Image fireImage = Game.getGameObjectImage('&');
                GameCell startCell = grid.getCell(V.CurrentCell.X, V.CurrentCell.Y-1 );
                GHost_fires f = new GHost_fires(fireImage, startCell, GameDirection.Left);
                Game.GHostFires.Add(f);
                x = 0;
            }
            x++;
        }
        int timerGhostFire = 0;
        private void createGhostFire(GameDirection d1)
        {

            GameDirection d=d1;
            if (timerGhostFire == 3)
            {
                Image fireImage = Game.getGameObjectImage('*');
                GameCell startCell = grid.getCell(H.CurrentCell.X + 2, H.CurrentCell.Y);
                GHost_fires f = new GHost_fires(fireImage, startCell, d);
                Game.GHostFires.Add(f);
                timerGhostFire = 0;
            }
            timerGhostFire++;
        }
        private void BigGHostFire()
        {

            Image fireImage = Game.getGameObjectImage('~');
            GameCell startCell = grid.getCell(bigG.CurrentCell.X , bigG.CurrentCell.Y-2);
            GHost_fires f = new GHost_fires(fireImage, startCell,GameDirection.Left );
            Game.bigGhostFires.Add(f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public Label score;
         Label life2;
        Label health1;
        TextBox score1;
        TextBox life1;
        ProgressBar health;


        private void creationOfLAbelThings()
        {
             score = new Label();
            score.ForeColor = Color.Yellow;
            score.Left = 100;
            score.Top = this.Height - 250;
            score.Text = "Score : ";
            score.Font = new Font(score.Font.FontFamily, 14);

             score1 = new TextBox();
            score1.ForeColor = Color.Yellow;
            score1.Left = (score.Left+score.Width)+ 20;
         
            score1.Top = this.Height - 250;
            score1.ReadOnly = true;
            score1.Text = "0";

             life2 = new Label();
            life2.ForeColor = Color.Yellow;
            life2.Left = 100;
            life2.Top = this.Height - 180;
            life2.Text = "Life : ";
            life2.Font = new Font(score.Font.FontFamily, 14);


             life1 = new TextBox();
            life1.ForeColor = Color.Yellow;
            life1.Left = (life2.Left + life2.Width) + 5;

            life1.Top = this.Height - 180;
            life1.ReadOnly = true;
            life1.Text = Game.life.ToString();

           

             health1 = new Label();
            health1.ForeColor = Color.Yellow;
            health1.Left = score1.Left+150;
            health1.Top = this.Height - 250;
            health1.Text = "Health: ";
            health1.Font = new Font(score.Font.FontFamily, 14);


             health = new ProgressBar();
            health.Left = health1.Left + health1.Width + 10;
            health.Top = health1.Top;
            health.Value = Game.playerLife;


            this.Controls.Add(health);
            this.Controls.Add(life1);
            this.Controls.Add(life2);
            this.Controls.Add(score);
            this.Controls.Add(score1);
            this.Controls.Add(health1);

        }
    }
}
