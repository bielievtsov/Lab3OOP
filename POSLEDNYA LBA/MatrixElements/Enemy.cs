using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Enemy : Cell
    {
        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            Icon = Resource.Enemy;
        }

        public void EnemyMove(Field field, Cell enemy, int x, int y)
        {
            try
            {
                if (field.gameField[y, x] is Mine)
                {
                    Mine m = new Mine(y, x);
                    m.Bombed(field, enemy);
                }
                else if (field.gameField[y, x - 1] is TrapRope)
                {
                    X = x - 1;
                }
                else if (field.gameField[y, x] is Wall)
                {
                    X -= Field.size_x - 3; 
                }
                else
                {
                    X = x;
                }
            }
            catch (IndexOutOfRangeException)
            {
                X = x;
            }
        }
    }
}
