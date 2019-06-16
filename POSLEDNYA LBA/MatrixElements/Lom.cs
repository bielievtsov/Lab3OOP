using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Lom : Cell
    {
        public Lom(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = Resource.Lom;
        }
    }
}
