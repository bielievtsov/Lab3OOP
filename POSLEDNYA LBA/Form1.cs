using POSLEDNYA_LBA.MatrixElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSLEDNYA_LBA
{
    public partial class MainForm : Form
    {
        Teleport teleport = new Teleport(8, 8);
        Field field = new Field();

        public MainForm(Field curfield, Menu menu)
        {
            field = curfield;
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.UserPaint,
                true);
        }

        Hero player = new Hero(1, 1);

        Enemy enemy = new Enemy(5, 7);
        Draws draw = new Draws();
     
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            draw.DrawField(field, player, enemy,g);

            draw.DrawInventory(player, g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {             
            int x = player.X, y = player.Y;
            switch (e.KeyCode)
            {
                case Keys.M:
                    {
                        player.HeroPutsMein(field, player);
                    };
                    break;
                case Keys.L:
                    {
                        player.Inventory(field, player);                        
                    };
                    break;
                case Keys.Up:
                    {
                        player.Insert_In_Matrix(x, y - 1, field, player, teleport);                        
                    };
                    break;
                case Keys.Down:
                    {
                        player.Insert_In_Matrix(x, y + 1, field, player, teleport);                                                
                    };
                    break;
                case Keys.Left:
                    {
                        player.Insert_In_Matrix(x - 1, y, field, player, teleport);                        
                    };
                    break;
                case Keys.Right:
                    {
                        player.Insert_In_Matrix(x + 1, y, field, player, teleport);                       
                    };
                    break;
            }

        }

        Time time = new Time();


        private void timer2_Tick(object sender, EventArgs e)
        {
            time.tick();
            if (time.sec < 10)
                label1.Text = time.min + " : 0" + time.sec;
            else
                label1.Text = time.min + " : " + time.sec;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (time.value == 120)
            {
                Environment.Exit(0);
            }
            time.value++;

            int enemyX = enemy.X, enemyY = enemy.Y;
            enemy.EnemyMove(field, enemy, enemyX + 1, enemyY);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}