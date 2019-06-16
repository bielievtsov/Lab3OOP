using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class TrapRope : Cell
    {
        public TrapRope(int x, int y)
        {
            X = x;
            Y = y;
            Icon = Resource.TrapRope;
        }
    }
}
