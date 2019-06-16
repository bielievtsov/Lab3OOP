using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Ladder : Cell
    {
        public Ladder(int X, int Y)
        {
            Icon = Resource.Ladder;
            this.X = X;
            this.Y = Y;
        }
    }
}
