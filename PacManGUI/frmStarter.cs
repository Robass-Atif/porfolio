using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGUI
{
    public partial class frmStarter : Form
    {
        public frmStarter()
        {
            InitializeComponent();
        }
        int x = 0;
        private void frmStarter_Load(object sender, EventArgs e)
        {


        }
        int y = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(x==4)
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value += 20;
                }
                x = 0;
                
            }
            x++;
            
            if(progressBar1.Value==100 )
            {
                if (y > 4)
                {
                    timer1.Enabled = false;
                    this.Hide();
                    Form1 a = new Form1();
                    a.Show();
                }
                y++;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
