using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    public class Teleport : Cell
    {
        public Teleport(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = Resource.Teleport;
        }

        

        public void TeleportHero(Field field, Hero hero, Cell tl)
        {
            int x = hero.X, y = hero.Y;
            try
            {
                hero.X = tl.X - 2;
                hero.Y = tl.Y - 1;
            }
            catch
            {

            }
        }
    }
}
