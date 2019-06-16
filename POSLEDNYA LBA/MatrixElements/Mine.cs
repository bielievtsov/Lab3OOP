using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Mine : Cell
    {
        public Mine(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = Resource.Vulnerability;
        }

        public void Bombed(Field field, Cell enemy)
        {
            try
            {
                field.gameField[enemy.Y - 1, enemy.X] = new Empty(enemy.X, enemy.Y - 1);
                field.gameField[enemy.Y + 1, enemy.X] = new Empty(enemy.X, enemy.Y + 1);
                field.gameField[enemy.Y, enemy.X + 1] = new Empty(enemy.X + 1, enemy.Y);
                field.gameField[enemy.Y, enemy.X - 1] = new Empty(enemy.X - 1, enemy.Y);
                enemy.X = -1;
                enemy.Y = -1;
            }
            catch(IndexOutOfRangeException)
            {

            }
        }
    }
}
