using POSLEDNYA_LBA.MatrixElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA
{
    class Draws
    {
        public Draws()
        {

        }

        public void DrawInventory(Hero hero, Graphics g)
        {
            int h = 160;

            foreach (Cell i in hero.inventoty)
            {

                g.DrawImage(i.Icon, h, 480);
                h += 50;
            }
        }

        public void DrawField(Field field, Hero player, Enemy enemy, Graphics g)
        {
            if (field.NumberOfGold <= 0)
            {
                Environment.Exit(0);
            }
            for (int i = 0; i < Field.size_y; i++)
            {
                for (int j = 0; j < Field.size_x; j++)
                {
                    if (player.Y == enemy.Y && player.X == enemy.X)
                    {
                        Environment.Exit(0);
                    }
                    if (i == player.Y && j == player.X)
                    {
                        g.DrawImage(player.Icon, player.X * 50, player.Y * 50);
                    }
                    else if (i == enemy.Y && j == enemy.X)
                    {
                        g.DrawImage(enemy.Icon, enemy.X * 50, enemy.Y * 50);
                    }
                    else
                    {
                        g.DrawImage(field.gameField[i, j].Icon, j * 50, i * 50);
                    }
                }
            }

            Font drawFont = new Font("Arial", 16);

            SolidBrush drawBrush = new SolidBrush(Color.Bisque);

            PointF drawPoint = new PointF(0, 450);

            PointF drawPoint1 = new PointF(0, 500);

            g.DrawString($"The number of taken coins is {player.Coin}", drawFont, drawBrush, drawPoint);

            g.DrawString("The inventory is ", drawFont, drawBrush, drawPoint1);
        }
    }
}
